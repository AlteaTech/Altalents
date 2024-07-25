using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.Business.Services
{
    public class DossierTechniqueService : BaseAppService<CustomDbContext>, IDossierTechniqueService
    {
        public DossierTechniqueService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider) : base(logger, contexte, mapper, serviceProvider)
        {
        }

        public async Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            await CheckNouveauCandidat(dossierTechnique, cancellationToken);
            DossierTechnique dt = Mapper.Map<DossierTechnique>(dossierTechnique);
            dt.Personne.Contacts.RemoveAll(x => string.IsNullOrWhiteSpace(x.Valeur));
            await DbContext.DossierTechniques.AddAsync(dt, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return dt.Id;

        }

        private async Task CheckNouveauCandidat(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            List<string> messagesErreur = new();
            Task<bool> taskCheckMail = GetScopedDbContexte().DossierTechniques.AnyAsync(x => x.Personne.Email == dossierTechnique.AdresseMail, cancellationToken);
            Task<bool> taskCheckIdBoond = GetScopedDbContexte().DossierTechniques.AnyAsync(x => x.Personne.BoondId == dossierTechnique.IdBoond, cancellationToken);
            Task<bool> taskCheckTrigramme = GetScopedDbContexte().DossierTechniques.AnyAsync(x => x.Personne.Trigramme == dossierTechnique.Trigramme, cancellationToken);
            if (await taskCheckMail)
            {
                messagesErreur.Add($"Adresse mail ({dossierTechnique.AdresseMail})");
            }

            if (await taskCheckIdBoond)
            {
                messagesErreur.Add($"BoondId ({dossierTechnique.IdBoond})");
            }

            if (await taskCheckTrigramme)
            {
                messagesErreur.Add($"Trigramme ({dossierTechnique.Trigramme})");
            }

            if (messagesErreur.Any())
            {
                throw new BusinessException($"Un Candidat avec les données suivantes existe deja : {string.Join(", ", messagesErreur)}");
            }
        }

        public async Task ChangerStatutDossierTechniqueAsync(Guid id, Guid statutId, CancellationToken cancellationToken)
        {
            DossierTechnique dt = await DbContext.DossierTechniques.AsTracking().SingleAsync(x => x.Id == id, cancellationToken);
            bool statutExist = await DbContext.References.AnyAsync(x => x.Id == statutId && x.Type == TypeReferenceEnum.StatutDt, cancellationToken);
            if (!statutExist)
            {
                throw new BusinessException("Statut inexistant");
            }
            dt.StatutId = statutId;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques()
        {
            return DbContext.DossierTechniques
                                         .ProjectTo<DossierTechniqueDto>(Mapper.ConfigurationProvider);
        }

        public IQueryable<DossierTechniqueEnCoursDto> GetDtsEnCours(EtatFiltreDtEnum etat)
        {
            if (etat == EtatFiltreDtEnum.InProgress)
            {
                return DbContext.DossierTechniques
                    .Where(x => x.Statut.Type == TypeReferenceEnum.StatutDt)
                    .Where(x => x.Statut.Code == CodeReferenceEnum.EnCours.ToString("g") || x.Statut.Code == CodeReferenceEnum.Inactif.ToString("g") || x.Statut.Code == CodeReferenceEnum.Cree.ToString("g"))
                                             .ProjectTo<DossierTechniqueEnCoursDto>(Mapper.ConfigurationProvider);
            }

            return DbContext.DossierTechniques
                    .Where(x => x.Statut.Type == TypeReferenceEnum.StatutDt)
                    .Where(x => x.Statut.Code == CodeReferenceEnum.AModifier.ToString("g") || x.Statut.Code == CodeReferenceEnum.NonValide.ToString("g") || x.Statut.Code == CodeReferenceEnum.Valide.ToString("g"))
                                         .ProjectTo<DossierTechniqueEnCoursDto>(Mapper.ConfigurationProvider);
        }

        public async Task<TrigrammeDto> GetTrigrammeAsync(GetTrigrammeRequestDto request, CancellationToken cancellationToken)
        {
            string baseTtrigramme = $"{request.Prenom[0]}{request.Nom[0..2]}".ToUpper();
            TrigrammeDto retour = new TrigrammeDto
            {
                Valeur = baseTtrigramme
            };
            int i = 1;

            while (await DbContext.Personnes.AnyAsync(x => x.Trigramme == retour.Valeur.ToLower(), cancellationToken) ||
                await DbContext.TrigrammeLocks.AnyAsync(x => x.Trigramme == retour.Valeur.ToLower(), cancellationToken)
                )
            {
                retour.Valeur = baseTtrigramme + i;
                i++;
            }

            await DbContext.TrigrammeLocks.AddAsync(new()
            {
                Trigramme = retour.Valeur.ToLower(),
                DateLock = DateTime.UtcNow,
            }, cancellationToken);

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return retour;
        }

        public async Task<bool> IsEmailValidAsync(string email, CancellationToken cancellationToken)
        {
            string trimmedEmail = email.Trim().ToLower();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address.ToLower() != trimmedEmail)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            if (await DbContext.Personnes.AnyAsync(x => x.Email == trimmedEmail, cancellationToken: cancellationToken))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsIdBoondValidAsync(string idboond, CancellationToken cancellationToken)
        {
            return !await DbContext.Personnes.AnyAsync(x => x.BoondId == idboond, cancellationToken: cancellationToken);
        }

        public async Task<bool> IsTrigrammeValidAsync(string trigram, CancellationToken cancellationToken)
        {
            return !await DbContext.Personnes.AnyAsync(x => x.Trigramme == trigram.ToLower(), cancellationToken);
        }

        public bool IsTelephoneValid(string telephone)
        {
            telephone = telephone.Trim();
            if (telephone.Length > 50)
                return false;
            telephone = telephone.Replace(" ", "");
            string motif1 = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            string motif2 = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";

            if (telephone != null && (Regex.IsMatch(telephone, motif1) || Regex.IsMatch(telephone, motif2)))
                return true;
            else
                return false;
        }
    }
}
