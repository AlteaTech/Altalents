using AlteaTools.Api.Core.Extensions;

using AnyAscii;

using Altalents.Commun.Helpers;
using Altalents.Commun.Settings;
using Altalents.Entities.Enum;

using Hangfire;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace Altalents.Business.Services
{
    public partial class MarqueService : BaseAppService<CustomDbContext>, IMarqueService
    {
        private const string EXPORT_RKD = $"Export RKD";
        private const string TITRE_MAIL_RKD_PART1 = "Voici l'export RKD de la publication, il y a ";
        private const string TITRE_MAIL_RKD_PART2 = " Marque(s)";
        private static string RKDFileName => $"Export RKD {DateTime.Today.Year}-{DateTime.Today.Month}.csv";
        private readonly MarqueSettings _marqueSettings;
        private readonly PurgeSettings _purgeSettings;
        private readonly IReferenceService _referenceService;
        private readonly IEmailService _emailService;
        private readonly EmailSettings _emailSettings;

        public MarqueService(
            IOptionsMonitor<PurgeSettings> purgeSettings,
            IOptionsMonitor<MarqueSettings> marqueSettings,
            IReferenceService referenceService,
            IEmailService emailService,
            ILogger<MarqueService> logger,
            CustomDbContext dbContext,
            IMapper mapper, IOptionsMonitor<EmailSettings> emailSettings,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
            _marqueSettings = marqueSettings.CurrentValue;
            _purgeSettings = purgeSettings.CurrentValue;
            _referenceService = referenceService;
            _emailService = emailService;
            _emailSettings = emailSettings.CurrentValue;
        }

        public async Task<Guid> InsertNouvelleMarqueAsync(CancellationToken cancellationToken = default)
        {
            Marque marque = new()
            {
                Notices = await DbContext.OngletNoticeMarques.Where(x => x.IsDefaultCreation).Select(x => new MarqueNotice()
                {
                    OngletNoticeMarqueId = x.Id,
                    Texte = "Saisissez votre Notice ici"
                }).ToListAsync(cancellationToken)
            };
            await DbContext.Marques.AddAsync(marque, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            BackgroundJob.Schedule(() => DeleteMarque(marque.Id, default), TimeSpan.FromSeconds(_purgeSettings.TimeToLiveMarqueNonFinalizeSeconds));
            return marque.Id;
        }

        public void DeleteMarque(Guid id, CancellationToken cancellationToken = default)
        {
            DeleteMarqueAsync(id, cancellationToken).GetAwaiter().GetResult();
        }

        public async Task<bool> MarqueExistAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext.Marques.AnyAsync(x => x.Id == id, cancellationToken);
        }

        private async Task DeleteMarqueAsync(Guid id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            PurgeMarquesRenvois(id, cancellationToken);
            Marque marque = await DbContext.Marques
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsFinalize, cancellationToken: cancellationToken);

            if (marque == null)
            {
                return;
            }

            if (marque.DateMaj.HasValue && marque.DateMaj.Value.AddSeconds(_purgeSettings.TimeToLiveMarqueNonFinalizeSeconds) > DateTime.Now)
            {
#if DEBUG
#else
                BackgroundJob.Schedule(() => DeleteMarque(marque.Id, default), TimeSpan.FromSeconds(_purgeSettings.TimeToLiveMarqueNonFinalizeSeconds));
                return;
#endif
            }

            DbContext.Marques.Remove(marque);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            foreach (MarqueImage image in marque.Images)
            {
                BackgroundJob.Schedule(() => DeleteFile(image.FullPath), TimeSpan.FromSeconds(1));
            }
            BackgroundJob.Schedule(() => PurgeOngletOrphelin(CancellationToken.None), TimeSpan.FromSeconds(1));
        }

        public void PurgeOngletOrphelin(CancellationToken cancellationToken = default)
        {
            DbContext.OngletNoticeMarques.RemoveRange(DbContext.OngletNoticeMarques.Where(x => x.IsSupprimable && !x.Notices.Any()));
            DbContext.SaveBaseEntityChangesAsync(cancellationToken).GetAwaiter().GetResult();
        }

        public void PurgeMarquesRenvois(Guid marqueId, CancellationToken cancellationToken = default)
        {
            PurgeMarquesRenvoisByMarqueIdTravailAsync(marqueId, cancellationToken).GetAwaiter().GetResult();
        }

        public async Task CheckMarqueExistAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            if (!await MarqueExistAsync(idMarque, cancellationToken))
            {
                throw new StatusCodeException(System.Net.HttpStatusCode.NotFound);
            }
        }

        public async Task<bool> GetMarqueIsFinalized(Guid idMarque, CancellationToken cancellationToken = default)
        {
            return await DbContext.Marques
                .Where(x => x.Id == idMarque)
                .Select(x => x.IsFinalize)
                .FirstAsync(cancellationToken);
        }

        private async Task MajDateMajMarqueAsync(Guid idMarque, CancellationToken cancellationToken)
        {
            Marque marque = await DbContext.Marques.AsTracking().FirstAsync(x => x.Id == idMarque, cancellationToken);
            marque.DateMaj = DateTime.Now;
        }

        public async Task<string> GetReferenceLugtByMarqueIdAsync(Guid idMarque, bool isLight = false, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(idMarque, cancellationToken);
            return await DbContext.Marques.Where(x => x.Id == idMarque).Select(x => isLight ? x.ReferenceLugtLight : x.ReferenceLugtLight).SingleAsync(cancellationToken);
        }

        public async Task<List<MarqueDtoBase>> GetMarquesFinaliseesAsync(string text, CancellationToken cancellationToken = default)
        {
            IOrderedQueryable<Marque> query = GetMarquesFinaliseesQuery(text);
            return await query.ProjectTo<MarqueDtoBase>(Mapper.ConfigurationProvider)
                            .OrderBy(x => x.ReferenceLugt)
                            .ToListAsync(cancellationToken);
        }

        private IOrderedQueryable<Marque> GetMarquesFinaliseesQuery(string text)
        {
            IQueryable<Marque> query = DbContext.Marques.AsQueryable();
            if (!string.IsNullOrWhiteSpace(text))
            {
                query = query.Where(x => x.ReferenceLugt.Contains(text));
            }
            return query.Where(x => x.IsFinalize)
                        .OrderBy(x => x.NumeroLugt);
        }

        private async Task CheckMarqueIsPubliableReferencesAsync(List<MarqueSousReferenceReference> marqueSousReferenceReferences, CancellationToken cancellationToken)
        {
            Task<List<Guid>> taskReferencesWithSousReferences = _referenceService.GetReferencesIdsWithAnySousReferenceAsync(marqueSousReferenceReferences.Select(x => x.ReferenceId)
                                                                                                                                                         .Distinct()
                                                                                                                                                         .ToList(),
                                                                                                                            cancellationToken);
            List<Guid> nomIds = await DbContext.References.Where(x => x.TypeReferenceId == EnumTypeReference.Nom.GetBddId())
                                                          .Select(x => x.Id)
                                                          .ToListAsync(cancellationToken);

            // Au moins un nom (principal)
            if (!marqueSousReferenceReferences.Any(x => x.IsPrincipal && nomIds.Contains(x.ReferenceId)))
            {
                throw new BusinessException(BusinessExceptionsResources.NOM_PRINCIPAL_OBLIGATOIRE);
            }
        }

        private static void CheckMarqueIsPubliableNotices(List<MarqueNotice> notices)
        {
            // Au moins une notice publiée
            if (!notices.Any(x => x.IsPublie))
            {
                throw new BusinessException(BusinessExceptionsResources.NOTICE_NON_PUBLIEE);
            }
        }

        public async Task<DateTime?> GetDatePublicationByMarqueIdAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(idMarque, cancellationToken);
            return await DbContext.Marques.Where(x => x.Id == idMarque).Select(x => x.DatePublication).SingleAsync(cancellationToken);
        }

        public async Task<byte[]> ExporterAsync(CancellationToken cancellationToken = default)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Position = 0;
                List<MarqueExportDto> marques = await DbContext.Marques.Where(x => x.IsFinalize)
                                                                       .Where(x => x.DatePublication.HasValue)
                                                                       .OrderBy(x => x.ReferenceLugt)
                                                                       .ProjectTo<MarqueExportDto>(Mapper.ConfigurationProvider)
                                                                       .ToListAsync(cancellationToken);
                foreach (MarqueExportDto marque in marques)
                {
                    byte[] ligne = Encoding.UTF8.GetBytes($"{marque.ReferenceLugtLight};{_marqueSettings.PathDetailMarqueFront}{marque.MarqueId};{marque.NomPrincipal};");
                    memoryStream.Write(ligne, 0, ligne.Length);
                    ligne = Encoding.UTF8.GetBytes(Environment.NewLine);
                    memoryStream.Write(ligne, 0, ligne.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public async Task<byte[]> PublierAsync(CancellationToken cancellationToken = default)
        {
            int totalPublished = 0;
            using (CustomDbContext context = GetScopedDbContexte())
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    memoryStream.Position = 0;

                    IQueryable<Marque> queryMarqueToUpdate = context.Marques
                        .Where(x => x.IsFinalize)
                        .Where(x => x.Notices.Any(a => !a.IsPublie));

                    IQueryable<MarquePublicationDto> publishedMarqueQuery = queryMarqueToUpdate
                                                    .OrderBy(x => x.ReferenceLugt)
                                                    .ProjectTo<MarquePublicationDto>(Mapper.ConfigurationProvider);

                    List<MarquePublicationDto> publishedMarque = await publishedMarqueQuery.ToListAsync(cancellationToken);
                    totalPublished = publishedMarque.Count;
                    DateTime datePublication = DateTime.UtcNow;

                    await queryMarqueToUpdate.ExecuteUpdateAsync(x => x.SetProperty(a => a.DatePublication, datePublication), cancellationToken);
                    await context.MarqueNotices.Where(x => x.Marque.IsFinalize && !x.IsPublie).ExecuteUpdateAsync(x => x.SetProperty(a => a.IsPublie, true), cancellationToken);

                    foreach (MarquePublicationDto marque in publishedMarque)
                    {
                        byte[] ligne = Encoding.UTF8.GetBytes($"{marque.ReferenceLugtLight};{_marqueSettings.PathDetailMarqueFront}{marque.MarqueId};{marque.NomPrincipal};{marque.Pays};{marque.Ville};");
                        memoryStream.Write(ligne, 0, ligne.Length);
                        ligne = Encoding.UTF8.GetBytes(Environment.NewLine);
                        memoryStream.Write(ligne, 0, ligne.Length);
                    }
                    transaction.Commit();
                    byte[] bytes = memoryStream.ToArray();
                    if (_emailSettings.UseHangfireToSendMail)
                    {
                        BackgroundJob.Schedule(() => EnoyerPjPublishAll(bytes, totalPublished), TimeSpan.FromSeconds(1));
                    }
                    else
                    {
                        await _emailService.SendEmailForCSVAsync(_emailSettings.DestinatairePublishAll, EXPORT_RKD, TITRE_MAIL_RKD_PART1 + totalPublished + TITRE_MAIL_RKD_PART2, bytes, RKDFileName);
                    }
                    return bytes;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<List<MarqueNonPublieDto>> GetMarquesNonPublieesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Marques.Where(x => x.IsFinalize)
                        .Where(x => x.Notices.Any(a => !a.IsPublie))
                .OrderBy(x => x.NumeroLugt)
                .ThenBy(x => x.ReferenceLugtLight)
                .ProjectTo<MarqueNonPublieDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public void EnoyerPjPublishAll(byte[] bytes, int totalPublished)
        {
            _emailService.SendEmailForCSV(_emailSettings.DestinatairePublishAll, EXPORT_RKD, TITRE_MAIL_RKD_PART1 + totalPublished + TITRE_MAIL_RKD_PART2, bytes, RKDFileName);
        }

        public void RepriseDeDonneesReferenceSousRefTransliteration()
        {
            RepriseDeDonneesReference();
            RepriseDeDonneesSousReference();
        }

        public void RepriseDeDonneesReferenceLibreMarquesTransliteration()
        {
            List<MarqueReferenceLibre> marqueReferenceLibres = new();
            int traite = 0;
            int offset = 100;
            do
            {
                marqueReferenceLibres = DbContext.MarqueReferenceLibres.Where(x => !string.IsNullOrWhiteSpace(x.Texte))
                                                                            .AsTracking()
                                                                            .OrderBy(x => x.Id)
                                                                            .Skip(traite)
                                                                            .Take(offset)
                                                                            .ToList();

                foreach (MarqueReferenceLibre marqueReferenceLibre in marqueReferenceLibres)
                {
                    marqueReferenceLibre.TexteTransLitLowerFr = null;
                    if (!string.IsNullOrEmpty(marqueReferenceLibre.Texte))
                    {
                        marqueReferenceLibre.TexteTransLitLowerFr = StringsHelpers.HtmlToPlainText(marqueReferenceLibre.Texte).Transliterate().ToLower();
                    }
                }
                DbContext.SaveBaseEntityChangesAsync(withTrigger: false).GetAwaiter().GetResult();
                traite = traite + offset;
            } while (marqueReferenceLibres.Any());
        }

        public void RepriseDeDonneesInitiales()
        {
            List<Marque> marques = DbContext.Marques.AsTracking().ToList();
            foreach (Marque item in marques)
            {
                item.DateMaj = DateTime.Now;
            }
            DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
        }

        public void RepriseDeDonneesInitialesMarquesTransliteration()
        {
            List<Marque> marques = new();
            int traite = 0;
            int offset = 100;
            do
            {
                marques = DbContext.Marques.Where(x => !string.IsNullOrWhiteSpace(x.Initiales))
                                            .OrderBy(x => x.Id)
                                            .Skip(traite)
                                            .Take(offset)
                                            .AsTracking()
                                            .ToList();

                foreach (Marque marque in marques)
                {
                    marque.InitialesTransLitLowerFr = null;

                    if (!string.IsNullOrEmpty(marque.Initiales))
                    {
                        marque.InitialesTransLitLowerFr = StringsHelpers.HtmlToPlainText(marque.Initiales).Transliterate().ToLower();
                    }

                }
                DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
                traite = traite + offset;
            } while (marques.Any());
        }

        private void RepriseDeDonneesReference()
        {
            List<Reference> references = DbContext.References.Where(x => string.IsNullOrWhiteSpace(x.LibelleTransLitLowerFr) || string.IsNullOrWhiteSpace(x.LibelleTransLitLower2))
                                                                            .AsTracking()
                                                                            .ToList();
            int compteur = 0;

            foreach (Reference reference in references)
            {
                compteur++;
                reference.LibelleTransLitLowerFr = null;
                reference.LibelleTransLitLower2 = null;

                if (!string.IsNullOrEmpty(reference.LibelleFr))
                {
                    reference.LibelleTransLitLowerFr = StringsHelpers.HtmlToPlainText(reference.LibelleFr).Transliterate();
                }
                if (!string.IsNullOrEmpty(reference.Libelle2))
                {
                    reference.LibelleTransLitLower2 = StringsHelpers.HtmlToPlainText(reference.Libelle2).Transliterate();
                }

                if (compteur == 100)
                {
                    compteur = 0;
                    DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
                }
            }
            DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
        }

        private void RepriseDeDonneesSousReference()
        {
            List<SousReference> sousReferences = DbContext.SousReferences.Where(x => string.IsNullOrWhiteSpace(x.LibelleTransLitLowerFr) || string.IsNullOrWhiteSpace(x.LibelleTransLitLower2))
                                                                            .AsTracking()
                                                                            .ToList();
            int compteur = 0;

            foreach (SousReference sousReference in sousReferences)
            {
                compteur++;

                sousReference.LibelleTransLitLowerFr = null;
                sousReference.LibelleTransLitLower2 = null;

                if (!string.IsNullOrEmpty(sousReference.LibelleFr))
                {
                    sousReference.LibelleTransLitLowerFr = StringsHelpers.HtmlToPlainText(sousReference.LibelleFr).Transliterate();
                }
                if (!string.IsNullOrEmpty(sousReference.Libelle2))
                {
                    sousReference.LibelleTransLitLower2 = StringsHelpers.HtmlToPlainText(sousReference.Libelle2).Transliterate();
                }

                if (compteur == 100)
                {
                    compteur = 0;
                    DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
                }
            }
            DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
        }

        public void RepriseDeDonneesReferenceLugtLightEtNoticesTextesBruts()
        {
            RepriseDeDonneesReferencesLugtLight();
            RepriseDeDonneesNoticesTextesBruts();
        }

        private void RepriseDeDonneesReferencesLugtLight()
        {
            List<Marque> marques = DbContext.Marques.Where(x => x.IsFinalize)
                                                    .Where(x => string.IsNullOrWhiteSpace(x.ReferenceLugtLight))
                                                    .AsTracking()
                                                    .ToList();
            int compteur = 0;

            foreach (Marque marque in marques)
            {
                compteur++;
                string referenceLugt = marque.ReferenceLugt.Remove(0, 2);
                referenceLugt = referenceLugt.Trim();
                marque.ReferenceLugtLight = $"L.{referenceLugt.TrimStart('0')}";

                if (compteur == 100)
                {
                    compteur = 0;
                    DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
                }
            }
            DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
        }

        private void RepriseDeDonneesNoticesTextesBruts()
        {
            List<MarqueNotice> notices = DbContext.MarqueNotices.Where(x => !string.IsNullOrWhiteSpace(x.Texte))
                                                                .AsTracking()
                                                                .ToList();
            int compteur = 0;

            foreach (MarqueNotice notice in notices)
            {
                compteur++;
                notice.TexteBrut = StringsHelpers.HtmlToPlainText(notice.Texte).Transliterate();

                if (compteur == 100)
                {
                    compteur = 0;
                    DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
                }
            }
            DbContext.SaveBaseEntityChangesAsync().GetAwaiter().GetResult();
        }
    }
}
