using System.Collections;
using Altalents.Business.Extensions;
using Altalents.Commun.Enums;
using Altalents.Commun.Settings;
using Altalents.IBusiness.DTO.Request;
using Altalents.Report.Library;
using Altalents.Report.Library.DSO;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;

using Telerik.Reporting;
using Telerik.Reporting.Processing;

namespace Altalents.Business.Services
{
    public class DossierTechniqueService : BaseAppService<CustomDbContext>, IDossierTechniqueService
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IEmailService _emailService;
        private readonly CommercialSettings _commercialSettings;

        public DossierTechniqueService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider,
            IOptionsMonitor<GlobalSettings> globalSettings, IEmailService emailService, IOptions<CommercialSettings> commercialSettings, ICompetencesService competenceService) : base(logger, contexte, mapper, serviceProvider)
        {
            _globalSettings = globalSettings.CurrentValue;
            _emailService = emailService;
            _commercialSettings = commercialSettings.Value;
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
            foreach (DocumentDto item in documents)
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
            using CustomDbContext context = GetScopedDbContexte();

            List<string> messagesErreur = new();
            bool checkTelephone = IsTelephoneValid(dossierTechnique.Telephone, true);
            Task<bool> taskCheckMail = IsEmailValidAsync(dossierTechnique.AdresseMail, null, cancellationToken);
            Task<bool> taskCheckIdBoond = IsIdBoondValidAsync(dossierTechnique.IdBoond, cancellationToken);
            Task<bool> taskCheckTrigramme = context.DossierTechniques.AnyAsync(x => x.Personne.Trigramme == dossierTechnique.Trigramme, cancellationToken);

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

        private async Task<Guid> GetDOssierTechniqueIdFromTokenAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await DbContext.DossierTechniques
                .Where(dt => dt.TokenAccesRapide == tokenAccesRapide)
                .Select(dt => dt.Id).FirstOrDefaultAsync(cancellationToken);
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

            using CustomDbContext context = GetScopedDbContexte();

            if (!tokenRapide.HasValue)
            {
                if (await context.Personnes.AnyAsync(x => x.Email == trimmedEmail, cancellationToken: cancellationToken))
                {
                    return false;
                }
            }
            else
            {
                if (await context.Personnes.AnyAsync(x => !x.DossierTechniques.Any(y => y.TokenAccesRapide == tokenRapide) && x.Email == trimmedEmail, cancellationToken: cancellationToken))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsIdBoondValidAsync(string idboond, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            return !await context.Personnes.AnyAsync(x => x.BoondId == idboond, cancellationToken: cancellationToken);
        }

        public async Task<bool> IsTrigrammeValidAsync(string trigram, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            return !await context.Personnes.AnyAsync(x => x.Trigramme == trigram.ToLower(), cancellationToken);
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

            using CustomDbContext context = GetScopedDbContexte();
            DossierTechnique dt = await GetQueryParlonsDeVous(context, tokenRapide).SingleAsync(cancellationToken);

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
            using CustomDbContext context = GetScopedDbContexte();

            return context.QuestionDossierTechniques
                .Where(x => x.DossierTechnique.TokenAccesRapide == tokenRapide)
                .OrderBy(x => x.Ordre)
                .ProjectTo<QuestionnaireDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task SetReponseQuestionnairesAsync(List<QuestionnaireUpdateDto> questionnaires, CancellationToken cancellationToken)
        {
            List<Guid> idsQuestionnaires = questionnaires.Select(x => x.Id).ToList();
            using CustomDbContext context = GetScopedDbContexte();
            List<QuestionDossierTechnique> questionReponses = await context.QuestionDossierTechniques
                .Where(x => idsQuestionnaires.Contains(x.Id))
                .AsTracking()
                .ToListAsync(cancellationToken);

            questionReponses.ForEach(question =>
            {
                question.Reponse = questionnaires.Single(x => x.Id == question.Id).Reponse;
            });

            await context.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task PutExperiencesAsync(Guid tokenAccesRapide, PutExperiencesRequestDto request, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            DossierTechnique dt = await context.DossierTechniques
                .Include(x => x.Experiences)
                .AsTracking()
                .SingleAsync(x => x.TokenAccesRapide == tokenAccesRapide, cancellationToken);

            context.Experiences.RemoveRange(dt.Experiences);
            dt.Experiences = Mapper.Map<List<Entities.Experience>>(request.Experiences);

            await context.SaveBaseEntityChangesAsync(cancellationToken);
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
            using CustomDbContext context = GetScopedDbContexte();
            return context.DossierTechniques.Where(x => x.TokenAccesRapide == tokenAccesRapide)
                .SelectMany(x => x.DocumentComplementaires.Select(d => new DocumentDto()
                {
                    Commentaire = d.Commentaire,
                    Data = d.Data,
                    MimeType = d.MimeType,
                    NomFichier = d.Nom
                }))
                .ToListAsync(cancellationToken);
        }

        public async Task<DocumentDto> GenerateDossierCompetenceFileAsync(Guid tokenAccesRapide, TypeExportEnum typeExportEnum, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            DossierCompetenceDso dt = await context.DossierTechniques.Where(x => x.TokenAccesRapide == tokenAccesRapide)
                .ProjectTo<DossierCompetenceDso>(Mapper.ConfigurationProvider)
                .FirstAsync(cancellationToken);

            ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            // set any deviceInfo settings if necessary
            Hashtable deviceInfo = new System.Collections.Hashtable();

            DossierCompetance rpt = new DossierCompetance();

            dt.Commercial = new()
            {
                Mail = _commercialSettings.Mail,
                Telephone = _commercialSettings.Telephone,
                Name = _commercialSettings.Nom,
                WebSite = _commercialSettings.SiteWeb
            };
            rpt.dossierCompetanceDataSource.DataSource = dt;
            rpt.experienceDataSource.DataSource = dt.Experiences;

            InstanceReportSource reportSource = new InstanceReportSource
            {
                ReportDocument = rpt
            };

            string formatDocument = "PDF";
            string mimeType = "application/pdf";
            if (typeExportEnum == TypeExportEnum.RTF)
            {
                formatDocument = "RTF";
                mimeType = "application/rtf";
            }

            RenderingResult result = reportProcessor.RenderReport(formatDocument, reportSource, deviceInfo);

            if (!result.HasErrors)
            {
                string fileName = result.DocumentName + "." + result.Extension;

                return new DocumentDto()
                {
                    MimeType = mimeType,
                    NomFichier = fileName,
                    Data = result.DocumentBytes
                };
            }
            else
            {
                throw new Exception(result.Errors.ToString());
            }
        }

        public async Task<AllAboutFormationsDto> GetAllAboutFormationAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            //Ces 3 context son necessaire pour pouvoir paralleliser les appels
            using CustomDbContext contextForFormation = GetScopedDbContexte();
            using CustomDbContext contextForcertifion = GetScopedDbContexte();
            using CustomDbContext contextForLangues = GetScopedDbContexte();

            // Lancer les requêtes en parallèle
            Task<List<FormationCertificationDto>> formationsTask = contextForFormation.Formations
                .Where(x => x.DossierTechnique.TokenAccesRapide == tokenAccesRapide)
                .ProjectTo<FormationCertificationDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            Task<List<FormationCertificationDto>> certificationsTask = contextForcertifion.Certifications
                .Where(x => x.DossierTechnique.TokenAccesRapide == tokenAccesRapide)
                .ProjectTo<FormationCertificationDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            Task<List<LangueParleeDto>> languesParleesTask = contextForLangues.DossierTechniqueLangues
                .Where(x => x.DossierTechnique.TokenAccesRapide == tokenAccesRapide)
                .ProjectTo<LangueParleeDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AllAboutFormationsDto
            {
                Formations = await formationsTask,
                Certifications = await certificationsTask,
                LanguesParlees = await languesParleesTask
            };
        }

        public async Task<Guid> AddOrUpdateFormationCertificationAsync(Guid tokenAccesRapide, FormationCertificationRequestDto request, CancellationToken cancellationToken, Guid? id = null)
        {

            using CustomDbContext context = GetScopedDbContexte();

            FormationCertificationEnum formationCertificationEnum = (FormationCertificationEnum)Enum.Parse(typeof(TypeLiaisonEnum), request.FormationOrCertificationEnumCode);

            switch (formationCertificationEnum)
            {
                case FormationCertificationEnum.Certification:

                    Certification certifToAddOrUpdate;

                    if (id == null)
                    {
                        certifToAddOrUpdate = Mapper.Map<Certification>(request);
                        certifToAddOrUpdate.DossierTechniqueId = await GetDOssierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
                        await context.Certifications.AddAsync(certifToAddOrUpdate, cancellationToken);
                    }
                    else
                    {
                        certifToAddOrUpdate = context.Certifications.AsTracking().FirstOrDefault(x => x.Id == id.Value);

                        //Mappage manuel car le mappeur set A Null les champs qui ne sont pas definit dans la config alors que on veut pas vu que c'est un update
                        certifToAddOrUpdate.Libelle = request.Libelle;
                        certifToAddOrUpdate.Niveau = request.Niveau;
                        certifToAddOrUpdate.DateDebut = request.DateDebut;
                        certifToAddOrUpdate.DateFin = request.DateFin;
                        certifToAddOrUpdate.Domaine = request.Domaine;
                        certifToAddOrUpdate.Organisme = request.Organisme;
                    }

                    await context.SaveBaseEntityChangesAsync();
                    return certifToAddOrUpdate.Id;

                case FormationCertificationEnum.Formation:
                    Formation formationfToAddOrUpdate;

                    if (id == null)
                    {
                        formationfToAddOrUpdate = Mapper.Map<Formation>(request);
                        formationfToAddOrUpdate.DossierTechniqueId = await GetDOssierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
                        await context.Formations.AddAsync(formationfToAddOrUpdate, cancellationToken);
                    }
                    else
                    {
                        formationfToAddOrUpdate = context.Formations.AsTracking().FirstOrDefault(x => x.Id == id.Value);

                        //Mappage manuel car le mappeur set A Null les champs qui ne sont pas definit dans la config alors que on veut pas vu que c'est un update
                        formationfToAddOrUpdate.Libelle = request.Libelle;
                        formationfToAddOrUpdate.Niveau = request.Niveau;
                        formationfToAddOrUpdate.DateDebut = request.DateDebut;
                        formationfToAddOrUpdate.DateFin = request.DateFin;
                        formationfToAddOrUpdate.Domaine = request.Domaine;
                        formationfToAddOrUpdate.Organisme = request.Organisme;
                    }

                    await context.SaveBaseEntityChangesAsync(cancellationToken);
                    return formationfToAddOrUpdate.Id;
                default:
                    throw new BusinessException("FormationOrCertificationEnumCode ne correspond a aucun code valide : les valeur attendu sont : '1' (Formation) ou '2' (Certification ");
            }
        }

        public async Task<Guid> AddOrUpdateLangueParleeAsync(Guid tokenAccesRapide, LangueParleeRequestDto request, CancellationToken cancellationToken, Guid? id = null)
        {
            using CustomDbContext context = GetScopedDbContexte();
            DossierTechniqueLangue dossierTechniqueLangueToAddOrUpdate;

            if (id == null)
            {
                dossierTechniqueLangueToAddOrUpdate = Mapper.Map<DossierTechniqueLangue>(request);
                dossierTechniqueLangueToAddOrUpdate.DossierTechniqueId = await GetDOssierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
                await context.DossierTechniqueLangues.AddAsync(dossierTechniqueLangueToAddOrUpdate, cancellationToken);
            }
            else
            {
                dossierTechniqueLangueToAddOrUpdate = context.DossierTechniqueLangues.AsTracking().FirstOrDefault(x => x.Id == id.Value);

                //Mappage manuel car le mappeur set A Null les champs qui ne sont pas definit dans la config alors que on veut pas vu que c'est un update
                dossierTechniqueLangueToAddOrUpdate.LangueId = request.LangueId;
                dossierTechniqueLangueToAddOrUpdate.Niveau = request.Niveau;
            }

            await context.SaveBaseEntityChangesAsync(cancellationToken);

            return dossierTechniqueLangueToAddOrUpdate.Id;
        }

        public async Task<RecapitulatifDtDto> GetRecapitulatifDtAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {

            using CustomDbContext context = GetScopedDbContexte();

            // Lancer la récupération de dossierTechnique en parallèle avec les autres appels
            Task<DossierTechnique> dossierTechniqueTask = context.DossierTechniques
                .Where(dt => dt.TokenAccesRapide == tokenAccesRapide)
                .Include(dt => dt.Experiences)
                    .ThenInclude(exp => exp.LiaisonExperienceCompetences)
                        .ThenInclude(ec => ec.Competance)
                .Include(dt => dt.Formations)
                .Include(dt => dt.Certifications)
                .Include(dt => dt.DossierTechniqueLangues).ThenInclude(dtl => dtl.Langue)
                .Include(dt => dt.DocumentComplementaires)
                .Include(dt => dt.QuestionDossierTechniques)
                .SingleOrDefaultAsync(cancellationToken);

            using CustomDbContext context1 = GetScopedDbContexte();
            using CustomDbContext context2 = GetScopedDbContexte();
            using CustomDbContext context3 = GetScopedDbContexte();
            using CustomDbContext context4 = GetScopedDbContexte();

            Task<List<CompetenceDto>> competencesTask = context1.GetLiaisonCandidatByTypeAsync(Mapper, tokenAccesRapide, TypeLiaisonEnum.Competence.GetHashCode().ToString(), cancellationToken);
            Task<List<CompetenceDto>> methodologiesTask = context2.GetLiaisonCandidatByTypeAsync(Mapper, tokenAccesRapide, TypeLiaisonEnum.Methodologie.GetHashCode().ToString(), cancellationToken);
            Task<List<CompetenceDto>> technologieTask = context3.GetLiaisonCandidatByTypeAsync(Mapper, tokenAccesRapide, TypeLiaisonEnum.Technologie.GetHashCode().ToString(), cancellationToken);
            Task<List<CompetenceDto>> outilsTask = context4.GetLiaisonCandidatByTypeAsync(Mapper, tokenAccesRapide, TypeLiaisonEnum.Outil.GetHashCode().ToString(), cancellationToken);

            DossierTechnique dossierTechnique = await dossierTechniqueTask;

            if (dossierTechnique == null)
                throw new BusinessException("Dossier technique inexistant");

            RecapitulatifDtDto recapitulatif = new ()
            {
                Competences = new ()
                {
                    Competences = await competencesTask,
                    Methodologies = await methodologiesTask,
                    Technologie = await technologieTask,
                    Outils = await outilsTask
                },
                Formations = Mapper.Map<List<FormationCertificationDto>>(dossierTechnique.Formations),
                Certifications = Mapper.Map<List<FormationCertificationDto>>(dossierTechnique.Certifications),
                Langues = Mapper.Map<List<LangueParleeDto>>(dossierTechnique.DossierTechniqueLangues),
                Questionnaires = Mapper.Map<List<QuestionnaireDto>>(dossierTechnique.QuestionDossierTechniques),
                Experiences = Mapper.Map<List<ExperienceDto>>(dossierTechnique.Experiences)
            };

            return recapitulatif;
        }
    }
}
