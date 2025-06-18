using System.Collections;
using System.Net.Mail;
using Altalents.Business.Extensions;
using Altalents.Commun.Enums;
using Altalents.Commun.Settings;
using Altalents.Entities;
using Altalents.Export.DSO.OpenXml;
using Altalents.Export.OpenXml;
using Altalents.Export.Services;
using Altalents.IBusiness.DTO.Request;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using MimeKit;
using Spire.Doc;
using Document = Spire.Doc.Document;



namespace Altalents.Business.Services
{
    public class DossierTechniqueExportService : BaseAppService<CustomDbContext>, IDossierTechniqueExportService
    {

        private readonly CommercialSettings _commercialSettings;

        public DossierTechniqueExportService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider,
            IOptions<CommercialSettings> commercialSettings) : base(logger, contexte, mapper, serviceProvider)
        {

            _commercialSettings = commercialSettings.Value;
        }

        private IQueryable<DossierTechnique> GetDossierTechniquesFromToken(Guid tokenAccesRapide, CustomDbContext contexte)
        {
            return contexte.DossierTechniques

                .Where(dt => dt.TokenAccesRapide == tokenAccesRapide);
        }
        public async Task<DocumentDto> GenereateDtWithOpenXmlAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            using CustomDbContext contextExperiences = GetScopedDbContexte();
            using CustomDbContext contextFormationsPersonneCertifications = GetScopedDbContexte();
            using CustomDbContext contextLanguesQuestionDossierTechniques = GetScopedDbContexte();

            DossierTechnique dt = null;
            Task<DossierTechnique> dtExperiencesTask = GetDossierTechniquesFromToken(tokenAccesRapide, contextExperiences)
                .Include(dt => dt.Experiences)
                    .ThenInclude(ec => ec.DomaineMetier)
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

            Task<DossierTechnique> dtFormationsPersonneCertificationsTask = GetDossierTechniquesFromToken(tokenAccesRapide, contextFormationsPersonneCertifications)
                .Include(dt => dt.Formations)
                .Include(dt => dt.Personne)
                .Include(dt => dt.Certifications)
                .SingleOrDefaultAsync(cancellationToken);

            Task<DossierTechnique> dtDossierTechniqueLanguesQuestionDossierTechniquesTask = GetDossierTechniquesFromToken(tokenAccesRapide, contextLanguesQuestionDossierTechniques)
                .Include(dt => dt.DossierTechniqueLangues).ThenInclude(dtl => dtl.Langue)
                .Include(dt => dt.DossierTechniqueLangues).ThenInclude(dtl => dtl.Niveau)
                .Include(dt => dt.QuestionDossierTechniques)
                .SingleOrDefaultAsync(cancellationToken);

            dt = await dtFormationsPersonneCertificationsTask;
            DossierTechnique dtDossierTechniqueLanguesQuestionDossierTechniques = await dtDossierTechniqueLanguesQuestionDossierTechniquesTask
            dt.DossierTechniqueLangues = dtDossierTechniqueLanguesQuestionDossierTechniques.DossierTechniqueLangues;
            dt.QuestionDossierTechniques = dtDossierTechniqueLanguesQuestionDossierTechniques.QuestionDossierTechniques;
            dt.Experiences = (await dtExperiencesTask).Experiences;

            if (dt == null)
            {
                throw new BusinessException("UNAUTHORIZED Action");
            }

            DtMainPageExportDso modelExport = new DtMainPageExportDso
            {
                //Remplissage data de l'entete
                Candidat_Trigramme = dt.Personne.Trigramme.ToUpper(),
                Dt_Poste = dt.Poste,

                //remplissage data du bloc Contact Commercial
                Commercial_SiteWeb = "www.altea-si.com",
                Commercial_NomComplet = _commercialSettings.Nom,
                Commercial_Email = _commercialSettings.Mail,
                Commercial_Phone = _commercialSettings.Telephone
            };

            //remplissage data du bloc Contact Focus
            int nbExp = CalculerTotalAnneesExperienceAvecChevauchements(dt);
            modelExport.Candidat_NbAnneesExperiences = nbExp == 0 ? "Novice" : nbExp == 1 ? "1 an" : nbExp.ToString() + " ans";
            modelExport.Candidat_CompetencesClefs = GetTop5Competences(dt);
            modelExport.Candidat_Synthese = dt.Synthese;

            //remplissage data du tableau compétences technique
            modelExport.Candidat_SoftSkill = dt.SoftSkills;
            //modelExport.Candidat_Bdd = "";
            //modelExport.Candidat_Versionning = "";
            //modelExport.Candidat_IDE = "";
            //modelExport.Candidat_Framework = "";

            modelExport.Candidat_Domaines = GetFormatedCompetencesFromExperiences(dt);
            modelExport.Candidat_Languages_Prog = GetFormatedTechnologiesFromExperiences(dt);
            modelExport.Candidat_Outils = GetFormatedOutilsFromExperiences(dt);
            modelExport.Candidat_Methodologie = GetFormatedMethodologiesFromExperiences(dt);

            //Remplissage data des templates enfants
            modelExport.Candidat_CompetencesMetiers = getDomainesMetierWithNbAnneeExp(dt);
            modelExport.Candidat_Formations = getFormationsOrderedByDateDesc(dt);
            modelExport.Candidat_Certifications = getCertificationOrderedByDateDesc(dt);
            modelExport.Candidat_Langues = getLanguesParle(dt);
            //modelExport.Candidat_ExperiencesProV1 = GetExperiencesOrderedByDate(dt);
            modelExport.Candidat_ExperiencesProV2 = GetExperiencesOrderedByDateV2(dt);

            modelExport.Candidat_Questions = GetQuestionToShowInDt(dt);


            GetQuestionToShowInDt(dt);

            WordTemplateService WordTemplateService = new WordTemplateService();
            byte[] generatedFile = WordTemplateService.GenerateDocument(modelExport);

            return new DocumentDto()
            {
                MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                NomFichier = dt.Personne.Trigramme.ToUpper() + " - " + dt.Poste + " - " + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + ".docx",
                Data = generatedFile
            };
        }

        public async Task<DocumentDto> GenereateDtWithOpenXmlAndReturnPdfAsync(Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            // Appeler la méthode qui génère le fichier Word
            var wordGenerated = await GenereateDtWithOpenXmlAsync(tokenAccesRapide, cancellationToken);

            // Créer un flux mémoire pour le fichier PDF
            using (MemoryStream wordStream = new MemoryStream(wordGenerated.Data))
            using (MemoryStream pdfStream = new MemoryStream())
            {
                // Charger le fichier Word
                Document wordDocument = new Document();
                wordDocument.LoadFromStream(wordStream, FileFormat.Docx);

                // Sauvegarder en PDF dans le flux mémoire
                wordDocument.SaveToStream(pdfStream, FileFormat.PDF);

                // Retourner le fichier PDF en réponse
                return new DocumentDto()
                {
                    MimeType = "application/pdf", // Type MIME pour PDF
                    NomFichier = wordGenerated.NomFichier.Replace(".docx", ".pdf"), // Remplacer l'extension en .pdf
                    Data = pdfStream.ToArray() // Renvoyer les données PDF
                };
            }
        }

        private static int CalculerTotalAnneesExperienceAvecChevauchements(DossierTechnique dt)
        {
            if (dt?.Experiences == null || !dt.Experiences.Any())
            {
                return 0; // Aucun calcul si aucune expérience n'est associée
            }

            // Récupère et normalise les plages de dates
            var plages = dt.Experiences
                .Select(exp => new
                {
                    StartDate = exp.DateDebut,
                    EndDate = exp.DateFin ?? DateTime.UtcNow // Utilise la date actuelle si DateFin est null
                })
                .OrderBy(exp => exp.StartDate)
                .ToList();

            // Consolidation des plages pour gérer les chevauchements
            var plagesConsolidees = new List<(DateTime Start, DateTime End)>();
            foreach (var plage in plages)
            {
                if (plagesConsolidees.Count == 0 || plagesConsolidees.Last().End < plage.StartDate)
                {
                    // Pas de chevauchement, ajouter directement
                    plagesConsolidees.Add((plage.StartDate, plage.EndDate));
                }
                else
                {
                    // Fusionner avec la dernière plage
                    var dernierePlage = plagesConsolidees.Last();
                    plagesConsolidees[plagesConsolidees.Count - 1] = (
                        dernierePlage.Start,
                        new DateTime(Math.Max(dernierePlage.End.Ticks, plage.EndDate.Ticks))
                    );
                }
            }

            // Calcul de la durée totale en jours
            double totalDays = plagesConsolidees
                .Sum(plage => (plage.End - plage.Start).TotalDays);

            // Conversion en années avec arrondi standard (0,5 ou plus monte à l'année supérieure)
            return (int)Math.Round(totalDays / 365.2425, MidpointRounding.AwayFromZero);
        }


        private static string GetTop5Competences(DossierTechnique dt)
        {

            var allCompetences = dt.Experiences
                .SelectMany(exp => exp.ProjetsOrMissionsClient
                        .SelectMany(proj => proj.LiaisonProjetCompetences
                            .Where(lec => lec.Competence != null )
                            .Select(lec => new
                            {
                                lec.Competence.Libelle,
                                lec.Niveau
                            })))
                .Concat(dt.Experiences
                    .SelectMany(exp => exp.ProjetsOrMissionsClient
                        .SelectMany(proj => proj.LiaisonProjetTechnologies
                            .Where(lec => lec.Technologie != null)
                            .Select(lec => new
                            {
                                lec.Technologie.Libelle,
                                lec.Niveau
                            }))))
                .Concat(dt.Experiences
                    .SelectMany(exp => exp.ProjetsOrMissionsClient
                        .SelectMany(proj => proj.LiaisonProjetMethodologies
                            .Where(lec => lec.Methodologie != null)
                            .Select(lec => new
                            {
                                lec.Methodologie.Libelle,
                                lec.Niveau
                            }))))
                .Concat(dt.Experiences
                     .SelectMany(exp => exp.ProjetsOrMissionsClient
                        .SelectMany(proj => proj.LiaisonProjetOutils
                            .Where(lec => lec.Outil != null)
                            .Select(lec => new
                            {
                                lec.Outil.Libelle,
                                lec.Niveau
                            }))))
                .OrderByDescending(x => x.Niveau)
                .Take(5)
                .ToList();

            string Top5BestCompetences = "";
            foreach (var competence in allCompetences)
            {
                Top5BestCompetences += competence.Libelle + ", ";
            }

            if (Top5BestCompetences.Length >= 2)
            {
                Top5BestCompetences = Top5BestCompetences.Remove(Top5BestCompetences.Length - 2);
            }

            return Top5BestCompetences;

        }



        public string GetFormatedCompetencesFromExperiences(DossierTechnique dt)
        {
            if (dt == null || dt.Experiences == null || !dt.Experiences.Any())
                return string.Empty;

            List<string> technologies = dt.Experiences
                .SelectMany(exp => exp.ProjetsOrMissionsClient)
                .Where(proj => proj.LiaisonProjetCompetences != null)
                .SelectMany(proj => proj.LiaisonProjetCompetences)
                .Where(lt => lt.Competence != null)
                .Select(lt => lt.Competence.Libelle)
                .Distinct()
                .OrderBy(libelle => libelle)
                .ToList();

            return string.Join(", ", technologies);

        }

        public string GetFormatedOutilsFromExperiences(DossierTechnique dt)
        {
            if (dt == null || dt.Experiences == null || !dt.Experiences.Any())
                return string.Empty;

            List<string> outils = dt.Experiences
                .SelectMany(exp => exp.ProjetsOrMissionsClient)
                .Where(exp => exp.LiaisonProjetOutils != null)
                .SelectMany(exp => exp.LiaisonProjetOutils)
                .Where(lt => lt.Outil != null)
                .Select(lt => lt.Outil.Libelle)
                .Distinct()
                .OrderBy(libelle => libelle)
                .ToList();

            return string.Join(", ", outils);
        }

        public string GetFormatedTechnologiesFromExperiences(DossierTechnique dt)
        {
            if (dt == null || dt.Experiences == null || !dt.Experiences.Any())
                return string.Empty;

            List<string> technologies = dt.Experiences
                .SelectMany(exp => exp.ProjetsOrMissionsClient)
                .Where(proj => proj.LiaisonProjetTechnologies != null)
                .SelectMany(proj => proj.LiaisonProjetTechnologies)
                .Where(lt => lt.Technologie != null)
                .Select(lt => lt.Technologie.Libelle)
                .Distinct()
                .OrderBy(libelle => libelle)
                .ToList();

            return string.Join(", ", technologies);
        }

        public string GetFormatedMethodologiesFromExperiences(DossierTechnique dt)
        {
            if (dt == null || dt.Experiences == null || !dt.Experiences.Any())
                return string.Empty;

            List<string> methodologies = dt.Experiences
                  .SelectMany(exp => exp.ProjetsOrMissionsClient)
                .Where(exp => exp.LiaisonProjetMethodologies != null)
                .SelectMany(exp => exp.LiaisonProjetMethodologies)
                .Where(lm => lm.Methodologie != null)
                .Select(lm => lm.Methodologie.Libelle)
                .Distinct()
                .OrderBy(libelle => libelle)
                .ToList();

            return string.Join(", ", methodologies);
        }

        private static List<DtCompetenceMetierExportDso> getDomainesMetierWithNbAnneeExp(DossierTechnique dt)
        {
            List<DtCompetenceMetierExportDso> domainesMetierExperiences = getDomainesMetierFromExperiences(dt);
            List<DtCompetenceMetierExportDso> domainesMetierMissions = getDomainesMetierFromMissions(dt);

            var result = domainesMetierExperiences
                .Union(domainesMetierMissions)
                .GroupBy(d => d.Nom) //
                .Select(g => g.OrderByDescending(d =>
                {
                    int years = int.TryParse(d.DureeExperience.Split(' ')[0], out var y) ? y : 0;
                    return years;
                }).First())
                .ToList();

            return result;
        }

        private static List<DtCompetenceMetierExportDso> getDomainesMetierFromExperiences(DossierTechnique dt)
        {
            return dt.Experiences
                .Where(exp => exp.DomaineMetier != null)
                .GroupBy(exp => exp.DomaineMetier.Libelle)
                .Select(group =>
                {
                    // Récupérer les plages de dates pour ce domaine
                    var plages = group
                        .Select(exp => new
                        {
                            StartDate = exp.DateDebut,
                            EndDate = exp.DateFin ?? DateTime.UtcNow
                        })
                        .OrderBy(plage => plage.StartDate)
                        .ToList();

                    // Consolidation des plages pour gérer les chevauchements
                    var plagesConsolidees = new List<(DateTime Start, DateTime End)>();
                    foreach (var plage in plages)
                    {
                        if (plagesConsolidees.Count == 0 || plagesConsolidees.Last().End < plage.StartDate)
                        {
                            // Pas de chevauchement, ajouter directement
                            plagesConsolidees.Add((plage.StartDate, plage.EndDate));
                        }
                        else
                        {
                            // Fusionner avec la dernière plage
                            var dernierePlage = plagesConsolidees.Last();
                            plagesConsolidees[plagesConsolidees.Count - 1] = (
                                dernierePlage.Start,
                                new DateTime(Math.Max(dernierePlage.End.Ticks, plage.EndDate.Ticks))
                            );
                        }
                    }

                    // Calculer la durée totale consolidée en années
                    double totalDays = plagesConsolidees
                        .Sum(plage => (plage.End - plage.Start).TotalDays);
                    double totalYears = totalDays / 365.2425;

                    // Appliquer l'arrondi selon les règles
                    int roundedYears = totalYears < 1
                        ? 1
                        : (int)Math.Round(totalYears, MidpointRounding.AwayFromZero);

                    return new DtCompetenceMetierExportDso
                    {
                        Nom = group.Key,
                        DureeExperience = $"{roundedYears} année{(roundedYears > 1 ? "s" : "")}"
                    };
                })
                .ToList();
        }

        private static List<DtCompetenceMetierExportDso> getDomainesMetierFromMissions(DossierTechnique dt)
        {
            return dt.Experiences
                .SelectMany(exp => exp.ProjetsOrMissionsClient)
                .Where(pmc => pmc.DomaineMetier != null)
                .GroupBy(pmc => pmc.DomaineMetier.Libelle)
                .Select(group =>
                {
                    // Récupérer les plages de dates pour ce domaine (missions)
                    var plages = group
                        .Select(pmc => new
                        {
                            StartDate = pmc.DateDebut ?? DateTime.UtcNow, // Utiliser DateTime.UtcNow si la date de début est null
                            EndDate = pmc.DateFin ?? DateTime.UtcNow // Idem pour la date de fin
                        })
                        .OrderBy(plage => plage.StartDate)
                        .ToList();

                    // Consolidation des plages pour gérer les chevauchements
                    var plagesConsolidees = new List<(DateTime Start, DateTime End)>();
                    foreach (var plage in plages)
                    {
                        if (plagesConsolidees.Count == 0 || plagesConsolidees.Last().End < plage.StartDate)
                        {
                            // Pas de chevauchement, ajouter directement
                            plagesConsolidees.Add((plage.StartDate, plage.EndDate));
                        }
                        else
                        {
                            // Fusionner avec la dernière plage
                            var dernierePlage = plagesConsolidees.Last();
                            plagesConsolidees[plagesConsolidees.Count - 1] = (
                                dernierePlage.Start,
                                new DateTime(Math.Max(dernierePlage.End.Ticks, plage.EndDate.Ticks))
                            );
                        }
                    }

                    // Calculer la durée totale consolidée des missions en années
                    double totalDays = plagesConsolidees
                        .Sum(plage => (plage.End - plage.Start).TotalDays);
                    double totalYears = totalDays / 365.2425;

                    // Appliquer l'arrondi selon les règles
                    int roundedYears = totalYears < 1
                        ? 1
                        : (int)Math.Round(totalYears, MidpointRounding.AwayFromZero);

                    return new DtCompetenceMetierExportDso
                    {
                        Nom = group.Key,
                        DureeExperience = $"{roundedYears} année{(roundedYears > 1 ? "s" : "")}" // Affichage avec le bon pluriel
                    };
                })
                .ToList();
        }

        private static List<DtCertificationExportDso> getCertificationOrderedByDateDesc(DossierTechnique dt)
        {
            return dt.Certifications
              .OrderByDescending(certif => certif.DateObtention) // Tri par DateFin ou DateDebut si DateFin est null
              .Select(certif =>
              {
                  // Construire le libellé complet
                  string niveauPart = !string.IsNullOrEmpty(certif.Niveau) ? $" ({certif.Niveau})" : string.Empty;
                  string organiusmePart = !string.IsNullOrEmpty(certif.Organisme) ? $" - {certif.Organisme}" : string.Empty;

                  return new DtCertificationExportDso
                  {
                      Annee = certif.DateObtention.ToString("yyyy"), // Convertir DateTime en string
                      LibelleComplet = certif.Libelle + niveauPart + organiusmePart
                  };
              })
              .ToList();
        }

        private static List<DtFormationExportDso> getFormationsOrderedByDateDesc(DossierTechnique dt)
        {
            return dt.Formations
              .OrderByDescending(forma => forma.DateObtention) // Tri par DateFin ou DateDebut si DateFin est null
              .Select(forma =>
              {
                  // Construire le libellé complet
                  string niveauPart = !string.IsNullOrEmpty(forma.Niveau) ? $" ({forma.Niveau})" : string.Empty;
                  string organiusmePart = !string.IsNullOrEmpty(forma.Organisme) ? $" - {forma.Organisme}" : string.Empty;

                  return new DtFormationExportDso
                  {
                      Annee = forma.DateObtention.ToString("yyyy"), // Convertir DateTime en string
                      LibelleComplet = forma.Libelle + niveauPart + organiusmePart
                  };
              })
              .ToList();
        }

        private static List<DtLangueExportDso> getLanguesParle(DossierTechnique dt)
        {
            return dt.DossierTechniqueLangues
              .OrderByDescending(lang => lang.Niveau.OrdreTri)
              .Select(lang =>
              {
                  return new DtLangueExportDso
                  {
                      Libelle = lang.Langue.Libelle,
                      Niveau = lang.Niveau.Libelle
                  };
              })
              .ToList();
        }

        public List<DtExperienceProExportDso> GetExperiencesOrderedByDate(DossierTechnique dt)
        {
            if (dt == null || dt.Experiences == null)
                return new List<DtExperienceProExportDso>();

            return dt.Experiences
                .OrderByDescending(exp => exp.DateDebut)
                .Select(exp => new DtExperienceProExportDso
                {
                    IsEsn = exp.IsEntrepriseEsnOrInterim,
                    NomClientIfEsn = exp.IsEntrepriseEsnOrInterim && exp.ProjetsOrMissionsClient != null
                        ? string.Join(", ", exp.ProjetsOrMissionsClient.Select(p => p.NomClientOrProjet))
                        : null,
                    NomEntreprise = exp.NomEntreprise,
                    IntitulePoste = exp.IntitulePoste,
                    Lieu = exp.LieuEntreprise,
                    TypeContrat = exp.TypeContrat?.Libelle,
                    DateDebutEtDateFin = $"{exp.DateDebut:MM/yyyy} --> {(exp.DateFin.HasValue ? exp.DateFin.Value.ToString("MM/yyyy") : "Aujourd'hui")}",
                    EnvironnementsTechnique = string.Join(", ",
                        (exp.ProjetsOrMissionsClient.SelectMany(x=>x.LiaisonProjetTechnologies?.Select(lt => lt.Technologie?.Libelle) ?? Enumerable.Empty<string>()))
                        .Concat(exp.ProjetsOrMissionsClient.SelectMany(x=>x.LiaisonProjetOutils?.Select(lo => lo.Outil?.Libelle) ?? Enumerable.Empty<string>()))),
                    MissionsOrProjects = exp.ProjetsOrMissionsClient?
                        .OrderByDescending(p => p.DateDebut)
                        .Select(p => new DtExpProMission
                        {
                            NomClient = p.NomClientOrProjet,
                            DateDebutDateFin = p.DateDebut.HasValue && p.DateFin.HasValue
                                ? $"Début : {p.DateDebut:MM/yyyy} --> Fin : {p.DateFin:MM/yyyy}"
                                : p.DateDebut.HasValue
                                    ? $"Début : {p.DateDebut:MM/yyyy}"
                                    : p.DateFin.HasValue
                                        ? $"Fin : {p.DateFin:MM/yyyy}"
                                        : string.Empty,
                            DomaineMetier = p.DomaineMetier?.Libelle,
                            Lieu = p.Lieu,
                            DescriptionProjet = p.DescriptionProjetOrMission,
                            Taches = p.Taches,
                            CompoEquipe = p.CompositionEquipe,
                            Budget = p.Budget.HasValue ? p.Budget.Value + " €" : null,

                        }).ToList()
                }).ToList();
        }


        public List<DtExperienceProExportDsoV2> GetExperiencesOrderedByDateV2(DossierTechnique dt)
        {
            if (dt == null || dt.Experiences == null)
                return new List<DtExperienceProExportDsoV2>();

            return dt.Experiences
                .OrderBy(exp => exp.DateDebut)
                .Select(exp => new DtExperienceProExportDsoV2
                {
                    IsEsn = exp.IsEntrepriseEsnOrInterim,
                    NomEntreprise = exp.NomEntreprise,
                    IntitulePoste = exp.IntitulePoste,
                    Lieu = exp.LieuEntreprise,
                    TypeContrat = exp.TypeContrat?.Libelle,
                    DateDebutEtDateFin = $"{exp.DateDebut:MM/yyyy} --> {(exp.DateFin.HasValue ? exp.DateFin.Value.ToString("MM/yyyy") : "Aujourd'hui")}",
                    DomaineMetier = exp.DomaineMetier?.Libelle,
                    MissionsOrProjects = exp.ProjetsOrMissionsClient?
                        .OrderByDescending(p => p.DateDebut)
                        .Select(p => new DtExpProProjetOrMissionV2
                        {
                            NomClient = p.NomClientOrProjet,
                            DateDebutDateFin = p.DateDebut.HasValue && p.DateFin.HasValue
                                ? $"Début : {p.DateDebut:MM/yyyy} --> Fin : {p.DateFin:MM/yyyy}"
                                : p.DateDebut.HasValue
                                    ? $"Début : {p.DateDebut:MM/yyyy}"
                                    : p.DateFin.HasValue
                                        ? $"Fin : {p.DateFin:MM/yyyy}"
                                        : string.Empty,
                            DomaineMetierClient = p.DomaineMetier?.Libelle,
                            
                            Lieu = p.Lieu,
                            Context = p.DescriptionProjetOrMission,
                            Taches = string.Join(", ", p.Taches.Split('\n')
                                          .Select(t => t.Trim())
                                          .Where(t => !string.IsNullOrEmpty(t))),
                            CompoEquipe = p.CompositionEquipe,
                            Competences = string.Join(", ", p.LiaisonProjetCompetences?.Select(lo => lo.Competence?.Libelle)),
                            Methodologies = string.Join(", ", p.LiaisonProjetMethodologies?.Select(lo => lo.Methodologie?.Libelle)),
                            EnvironnementsTechnique = string.Join(", ",
                            p.LiaisonProjetTechnologies?.Select(lt => lt.Technologie?.Libelle) ?? Enumerable.Empty<string>()
                                .Concat(p.LiaisonProjetOutils?.Select(lo => lo.Outil?.Libelle) ?? Enumerable.Empty<string>()))

                        }).ToList()
                }).ToList();
        }


        private List<DtQuestionDso> GetQuestionToShowInDt(DossierTechnique dt)
        {
            return dt.QuestionDossierTechniques.Where(x => x.IsShowDt)
                             .Select(x => new DtQuestionDso()
                             {
                                 Question = x.Question,
                                 Reponse = x.Reponse,
                             }).ToList();
        }


    }
}
