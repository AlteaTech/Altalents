using Altalents.Commun.Enums;
using Altalents.Commun.Helpers;
using Altalents.Commun.Settings;
using Altalents.IBusiness.DTO.Request;

using AlteaTools.Api.Core.Extensions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;



namespace Altalents.Business.Services
{
    public class DossierTechniqueService : BaseAppService<CustomDbContext>, IDossierTechniqueService
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IEmailService _emailService;
        private readonly CommercialSettings _commercialSettings;
        private readonly EmailSettings _emailSettings;

        public DossierTechniqueService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider,
            IOptionsMonitor<GlobalSettings> globalSettings, IEmailService emailService, IOptions<CommercialSettings> commercialSettings, IOptions<EmailSettings> emailSettings) : base(logger, contexte, mapper, serviceProvider)
        {
            _globalSettings = globalSettings.CurrentValue;
            _emailService = emailService;
            _commercialSettings = commercialSettings.Value;
            _emailSettings = emailSettings.Value;
        }

        public async Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            await CheckNouveauCandidat(dossierTechnique, cancellationToken);
            DossierTechnique dt = Mapper.Map<DossierTechnique>(dossierTechnique);

            dt.StatutId = Guid.Parse(IdsConstantes.StatutDtCreeId);
            dt.DateCrea = DateTime.Now;
            dt.DateMaj = DateTime.Now;
            dt.Personne.Contacts.RemoveAll(x => string.IsNullOrWhiteSpace(x.Valeur));
            dt.QuestionDossierTechniques = Mapper.Map<List<QuestionDossierTechnique>>(dossierTechnique.Questionnaires);

            if (dossierTechnique.Documents != null && dossierTechnique.Documents.Any())
            {
                dt.DocumentComplementaires = GetDocumentComplementairesFromDtos(dossierTechnique.Documents);
            }

            await DbContext.DossierTechniques.AddAsync(dt, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);

            //On envoi en async volontairement pour de raison de perf (Pas besoin d'attendre un envoi de mail)
            EnvoiEmailCreationDtCandidatAsync(dossierTechnique.AdresseMail, dt.TokenAccesRapide, dt.Personne.Prenom + " " + dt.Personne.Nom);

            return dt.Id;
        }


        public async Task SetLastValidatedEtape(Guid tokenAccesRapide, int numEtapeValidated, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            DossierTechnique dt = await context.DossierTechniques.AsTracking().SingleAsync(x => x.TokenAccesRapide == tokenAccesRapide);

            if (dt == null)
                throw new BusinessException("Impossible de setter une etape à 'Validé' si aucun DT ne correspond au tokenAccesRapide");

            if (dt.NumLastEtapValidated < numEtapeValidated)
            {
                dt.NumLastEtapValidated = numEtapeValidated;
                await context.SaveBaseEntityChangesAsync(cancellationToken);
            }

        }

        public async Task ValidationDtCompletByCandidatAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            DossierTechnique dt = await context.DossierTechniques.Include(x => x.Personne).AsTracking().SingleAsync(x => x.TokenAccesRapide == tokenAccesRapide);

            if (dt.StatutId == Guid.Parse(IdsConstantes.StatutDtCreeId))
            {
                //On envoi en async volontairement pour de raison de perf (Pas besoin d'attendre un envoi de mail)
                EnvoiEmailDtCandidatCompletAsync(tokenAccesRapide, dt.Personne.Prenom + " " + dt.Personne.Nom);
                EnvoiEmailConfirmationReceptionDtCandidatAsync(dt.Personne.Email, dt.Personne.Prenom + " " + dt.Personne.Nom);

                dt.StatutId = Guid.Parse(IdsConstantes.StatutDtAValiderId);
                dt.DateMaj = DateTime.Now;
                await context.SaveBaseEntityChangesAsync(cancellationToken);
            }

        }

        public async Task TestEnvoiEmailValidationDtByCandidatAuServiceComAsync(Guid tokenAccesRapide, string fullNameCandidat, CancellationToken cancellationToken)
        {
            await EnvoiEmailDtCandidatCompletAsync(tokenAccesRapide, fullNameCandidat);
        }

        public async Task TestEnvoiEmailValidationDtByCandidatAuCandidatAsync(string emailCandidat, string fullNameCandidat, CancellationToken cancellationToken)
        {
            await EnvoiEmailConfirmationReceptionDtCandidatAsync(emailCandidat, fullNameCandidat);
        }

        public async Task TestEnvoiEmailCreationDtAuCandidatAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            DossierTechnique dt = await context.DossierTechniques.Include(x => x.Personne).Include(x => x.DocumentComplementaires).AsTracking().SingleAsync(x => x.TokenAccesRapide == tokenAccesRapide);

            await EnvoiEmailCreationDtCandidatAsync(dt.Personne.Email, tokenAccesRapide, dt.Personne.Prenom + " " + dt.Personne.Nom, dt.DocumentComplementaires);
        }

        private async Task EnvoiEmailCreationDtCandidatAsync(string emailTo, Guid tokenAccesRapide, string fullNameCandidat, List<DocumentComplementaire> documentComplementaires = null)
        {
            var documentLinks = "";
            if (documentComplementaires != null && documentComplementaires.Any())
            {
                documentLinks += "<p class='small'>PS : Nos amis du service commercial ont pensé à vous ! Ils ont mis à disposition quelques documents qui pourraient vous être utiles pour remplir votre dossier technique :</p>\r\n";
                documentLinks += "<ul>";
                foreach (var doc in documentComplementaires)
                {
                    var downloadLink = $"{_globalSettings.BaseUrl}/{RoutesNamesConstantes.ApiControllerDossiersTechniques}/{tokenAccesRapide}/{RoutesNamesConstantes.ApiControllerDossierTechnique_MethodeDocument}/{doc.Id}/{RoutesNamesConstantes.ApiControllerDossierTechnique_RouteDownload}";
                    documentLinks += $"<li><a href='{downloadLink}' target='_blank'>{doc.Nom}</a> - <span>{doc.Commentaire}</span></li>";
                }
                documentLinks += "</ul>";
                documentLinks += "<p class='small'>et non, ce ne sont pas des instructions en hiéroglyphes, promis 😄</p>";
            }

            string htmlContent = _emailService.LoadEmailTemplateWithCss(
                FilesNamesConstantes.EmailConfirmationCreationDt_HtmlTemplate_FileNameWithExt,
                FilesNamesConstantes.EmailTemplate_CssStyle_FileNameWithExt,
                new Dictionary<string, string>
                {
            { "baseUrl", _globalSettings.BaseUrl },
            { "link", $"{_globalSettings.BaseUrl}/accueil/{tokenAccesRapide}" },
            { "candidatFullName", fullNameCandidat },
            { "documentLinks", documentLinks } // Ajout des liens ici
                }
            );

            await _emailService.SendEmailWithRetryAsync(
                  emailTo,
                  "Demande de création de dossier technique",
                  htmlContent
              );
        }

        private async Task EnvoiEmailConfirmationReceptionDtCandidatAsync(string emailTo, string fullNameCandidat)
        {
            string htmlContent = _emailService.LoadEmailTemplateWithCss(
                FilesNamesConstantes.EmailConfirmationReceptionDt_HtmlTemplate_FileNameWithExt,
                FilesNamesConstantes.EmailTemplate_CssStyle_FileNameWithExt,
                new Dictionary<string, string>
                {
            { "baseUrl", _globalSettings.BaseUrl },
            { "candidatFullName", fullNameCandidat }
                }
            );

            await _emailService.SendEmailWithRetryAsync(
                emailTo,
                "Votre dossier technique a bien été reçu !",
                htmlContent, false
            );
        }

        private async Task EnvoiEmailDtCandidatCompletAsync(Guid tokenAccesRapide, string fullNameCandidat)
        {
            string htmlContent = _emailService.LoadEmailTemplateWithCss(
                FilesNamesConstantes.EmailConfirmationValidationDt_HtmlTemplate_FileNameWithExt,
                FilesNamesConstantes.EmailTemplate_CssStyle_FileNameWithExt,
                new Dictionary<string, string>
                {
                    { "baseUrl", _globalSettings.BaseUrl },
                    { "candidatFullName", fullNameCandidat },
                    { "downloadLink",$"{_globalSettings.BaseUrl}/{RoutesNamesConstantes.ApiControllerDossiersTechniques}/{tokenAccesRapide}/{RoutesNamesConstantes.ApiControllerDossierTechnique_MethodeDownloadDtWord}"},
                    { "openAdminLink", $"{_globalSettings.BaseUrl}/{RoutesNamesConstantes.MvcAreaAdmin}/{RoutesNamesConstantes.MvcControllerTableauDeBord}" },
                    { "editLink", $"{_globalSettings.BaseUrl}/{RoutesNamesConstantes.AngularApp_DossierTechnique}/{tokenAccesRapide}" }
                }
            );

            await _emailService.SendEmailWithRetryAsync(
                _emailSettings.MailsServiceCommercial,
                $"Alerte : Un candidat ({fullNameCandidat}) a complété son dossier technique",
                htmlContent, false
            );
        }

        public List<DocumentComplementaire> GetDocumentComplementairesFromDtos(List<DocumentDto> documents)
        {
            List<DocumentComplementaire> retour = new();
            foreach (DocumentDto item in documents)
            {
                retour.Add(GetDocumentDto(item));
            }
            return retour;
        }

        private DocumentComplementaire GetDocumentDto(DocumentDto item)
        {
            return new()
            {
                Commentaire = item.Commentaire,
                MimeType = item.MimeType,
                Nom = item.NomFichier,
                Data = item.Data,
                TypeDocument = TypeDocumentEnum.PieceJointeDt
            };
        }


        public async Task<List<DocumentDto>> GetPiecesJointesDtWithoutDataAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            List<DocumentDto> result = await context.DossierTechniques
                .Where(x => x.TokenAccesRapide == tokenAccesRapide)
                .SelectMany(x => x.DocumentComplementaires
                    .Where(w => w.TypeDocument == TypeDocumentEnum.PieceJointeDt)
                    .Select(d => new DocumentDto
                    {
                        Id = d.Id,
                        Commentaire = d.Commentaire,
                        //Data = d.Data,
                        MimeType = d.MimeType,
                        NomFichier = d.Nom
                    }))
                .ToListAsync(cancellationToken);
            return result;
        }

        public async Task<DocumentDto> GetPieceJointeDtWithDataAsync(Guid tokenAccesRapide, Guid documentId, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            DocumentComplementaire docToDl = await context.DocumentComplementaires.Include(x => x.DossierTechnique).Where(x => x.Id == documentId).SingleAsync(cancellationToken);

            if (docToDl == null)
                throw new BusinessException("Dossier technique inexistant");

            if (docToDl.DossierTechnique.TokenAccesRapide != tokenAccesRapide)
                throw new BusinessException("Le token d'acces rapide ne correspond pas");

            DocumentDto toReturn = new DocumentDto()
            {
                Id = docToDl.Id,
                Commentaire = docToDl.Commentaire,
                Data = docToDl.Data,
                MimeType = docToDl.MimeType,
                NomFichier = docToDl.Nom
            };

            return toReturn;
        }

        public async Task<DocumentDto> GetCvDtAsync(Guid tokenRapide, CancellationToken cancellationToken)
        {

            using CustomDbContext context = GetScopedDbContexte();

            Entities.Document cv = await context.DossierTechniques
                            .Where(x => x.TokenAccesRapide == tokenRapide)
                            .Include(x => x.Personne)
                                .ThenInclude(x => x.Documents).Select(e => e.Personne.Documents.FirstOrDefault(e => e.TypeDocument == TypeDocumentEnum.CV)).SingleAsync(cancellationToken);

            if (cv == null)
                return null;

            return new DocumentDto() { Id = cv.Id, MimeType = cv.MimeType, NomFichier = cv.Nom, Data = cv.Data };

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
            dt.DateMaj = DateTime.Now;

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<PrivatesDatasDto> GetPrivateDatasDossierTechniqueAsync(Guid id, CancellationToken cancellationToken)
        {
            DossierTechnique dt = await DbContext.DossierTechniques.Include(x => x.Personne).SingleAsync(x => x.Id == id, cancellationToken);
            if (dt == null)
            {
                throw new BusinessException("DT inexistant");
            }

            PrivatesDatasDto toReturn = new PrivatesDatasDto();

            toReturn.DtId = dt.Id;
            toReturn.TarifJournalier = dt.PrixJour;
            toReturn.Trigramme = dt.Personne.Trigramme;
            toReturn.DisponibiliteId = dt.DisponibiliteId;
            toReturn.Email = dt.Personne.Email;
            toReturn.Poste = dt.Poste;

            return toReturn;
        }




        public async Task UpdatePrivateDatasDossierTechniqueAsync(PrivatesDatasRequestDto privatesDatasRequestDto, CancellationToken cancellationToken)
        {

            DossierTechnique dt = await DbContext.DossierTechniques.Include(x => x.Personne).AsTracking().SingleAsync(x => x.Id == privatesDatasRequestDto.DtId, cancellationToken);
            if (dt == null)
            {
                throw new BusinessException("DT inexistant");
            }

            dt.DisponibiliteId = privatesDatasRequestDto.DisponibiliteId;
            dt.Personne.Trigramme = privatesDatasRequestDto.Trigramme;
            dt.PrixJour = privatesDatasRequestDto.TarifJournalier;
            dt.Personne.Email = privatesDatasRequestDto.Email;
            dt.Poste = privatesDatasRequestDto.Poste;

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

        private async Task<Guid> GetDossierTechniqueIdFromTokenAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await DbContext.DossierTechniques
                .Where(dt => dt.TokenAccesRapide == tokenAccesRapide)
                .Select(dt => dt.Id).FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<DossierTechniqueForAdminDto> GetQueryDtForKendoUi()
        {
            return DbContext.DossierTechniques
                   .ProjectTo<DossierTechniqueForAdminDto>(Mapper.ConfigurationProvider);
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
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string trimmedEmail = email.Trim().ToLower();

            // Vérifie si l'e-mail se termine par un "." ou ne contient pas une extension de domaine valide
            if (trimmedEmail.EndsWith(".") || !Regex.IsMatch(trimmedEmail, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
            {
                return false;
            }

            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                if (!addr.Address.Equals(trimmedEmail, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            using CustomDbContext context = GetScopedDbContexte();

            var query = context.Personnes.AsQueryable();

            if (tokenRapide.HasValue)
            {
                query = query.Where(x => !x.DossierTechniques.Any(y => y.TokenAccesRapide == tokenRapide) && x.Email == trimmedEmail);
            }
            else
            {
                query = query.Where(x => x.Email == trimmedEmail);
            }

            return !await query.AnyAsync(cancellationToken);
        }



        public async Task<PermissionConsultationDtDto> GetPermissionConsultationDtAsync(string tokenRapide, bool isUserLoggedInBackoffice, CancellationToken cancellationToken)
        {

            PermissionConsultationDtDto permissiontDto = new PermissionConsultationDtDto();


            permissiontDto.TokenAccesRapide = tokenRapide;
            permissiontDto.IsUserLoggedInBackOffice = isUserLoggedInBackoffice;
            permissiontDto.IsDtAccessible = false;
            permissiontDto.IsDtReadOnly = false;
            permissiontDto.IsValideGuidFromToken = false;

            Guid validGuid;
            permissiontDto.IsValideGuidFromToken = Guid.TryParse(tokenRapide, out validGuid);

            if (!permissiontDto.IsValideGuidFromToken)
                return permissiontDto;

            using CustomDbContext context = GetScopedDbContexte();

            // Vérifie si le dossier technique existe et récupère le code du statut
            var dossierTechnique = await context.DossierTechniques
                .Where(x => x.TokenAccesRapide == validGuid)
                .Select(e => new { Existe = true, StatutCode = e.Statut.Code, NumLastEtapeValidated = e.NumLastEtapValidated })
                .FirstOrDefaultAsync(cancellationToken);

            permissiontDto.IsDtExiste = dossierTechnique != null;
            permissiontDto.NumLastEtapeValidated = dossierTechnique?.NumLastEtapeValidated ?? 0;

            permissiontDto.CodeStatutDT = dossierTechnique?.StatutCode;

            if (permissiontDto.CodeStatutDT == CodeReferenceEnum.Cree.ToString())
            {
                permissiontDto.IsDtAccessible = true;
                permissiontDto.LibelleStatutDT = CodeReferenceEnum.Cree.GetDisplayName();
            }
            else if (permissiontDto.CodeStatutDT == CodeReferenceEnum.AValider.ToString())
            {
                permissiontDto.LibelleStatutDT = CodeReferenceEnum.AValider.GetDisplayName();
                //permissiontDto.Message = "Lorsque le statut d'un DT est \"À valider\", il est uniquement accessible au service commercial. Si vous appartenez à ce service, veuillez préalablement vous authentifier sur back-office d'Altalants pour accéder à ce DT.";

                permissiontDto.IsDtAccessible = true;

                if (!isUserLoggedInBackoffice)
                    permissiontDto.IsDtReadOnly = true;
            }
            else if (permissiontDto.CodeStatutDT == CodeReferenceEnum.Termine.ToString())
            {

                permissiontDto.LibelleStatutDT = CodeReferenceEnum.Termine.GetDisplayName();

                if (isUserLoggedInBackoffice)
                {
                    permissiontDto.IsDtAccessible = true;
                    permissiontDto.IsDtReadOnly = true;
                }
                else
                {

                    permissiontDto.Message = "Lorsque le statut d'un DT est à: 'terminé', il est alors publiquement inaccessible. Si vous appartenez au service commercial, vous pouvez vous connecter au Back Office d'altalents pour pouvoir le consulter.";

                }
            }

            return permissiontDto;
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

            string frenchNumber = @"^((\+33[-]?|0)[1-9])([-. ]?[0-9]{2}){4}$";
            string internationalNumber = @"^\(?\+?([0-9]{1,3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            if (telephone != null && (Regex.IsMatch(telephone, frenchNumber) || Regex.IsMatch(telephone, internationalNumber)))
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

            List<DocumentDto> listDocDtos = new List<DocumentDto>();

            Entities.Document CV = dt.Personne.Documents.FirstOrDefault(e => e.TypeDocument == TypeDocumentEnum.CV);
            if (CV != null)
            {
                listDocDtos.Add(new DocumentDto() { Id = CV.Id, MimeType = CV.MimeType, NomFichier = CV.Nom });
            }

            ParlonsDeVousDto reponse = new ParlonsDeVousDto()
            {
                Adresse = adresseDto,
                Telephone1 = contactTelephones.FirstOrDefault()?.Valeur,
                Email = dt.Personne.Email,
                Nom = dt.Personne.Nom,
                Prenom = dt.Personne.Prenom,
                Synthese = dt.Synthese,
                SoftSkills = dt.SoftSkills,
                ZoneGeo = dt.ZoneGeo,
                Documents = listDocDtos
            };

            return reponse;
        }

        private IIncludableQueryable<DossierTechnique, List<Contact>> GetQueryParlonsDeVous(CustomDbContext context, Guid tokenRapide)
        {
            return context.DossierTechniques
                            .Where(x => x.TokenAccesRapide == tokenRapide)
                            .Include(x => x.Personne)
                                .ThenInclude(x => x.Documents)
                            .Include(x => x.Personne)
                                .ThenInclude(x => x.Adresses)
                            .Include(x => x.Personne)
                                .ThenInclude(x => x.Contacts)
                      ;
        }

        public async Task PutParlonsDeVousAsync(Guid tokenRapide, ParlonsDeVousUpdateRequestDto request, CancellationToken cancellationToken)
        {
            DossierTechnique dt = await GetQueryParlonsDeVous(DbContext, tokenRapide)
                .AsTracking()
                .SingleAsync(cancellationToken);

            dt.Synthese = StringsHelpers.FirstLetterToUpperCase(request.Synthese);
            dt.SoftSkills = StringsHelpers.FirstLetterToUpperCase(request.SoftSKills);

            dt.ZoneGeo = request.zoneGeo;

            Adresse adresse = dt.Personne.Adresses?.FirstOrDefault();
            if (adresse != null)
            {
                adresse.Pays = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Pays);
                adresse.Adresse1 = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Adresse1);
                adresse.Adresse2 = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Adresse2);
                adresse.CodePostal = request.Adresse.CodePostal;
                adresse.Ville = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Ville);
            }
            else
            {
                dt.Personne.Adresses = new()
                {
                    new()
                    {
                        Pays = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Pays),
                        Adresse1 = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Adresse1),
                        Adresse2 = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Adresse2),
                        CodePostal= request.Adresse.CodePostal,
                        Ville = StringsHelpers.FirstLetterToUpperCase(request.Adresse.Ville)
                    }
                };
            }
            dt.Personne.Nom = StringsHelpers.FirstLetterToUpperCase(request.Nom);
            dt.Personne.Prenom = StringsHelpers.FirstLetterToUpperCase(request.Prenom);
            dt.Personne.Email = request.Email;

            //si un CV a ete renseigné
            if (request.Cv.Data != null && request.Cv.Data.Length > 0)
            {
                Entities.Document cv = dt.Personne.Documents.FirstOrDefault(e => e.TypeDocument == TypeDocumentEnum.CV);
                if (cv != null)
                {
                    cv.Nom = request.Cv.NomFichier;
                    cv.TypeDocument = TypeDocumentEnum.CV;
                    cv.MimeType = request.Cv.MimeType;
                    cv.Data = request.Cv.Data;
                }
                else
                {
                    dt.Personne.Documents = new()
                    {
                        new()
                        {
                           Nom = request.Cv.NomFichier,
                           TypeDocument = TypeDocumentEnum.CV,
                           MimeType = request.Cv.MimeType,
                           Data = request.Cv.Data,

                        }
                    };
                }
            }

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
            }

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<List<QuestionnaireDto>> GetQuestionnairesAsync(Guid tokenRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            return await context.QuestionDossierTechniques
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
                string rep = questionnaires.Single(x => x.Id == question.Id).Reponse;
                question.Reponse = StringsHelpers.FirstLetterToUpperCase(rep);
            });

            await context.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<List<ExperienceDto>> GetExperiencesAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            return await context.Experiences.Where(x => x.DossierTechnique.TokenAccesRapide == tokenAccesRapide)
                .OrderByDescending(x => x.DateDebut)
                .ProjectTo<ExperienceDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
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

        public async Task<Guid> AddOrUpdateExperienceAsync(Guid tokenAccesRapide, ExperienceRequestDto experienceDto, CancellationToken cancellationToken, Guid? id = null)
        {
            using CustomDbContext context = GetScopedDbContexte();
            Guid? idDossierTechnique = null;

            //update
            if (id != null)
            {
                Entities.Experience expToUpdate = await context.Experiences.Include(x => x.DossierTechnique).AsTracking().FirstOrDefaultAsync(x => x.Id == id.Value);
                if (expToUpdate != null)
                {
                    if (tokenAccesRapide == expToUpdate.DossierTechnique.TokenAccesRapide)
                    {
                        idDossierTechnique = expToUpdate.DossierTechnique.Id;
                        context.Experiences.Remove(expToUpdate);
                    }
                    else
                    {
                        throw new BusinessException("UNAUTHORIZED Action");
                    }
                }
            }
            //create
            else
            {
                idDossierTechnique = await GetDossierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
            }

            //mapiing & Save
            if (idDossierTechnique == null)
            {
                throw new BusinessException("UNAUTHORIZED Action");
            }
            else
            {
                DossierTechnique dt = await context.DossierTechniques.AsTracking().SingleAsync(x => x.TokenAccesRapide == tokenAccesRapide);
                dt.NumLastEtapValidated = 2;

                Entities.Experience expToAdd = Mapper.Map<Entities.Experience>(experienceDto);
                expToAdd.DossierTechniqueId = idDossierTechnique.Value;
                await context.Experiences.AddAsync(expToAdd, cancellationToken);

                await context.SaveBaseEntityChangesAsync(cancellationToken);
                return expToAdd.Id;
            }
        }

        public async Task<Guid> AddOrUpdateFormationCertificationAsync(Guid tokenAccesRapide, FormationCertificationRequestDto request, CancellationToken cancellationToken, Guid? id = null)
        {
            using CustomDbContext context = GetScopedDbContexte();

            FormationCertificationEnum formationCertificationEnum = (FormationCertificationEnum)Enum.Parse(typeof(FormationCertificationEnum), request.FormationOrCertificationEnumCode);

            switch (formationCertificationEnum)
            {
                case FormationCertificationEnum.Certification:

                    Certification certifToAddOrUpdate;

                    if (id == null)
                    {
                        certifToAddOrUpdate = Mapper.Map<Certification>(request);
                        certifToAddOrUpdate.DossierTechniqueId = await GetDossierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
                        await context.Certifications.AddAsync(certifToAddOrUpdate, cancellationToken);
                    }
                    else
                    {
                        certifToAddOrUpdate = context.Certifications.Include(x => x.DossierTechnique).AsTracking().FirstOrDefault(x => x.Id == id.Value);

                        if (tokenAccesRapide == certifToAddOrUpdate.DossierTechnique.TokenAccesRapide)
                        {
                            //Mappage manuel car le mappeur set A Null les champs qui ne sont pas definit dans la config alors que on veut pas vu que c'est un update
                            certifToAddOrUpdate.Libelle = StringsHelpers.FirstLetterToUpperCase(request.Libelle);
                            certifToAddOrUpdate.Niveau = StringsHelpers.FirstLetterToUpperCase(request.Niveau);
                            certifToAddOrUpdate.DateObtention = request.DateObtention;
                            certifToAddOrUpdate.Organisme = StringsHelpers.FirstLetterToUpperCase(request.Organisme);
                        }
                        else
                        {
                            throw new BusinessException("UNAUTHORIZED Action");
                        }
                    }

                    await context.SaveBaseEntityChangesAsync();
                    return certifToAddOrUpdate.Id;

                case FormationCertificationEnum.Formation:
                    Formation formationfToAddOrUpdate;

                    if (id == null)
                    {
                        formationfToAddOrUpdate = Mapper.Map<Formation>(request);
                        formationfToAddOrUpdate.DossierTechniqueId = await GetDossierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
                        await context.Formations.AddAsync(formationfToAddOrUpdate, cancellationToken);
                    }
                    else
                    {
                        formationfToAddOrUpdate = context.Formations.Include(x => x.DossierTechnique).AsTracking().FirstOrDefault(x => x.Id == id.Value);

                        if (tokenAccesRapide == formationfToAddOrUpdate.DossierTechnique.TokenAccesRapide)
                        {
                            //Mappage manuel car le mappeur set A Null les champs qui ne sont pas definit dans la config alors que on veut pas vu que c'est un update
                            formationfToAddOrUpdate.Libelle = StringsHelpers.FirstLetterToUpperCase(request.Libelle);
                            formationfToAddOrUpdate.Niveau = StringsHelpers.FirstLetterToUpperCase(request.Niveau);
                            formationfToAddOrUpdate.DateObtention = request.DateObtention;
                            formationfToAddOrUpdate.Organisme = StringsHelpers.FirstLetterToUpperCase(request.Organisme);
                        }
                        else
                        {
                            throw new BusinessException("UNAUTHORIZED Action");
                        }
                    }

                    await context.SaveBaseEntityChangesAsync(cancellationToken);
                    return formationfToAddOrUpdate.Id;
                default:
                    throw new BusinessException("FormationOrCertificationEnumCode ne correspond a aucun code valide : les valeur attendues sont : '1' (Formation) ou '2' (Certification ");
            }
        }

        public async Task<List<CompetenceDto>> GetLiaisonCandidatByTypeAsync(Guid tokenRapide, string typeLiaisonCode, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();
            TypeLiaisonEnum typeLiaisonEnum = (TypeLiaisonEnum)Enum.Parse(typeof(TypeLiaisonEnum), typeLiaisonCode);
            switch (typeLiaisonEnum)
            {
                case TypeLiaisonEnum.Competence:

                    List<LiaisonProjetCompetence> competences = await context.LiaisonProjetCompetences.Where(x => x.ProjetOrMissionClient.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                     .Include(x => x.Competence)
                                     .GroupBy(e => e.CompetenceId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);
                    return Mapper.Map<List<CompetenceDto>>(competences);


                case TypeLiaisonEnum.Methodologie:

                    List<LiaisonProjetMethodologie> methodologies = await context.LiaisonProjetMethodologies.Where(x => x.ProjetOrMissionClient.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                     .Include(x => x.Methodologie)
                                     .GroupBy(e => e.MethodologieId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);
                    return Mapper.Map<List<CompetenceDto>>(methodologies);


                case TypeLiaisonEnum.Outil:

                    List<LiaisonProjetOutil> Outils = await context.LiaisonProjetOutils.Where(x => x.ProjetOrMissionClient.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                     .Include(x => x.Outil)
                                     .GroupBy(e => e.OutilId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);
                    return Mapper.Map<List<CompetenceDto>>(Outils);


                case TypeLiaisonEnum.Technologie:

                    List<LiaisonProjetTechnologie> technologies = await context.LiaisonProjetTechnologies.Where(x => x.ProjetOrMissionClient.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                    .Include(x => x.Technologie)
                                     .GroupBy(e => e.TechnologieId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);
                    return Mapper.Map<List<CompetenceDto>>(technologies);


                default:
                    return new List<CompetenceDto>();
            }
        }


        public async Task UpdateNiveauLiaisonAsync(LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken)
        {

            TypeLiaisonEnum typeLiaisonEnum = (TypeLiaisonEnum)Enum.Parse(typeof(TypeLiaisonEnum), request.TypeLiaisonCode);

            using CustomDbContext context = GetScopedDbContexte();

            switch (typeLiaisonEnum)
            {
                case TypeLiaisonEnum.Competence:

                    LiaisonProjetCompetence liaisonCompetence = await context.LiaisonProjetCompetences.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonCompetence.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Methodologie:

                    LiaisonProjetMethodologie liaisonMethodo = await context.LiaisonProjetMethodologies.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonMethodo.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Outil:

                    LiaisonProjetOutil liaisonOutil = await context.LiaisonProjetOutils.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonOutil.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Technologie:

                    LiaisonProjetTechnologie liaisonTechno = await context.LiaisonProjetTechnologies.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonTechno.Niveau = request.Note;
                    break;

                default:
                    break;

            }

            await context.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<Guid> AddOrUpdateLangueParleeAsync(Guid tokenAccesRapide, LangueParleeRequestDto request, CancellationToken cancellationToken, Guid? id = null)
        {
            using CustomDbContext context = GetScopedDbContexte();
            DossierTechniqueLangue dossierTechniqueLangueToAddOrUpdate;

            if (id == null)
            {
                dossierTechniqueLangueToAddOrUpdate = Mapper.Map<DossierTechniqueLangue>(request);
                dossierTechniqueLangueToAddOrUpdate.DossierTechniqueId = await GetDossierTechniqueIdFromTokenAsync(tokenAccesRapide, cancellationToken);
                await context.DossierTechniqueLangues.AddAsync(dossierTechniqueLangueToAddOrUpdate, cancellationToken);
            }
            else
            {

                dossierTechniqueLangueToAddOrUpdate = context.DossierTechniqueLangues.Include(x => x.DossierTechnique).AsTracking().FirstOrDefault(x => x.Id == id.Value);

                if (tokenAccesRapide == dossierTechniqueLangueToAddOrUpdate.DossierTechnique.TokenAccesRapide)
                {
                    //Mappage manuel car le mappeur set A Null les champs qui ne sont pas definit dans la config alors que on veut pas vu que c'est un update
                    dossierTechniqueLangueToAddOrUpdate.LangueId = request.LangueId;
                    dossierTechniqueLangueToAddOrUpdate.NiveauId = request.NiveauId;
                }
                else
                {
                    throw new BusinessException("UNAUTHORIZED Action");
                }
            }

            await context.SaveBaseEntityChangesAsync(cancellationToken);

            return dossierTechniqueLangueToAddOrUpdate.Id;
        }

        private IQueryable<DossierTechnique> GetDossierTechniquesFromToken(Guid tokenAccesRapide, CustomDbContext contexte)
        {
            return contexte.DossierTechniques

                .Where(dt => dt.TokenAccesRapide == tokenAccesRapide);
        }

        public async Task<RecapitulatifDtDto> GetRecapitulatifDtAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {

            using CustomDbContext context = GetScopedDbContexte();
            using CustomDbContext context2 = GetScopedDbContexte();

            // Lancer la récupération de dossierTechnique en parallèle avec les autres appels
            Task<DossierTechnique> dossierTechniqueTask = GetDossierTechniquesFromToken(tokenAccesRapide, context)
              .Include(dt => dt.Experiences)
                    .ThenInclude(exp => exp.ProjetsOrMissionsClient)
                        .ThenInclude(exp => exp.LiaisonProjetCompetences)
                            .ThenInclude(ec => ec.Competence)
                .Include(dt => dt.Experiences)
                    .ThenInclude(exp => exp.ProjetsOrMissionsClient)
                        .ThenInclude(exp => exp.LiaisonProjetOutils)
                            .ThenInclude(lo => lo.Outil)
                .Include(dt => dt.Experiences)
                    .ThenInclude(exp => exp.ProjetsOrMissionsClient)
                        .ThenInclude(exp => exp.LiaisonProjetMethodologies)
                            .ThenInclude(lm => lm.Methodologie)
                .Include(dt => dt.Experiences)
                    .ThenInclude(exp => exp.ProjetsOrMissionsClient)
                        .ThenInclude(exp => exp.LiaisonProjetTechnologies)
                            .ThenInclude(lt => lt.Technologie)
                .Include(dt => dt.Experiences)
                    .ThenInclude(exp => exp.ProjetsOrMissionsClient)
                        .ThenInclude(lt => lt.DomaineMetier)
                .SingleOrDefaultAsync(cancellationToken);

            // Lancer la récupération de dossierTechnique en parallèle avec les autres appels
            Task<DossierTechnique> dossierTechnique2Task = GetDossierTechniquesFromToken(tokenAccesRapide, context2)
                .Include(dt => dt.Formations)
                .Include(dt => dt.Personne)
                .Include(dt => dt.Certifications)
                .Include(dt => dt.DossierTechniqueLangues).ThenInclude(dtl => dtl.Langue)
                .Include(dt => dt.DossierTechniqueLangues).ThenInclude(dtl => dtl.Niveau)
                .Include(dt => dt.QuestionDossierTechniques)
                .SingleOrDefaultAsync(cancellationToken);

            Task<List<CompetenceDto>> competencesTask = GetLiaisonCandidatByTypeAsync(tokenAccesRapide, TypeLiaisonEnum.Competence.GetHashCode().ToString(), cancellationToken);
            Task<List<CompetenceDto>> methodologiesTask = GetLiaisonCandidatByTypeAsync(tokenAccesRapide, TypeLiaisonEnum.Methodologie.GetHashCode().ToString(), cancellationToken);
            Task<List<CompetenceDto>> technologieTask = GetLiaisonCandidatByTypeAsync(tokenAccesRapide, TypeLiaisonEnum.Technologie.GetHashCode().ToString(), cancellationToken);
            Task<List<CompetenceDto>> outilsTask = GetLiaisonCandidatByTypeAsync(tokenAccesRapide, TypeLiaisonEnum.Outil.GetHashCode().ToString(), cancellationToken);

            Task<ParlonsDeVousDto> InfoBasicTask = GetParlonsDeVousAsync(tokenAccesRapide, cancellationToken);

            DossierTechnique dossierTechnique = await dossierTechniqueTask;
            DossierTechnique dossierTechnique2 = await dossierTechnique2Task;
            dossierTechnique.Formations = dossierTechnique2.Formations;
            dossierTechnique.Personne = dossierTechnique2.Personne;
            dossierTechnique.Certifications = dossierTechnique2.Certifications;
            dossierTechnique.DossierTechniqueLangues = dossierTechnique2.DossierTechniqueLangues;
            dossierTechnique.QuestionDossierTechniques = dossierTechnique2.QuestionDossierTechniques;
            // Appliquer le tri sur les expériences après récupération
            if (dossierTechnique != null && dossierTechnique.Experiences != null)
            {
                dossierTechnique.Experiences = dossierTechnique.Experiences
                    .OrderByDescending(x => x.DateDebut)
                    .ToList();
            }

            if (dossierTechnique == null)
                throw new BusinessException("Dossier technique inexistant");

            RecapitulatifDtDto recapitulatif = new()
            {
                Competences = new()
                {
                    Competences = await competencesTask,
                    Methodologies = await methodologiesTask,
                    Technologie = await technologieTask,
                    Outils = await outilsTask
                },

                ParlonsDeVous = await InfoBasicTask,

                Formations = Mapper.Map<List<FormationCertificationDto>>(dossierTechnique.Formations),
                Certifications = Mapper.Map<List<FormationCertificationDto>>(dossierTechnique.Certifications),
                Langues = Mapper.Map<List<LangueParleeDto>>(dossierTechnique.DossierTechniqueLangues),
                Questionnaires = Mapper.Map<List<QuestionnaireDto>>(dossierTechnique.QuestionDossierTechniques),
                Experiences = Mapper.Map<List<ExperienceDto>>(dossierTechnique.Experiences)

            };

            return recapitulatif;
        }

        public async Task DeleteDossierTechniqueAndPersonne(Guid idDossierTechnique, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            Entities.DossierTechnique dtToDelete = await context.DossierTechniques.AsTracking().SingleAsync(x => x.Id == idDossierTechnique);
            if (dtToDelete != null)
            {
                context.DossierTechniques.Remove(dtToDelete);

                await context.Experiences.Where(x => x.DossierTechniqueId == idDossierTechnique).ExecuteDeleteAsync();
                await context.DocumentComplementaires.Where(x => x.DossierTechniqueId == idDossierTechnique).ExecuteDeleteAsync();
                await context.QuestionDossierTechniques.Where(x => x.DossierTechniqueId == idDossierTechnique).ExecuteDeleteAsync();
                await context.Formations.Where(x => x.DossierTechniqueId == idDossierTechnique).ExecuteDeleteAsync();
                await context.Certifications.Where(x => x.DossierTechniqueId == idDossierTechnique).ExecuteDeleteAsync();
                await context.DossierTechniqueLangues.Where(x => x.DossierTechniqueId == idDossierTechnique).ExecuteDeleteAsync();

                await context.Contacts.Where(x => x.PersonneId == dtToDelete.PersonneId).ExecuteDeleteAsync();
                await context.Documents.Where(x => x.PersonneId == dtToDelete.PersonneId).ExecuteDeleteAsync();
                await context.Adresses.Where(x => x.PersonneId == dtToDelete.PersonneId).ExecuteDeleteAsync();
                var personne = new Entities.Personne { Id = dtToDelete.PersonneId };
                context.Personnes.Remove(personne);
                await context.SaveBaseEntityChangesAsync(cancellationToken);
            }
            else
            {
                throw new BusinessException("Impossible de supprinmer un Dossier Technique qui n'existe pas en BDD");
            }
        }

        public async Task DeleteProjectOrMissionAsync(Guid tokenAccesRapide, Guid idMissionToDelete, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            Entities.ProjetOrMissionClient prjOrMissionToDelete = await context.ProjetsOrMissionsClient.AsTracking().SingleAsync(x => x.Id == idMissionToDelete && x.Experience.DossierTechnique.TokenAccesRapide == tokenAccesRapide);
            if (prjOrMissionToDelete != null)
            {
                context.ProjetsOrMissionsClient.Remove(prjOrMissionToDelete);
                await context.SaveBaseEntityChangesAsync(cancellationToken);
            }
            else
            {
                throw new BusinessException("Ce projet ou cette mission n'existe pas ou alors vous n'avez pas le droit de la supprimer");
            }
        }


        public async Task DeleteLangueParleeAsync(Guid tokenAccesRapide, Guid id, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            DossierTechniqueLangue candidatLangueToDelete = await context.DossierTechniqueLangues.Include(x => x.DossierTechnique).SingleAsync(x => x.Id == id, cancellationToken);

            if (candidatLangueToDelete != null)
            {
                if (tokenAccesRapide == candidatLangueToDelete.DossierTechnique.TokenAccesRapide)
                {
                    context.DossierTechniqueLangues.Remove(candidatLangueToDelete);
                    await context.SaveBaseEntityChangesAsync(cancellationToken);
                }
                else
                {
                    throw new BusinessException("UNAUTHORIZED Action");
                }
            }
            else
            {
                throw new BusinessException("Impossible de supprimer la langue du candidat correspondant a l'id : " + id.ToString());

            }
        }

        public async Task DeleteExperienceAsync(Guid tokenAccesRapide, Guid id, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            Entities.Experience expToDelete = await context.Experiences.Include(x => x.DossierTechnique).AsTracking().SingleAsync(x => x.Id == id);
            if (expToDelete != null)
            {
                if (tokenAccesRapide == expToDelete.DossierTechnique.TokenAccesRapide)
                {
                    context.Experiences.Remove(expToDelete);
                    await context.SaveBaseEntityChangesAsync(cancellationToken);
                }
                else
                {
                    throw new BusinessException("UNAUTHORIZED Action");
                }
            }
        }

        public async Task DeleteFormationCertificationAsync(Guid tokenAccesRapide, Guid id, FormationCertificationEnum formationOrCertificationEnum, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            switch (formationOrCertificationEnum)
            {
                case FormationCertificationEnum.Certification:

                    Certification certificationToDelete = await context.Certifications.Include(x => x.DossierTechnique).SingleAsync(x => x.Id == id, cancellationToken);

                    if (certificationToDelete != null)
                    {
                        if (tokenAccesRapide == certificationToDelete.DossierTechnique.TokenAccesRapide)
                        {
                            context.Certifications.Remove(certificationToDelete);
                        }
                        else
                        {
                            throw new BusinessException("UNAUTHORIZED Action");
                        }
                    }
                    else
                    {
                        throw new BusinessException("Impossible de supprimer la certification correspondant a l'id : " + id.ToString());
                    }
                    break;

                case FormationCertificationEnum.Formation:

                    Formation formationToDelete = await context.Formations.Include(x => x.DossierTechnique).SingleAsync(x => x.Id == id, cancellationToken);

                    if (formationToDelete != null)
                    {
                        if (tokenAccesRapide == formationToDelete.DossierTechnique.TokenAccesRapide)
                        {
                            context.Formations.Remove(formationToDelete);
                        }
                        else
                        {
                            throw new BusinessException("UNAUTHORIZED Action");
                        }

                    }
                    else
                    {
                        throw new BusinessException("Impossible de supprimer la formation correspondant a l'id : " + id.ToString());
                    }
                    break;

                default:
                    throw new BusinessException("FormationOrCertificationEnum ne correspond a aucun cas valide : les cas attendus sont : '1' (Formation) ou '2' (Certification ");
            }

            await context.SaveBaseEntityChangesAsync(cancellationToken);
        }

    }
}
