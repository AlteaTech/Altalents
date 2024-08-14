using Altalents.Commun.Enums;
using Altalents.Commun.Settings;
using Altalents.IBusiness.DTO.Requesst;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;

namespace Altalents.Business.Services
{
    public class DossierTechniqueService : BaseAppService<CustomDbContext>, IDossierTechniqueService
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IEmailService _emailService;
        public DossierTechniqueService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider,
            IOptionsMonitor<GlobalSettings> globalSettings, IEmailService emailService) : base(logger, contexte, mapper, serviceProvider)
        {
            _globalSettings = globalSettings.CurrentValue;
            _emailService = emailService;
        }

        public async Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            await CheckNouveauCandidat(dossierTechnique, cancellationToken);
            DossierTechnique dt = Mapper.Map<DossierTechnique>(dossierTechnique);
            dt.Personne.Contacts.RemoveAll(x => string.IsNullOrWhiteSpace(x.Valeur));
            dt.QuestionDossierTechniques = Mapper.Map<List<QuestionDossierTechnique>>(dossierTechnique.Questionnaires);
            if (dossierTechnique.Documents != null && dossierTechnique.Documents.Any())
            {
                dt.DocumentComplementaires = GetDocumentComplementaires(dossierTechnique.Documents);
            }
            await DbContext.DossierTechniques.AddAsync(dt, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            await _emailService.SendEmailWithRetryAsync(dossierTechnique.AdresseMail, "Demande de creation de dossier technique", $"Merci de remplir le dossier suivant : <a href=\"{_globalSettings.BaseUrl}/accueil/{dt.TokenAccesRapide}\"> ce dossier là </a>");
            return dt.Id;

        }

        public List<DocumentComplementaire> GetDocumentComplementaires(List<DocumentDto> documents)
        {
            List<DocumentComplementaire> retour = new();
            foreach (var item in documents)
            {
                retour.Add(new()
                {
                    Commentaire = item.Commentaire,
                    MimeType = item.MimeType,
                    Nom = item.NomFichier,
                    Data = item.Data
                });
            }
            return retour;
        }

        private async Task CheckNouveauCandidat(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            List<string> messagesErreur = new();
            bool checkTelephone = IsTelephoneValid(dossierTechnique.Telephone, true);
            Task<bool> taskCheckMail = IsEmailValidAsync(dossierTechnique.AdresseMail, null, cancellationToken);
            Task<bool> taskCheckIdBoond = IsIdBoondValidAsync(dossierTechnique.IdBoond, cancellationToken);
            Task<bool> taskCheckTrigramme = GetScopedDbContexte().DossierTechniques.AnyAsync(x => x.Personne.Trigramme == dossierTechnique.Trigramme, cancellationToken);

            if (!await taskCheckMail)
            {
                messagesErreur.Add($"Adresse mail ({dossierTechnique.AdresseMail})");
            }
            if (!await taskCheckIdBoond)
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
            if (!checkTelephone)
            {
                throw new BusinessException($"Le telephone ({dossierTechnique.Telephone}) est invalide.");
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

        public async Task<NomPrenomPersonneDto> GetNomPrenomFromTokenAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await DbContext.DossierTechniques
                .Where(dt => dt.TokenAccesRapide == tokenAccesRapide)
                .Select(dt => new NomPrenomPersonneDto
                {
                    Nom = dt.Personne.Nom,
                    Prenom = dt.Personne.Prenom
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new BusinessException("DossierTechnique inexistant.");
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

        public async Task<bool> IsEmailValidAsync(string email, Guid? tokenRapide, CancellationToken cancellationToken)
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

            if (!tokenRapide.HasValue)
            {
                if (await GetScopedDbContexte().Personnes.AnyAsync(x => x.Email == trimmedEmail, cancellationToken: cancellationToken))
                {
                    return false;
                }
            }
            else
            {
                if (await GetScopedDbContexte().Personnes.AnyAsync(x => !x.DossierTechniques.Any(y => y.TokenAccesRapide == tokenRapide) && x.Email == trimmedEmail, cancellationToken: cancellationToken))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsIdBoondValidAsync(string idboond, CancellationToken cancellationToken)
        {
            return !await GetScopedDbContexte().Personnes.AnyAsync(x => x.BoondId == idboond, cancellationToken: cancellationToken);
        }

        public async Task<bool> IsTrigrammeValidAsync(string trigram, CancellationToken cancellationToken)
        {
            return !await DbContext.Personnes.AnyAsync(x => x.Trigramme == trigram.ToLower(), cancellationToken);
        }

        public bool IsTelephoneValid(string telephone, bool isOptionnal = false)
        {
            if (isOptionnal && telephone == null)
            {
                return true;
            }
            else if (telephone == null)
            {
                return false;
            }
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

        public async Task<ParlonsDeVousDto> GetParlonsDeVousAsync(Guid tokenRapide, CancellationToken cancellationToken)
        {
            DossierTechnique dt = await GetQueryParlonsDeVous(GetScopedDbContexte(), tokenRapide).SingleAsync(cancellationToken);

            AdresseDto adresseDto = dt.Personne.Adresses?.Select(x => new AdresseDto()
            {
                Adresse1 = x.Adresse1,
                Adresse2 = x.Adresse2,
                CodePostal = x.CodePostal,
                Pays = x.Pays,
                Ville = x.Ville
            })
            .FirstOrDefault();

            List<Contact> contactTelephones = dt.Personne.Contacts.Where(x => x.TypeId == Guid.Parse(IdsConstantes.ContactTelephoneId)).ToList();

            ParlonsDeVousDto reponse = new ParlonsDeVousDto()
            {
                Adresse = adresseDto,
                Telephone1 = contactTelephones.FirstOrDefault()?.Valeur,
                Telephone2 = contactTelephones.Count <= 1 ? null : contactTelephones.LastOrDefault()?.Valeur,
                Email = dt.Personne.Email,
                Nom = dt.Personne.Nom,
                Prenom = dt.Personne.Prenom
            };
            return reponse;
        }

        private IIncludableQueryable<DossierTechnique, List<Contact>> GetQueryParlonsDeVous(CustomDbContext context, Guid tokenRapide)
        {
            return context.DossierTechniques
                            .Where(x => x.TokenAccesRapide == tokenRapide)
                            .Include(x => x.Personne)
                                .ThenInclude(x => x.Adresses)
                            .Include(x => x.Personne)
                                .ThenInclude(x => x.Contacts);
        }

        public async Task PutParlonsDeVousAsync(Guid tokenRapide, ParlonsDeVousUpdateRequestDto request, CancellationToken cancellationToken)
        {
            DossierTechnique dt = await GetQueryParlonsDeVous(DbContext, tokenRapide)
                .AsTracking()
                .SingleAsync(cancellationToken);

            Adresse adresse = dt.Personne.Adresses?.FirstOrDefault();
            if (adresse != null)
            {
                adresse.Pays = request.Adresse.Pays;
                adresse.Adresse1 = request.Adresse.Adresse1;
                adresse.Adresse2 = request.Adresse.Adresse2;
                adresse.CodePostal = request.Adresse.CodePostal;
                adresse.Ville = request.Adresse.Ville;
            }
            else
            {
                dt.Personne.Adresses = new()
                {
                    new()
                    {
                        Pays = request.Adresse.Pays,
                        Adresse1 = request.Adresse.Adresse1,
                        Adresse2 = request.Adresse.Adresse2,
                        CodePostal= request.Adresse.CodePostal,
                        Ville = request.Adresse.Ville
                    }
                };
            }
            dt.Personne.Nom = request.Nom;
            dt.Personne.Prenom = request.Prenom;
            dt.Personne.Email = request.Email;

            List<Contact> contactTelephones = dt.Personne.Contacts.Where(x => x.TypeId == Guid.Parse(IdsConstantes.ContactTelephoneId)).ToList();
            Contact tel1 = contactTelephones.FirstOrDefault();
            if (tel1 != null)
            {
                tel1.Valeur = request.Telephone1;
            }
            else
            {
                dt.Personne.Contacts.Add(new Contact()
                {
                    Valeur = request.Telephone1,
                    TypeId = Guid.Parse(IdsConstantes.ContactTelephoneId)
                });
                if (!string.IsNullOrEmpty(request.Telephone2))
                {
                    dt.Personne.Contacts.Add(new Contact()
                    {
                        Valeur = request.Telephone2,
                        TypeId = Guid.Parse(IdsConstantes.ContactTelephoneId)
                    });
                }
            }
            if (contactTelephones.Count <= 1 && !string.IsNullOrEmpty(request.Telephone2))
            {
                dt.Personne.Contacts.Add(new Contact()
                {
                    Valeur = request.Telephone2,
                    TypeId = Guid.Parse(IdsConstantes.ContactTelephoneId)
                });
            }
            else if (contactTelephones.Count > 1)
            {
                dt.Personne.Contacts[1].Valeur = request.Telephone2;
            }

            dt.StatutId = Guid.Parse(IdsConstantes.StatutDtEnCoursId);

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);

        }

        public Task<List<QuestionnaireDto>> GetQuestionnairesAsync(Guid tokenRapide, CancellationToken cancellationToken)
        {
            return GetScopedDbContexte().QuestionDossierTechniques
                .Where(x => x.DossierTechnique.TokenAccesRapide == tokenRapide)
                .OrderBy(x => x.Ordre)
                .ProjectTo<QuestionnaireDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task SetReponseQuestionnairesAsync(List<QuestionnaireUpdateDto> questionnaires, CancellationToken cancellationToken)
        {
            List<Guid> idsQuestionnaires = questionnaires.Select(x => x.Id).ToList();
            CustomDbContext contexte = GetScopedDbContexte();
            List<QuestionDossierTechnique> questionReponses = await contexte.QuestionDossierTechniques
                .Where(x => idsQuestionnaires.Contains(x.Id))
                .AsTracking()
                .ToListAsync(cancellationToken);

            questionReponses.ForEach(question =>
            {
                question.Reponse = questionnaires.Single(x => x.Id == question.Id).Reponse;
            });

            await contexte.SaveBaseEntityChangesAsync();
        }

        public async Task PutExperiencesAsync(Guid tokenAccesRapide, PutExperiencesRequestDto request, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            DossierTechnique dt = await context.DossierTechniques
                .Include(x => x.Experiences)
                .AsTracking()
                .SingleAsync(x => x.TokenAccesRapide == tokenAccesRapide, cancellationToken);

            context.Experiences.RemoveRange(dt.Experiences);
            dt.Experiences = Mapper.Map<List<Experience>>(request.Experiences);

            await context.SaveBaseEntityChangesAsync();
        }

        public async Task<List<ExperienceDto>> GetExperiencesAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            return await context.Experiences.Where(x => x.DossierTechnique.TokenAccesRapide == tokenAccesRapide)
                .ProjectTo<ExperienceDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        [Obsolete("Methode de test")]
        public Task<List<DocumentDto>> GetDocumentsAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return GetScopedDbContexte().DossierTechniques.Where(x => x.TokenAccesRapide == tokenAccesRapide)
                .SelectMany(x => x.DocumentComplementaires.Select(d => new DocumentDto()
                {
                    Commentaire = d.Commentaire,
                    Data = d.Data,
                    MimeType = d.MimeType,
                    NomFichier = d.Nom
                }))
                .ToListAsync(cancellationToken);
        }
    }
}
