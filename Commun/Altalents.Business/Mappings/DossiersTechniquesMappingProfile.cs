using Altalents.IBusiness.DTO.Request;

namespace Altalents.Business.Mappings
{
    internal class DossiersTechniquesMappingProfile : Profile
    {
        public DossiersTechniquesMappingProfile()
        {



            CreateMap<DossierTechnique, DossierTechniqueForAdminDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumeroDt, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.IdBoond, opt => opt.MapFrom(src => src.Personne.BoondId))
                .ForMember(dest => dest.NomCandidat, opt => opt.MapFrom(src => src.Personne.Nom))
                .ForMember(dest => dest.PrenomCandidat, opt => opt.MapFrom(src => src.Personne.Prenom))
                .ForMember(dest => dest.PosteVoulu, opt => opt.MapFrom(src => src.Poste))
                .ForMember(dest => dest.DateCrea, opt => opt.MapFrom(src => src.DateCrea))
                .ForMember(dest => dest.DateUpdate, opt => opt.MapFrom(src => src.DateMaj))
                .ForMember(dest => dest.Statut, opt => opt.MapFrom(src => src.Statut.Libelle))
                .ForMember(dest => dest.StatutCode, opt => opt.MapFrom(src => src.Statut.Code))
                .ForMember(dest => dest.Commercial, opt => opt.MapFrom(src => src.Commercial.Nom))
                .ForMember(dest => dest.TokenAccesRapide, opt => opt.MapFrom(src => src.TokenAccesRapide));

            CreateMap<DossierTechniqueInsertRequestDto, DossierTechnique>()
                .ForMember(dest => dest.Personne, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TokenAccesRapide, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PrixJour, opt => opt.MapFrom(src => src.TarifJournalier))
                .ForMember(dest => dest.Poste, opt => opt.MapFrom(src => src.Poste))
                .ForMember(dest => dest.DisponibiliteId, opt => opt.MapFrom(src => src.DisponibiliteId))
                .ForMember(dest => dest.DocumentComplementaires, opt => opt.Ignore())
                .ForMember(dest => dest.StatutId, opt => opt.MapFrom(src => Guid.Parse(IdsConstantes.StatutDtCreeId)))
                .ForMember(dest => dest.CommercialId, opt => opt.MapFrom(src => src.UtilisateurId));

            CreateMap<QuestionInsertDto, QuestionDossierTechnique>()
                                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.Ordre))
                                .ForMember(dest => dest.IsShowDt, opt => opt.MapFrom(src => src.IsShowDt))
                                .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.IsObligatoire))
                                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question));

            CreateMap<QuestionDossierTechnique, QuestionnaireDto>()
                                .ForMember(dest => dest.IsObligatoire, opt => opt.MapFrom(src => src.IsRequired))
                                .ForMember(dest => dest.Reponse, opt => opt.MapFrom(src => src.Reponse))
                                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Reference, ReferenceDto>()
                .ForMember(dest => dest.CommentaireFun, opt => opt.MapFrom(src => src.CommentaireFun))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle));

             CreateMap<ProjetOrMissionClient, ProjetOrMissionClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomClientOrProjet, opt => opt.MapFrom(src => src.NomClientOrProjet))
                .ForMember(dest => dest.DescriptionProjetOrMission, opt => opt.MapFrom(src => src.DescriptionProjetOrMission))
                .ForMember(dest => dest.Taches, opt => opt.MapFrom(src => src.Taches))
                .ForMember(dest => dest.Lieu, opt => opt.MapFrom(src => src.Lieu))
                .ForMember(dest => dest.DomaineMetier, opt => opt.MapFrom(src => src.DomaineMetier))
                .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
                .ForMember(dest => dest.CompositionEquipe, opt => opt.MapFrom(src => src.CompositionEquipe))
                .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
                .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.LiaisonProjetTechnologies.Select(x => x.Technologie)))
                .ForMember(dest => dest.Competences, opt => opt.MapFrom(src => src.LiaisonProjetCompetences.Select(x => x.Competence)))
                .ForMember(dest => dest.Methodologies, opt => opt.MapFrom(src => src.LiaisonProjetMethodologies.Select(x => x.Methodologie)))
                .ForMember(dest => dest.Outils, opt => opt.MapFrom(src => src.LiaisonProjetOutils.Select(x => x.Outil)))
                ;

            CreateMap<ProjetOrMissionClientRequestDto, ProjetOrMissionClient>()
                .ForMember(dest => dest.NomClientOrProjet, opt => opt.MapFrom(src => src.NomClientOrProjet))
                .ForMember(dest => dest.DescriptionProjetOrMission, opt => opt.MapFrom(src => src.DescriptionProjetOrMission))
                .ForMember(dest => dest.Taches, opt => opt.MapFrom(src => src.Taches))
                .ForMember(dest => dest.Lieu, opt => opt.MapFrom(src => src.Lieu))
                .ForMember(dest => dest.DomaineMetierId, opt => opt.MapFrom(src => src.DomaineMetierId))
                .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
                .ForMember(dest => dest.CompositionEquipe, opt => opt.MapFrom(src => src.CompositionEquipe))
                .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
                .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
                .ForMember(dest => dest.LiaisonProjetTechnologies, opt => opt.MapFrom(src => src.TechnologieIds.Select(x => new LiaisonProjetTechnologie()
                {
                    TechnologieId = x,
                }).ToList()
                ))
                .ForMember(dest => dest.LiaisonProjetCompetences, opt => opt.MapFrom(src => src.CompetenceIds.Select(x => new LiaisonProjetCompetence()
                {
                    CompetenceId = x,
                }).ToList()
                ))
                .ForMember(dest => dest.LiaisonProjetMethodologies, opt => opt.MapFrom(src => src.MethodologieIds.Select(x => new LiaisonProjetMethodologie()
                {
                    MethodologieId = x,
                }).ToList()
                ))
                .ForMember(dest => dest.LiaisonProjetOutils, opt => opt.MapFrom(src => src.OutilIds.Select(x => new LiaisonProjetOutil()
                {
                    OutilId = x,
                }).ToList()
                  ))
                ;
            
            CreateMap<DossierTechniqueInsertRequestDto, Personne>()
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
                .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
                .ForMember(dest => dest.Trigramme, opt => opt.MapFrom(src => src.Trigramme.ToLower()))
                .ForMember(dest => dest.BoondId, opt => opt.MapFrom(src => src.IdBoond))
                .ForMember(dest => dest.Documents, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AdresseMail.ToLower().Trim()))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => Guid.Parse(IdsConstantes.TypePersonneCandidatId)))
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => new List<Contact>
                {
                    new()
                    {
                        TypeId = Guid.Parse(IdsConstantes.ContactTelephoneId),
                        Valeur = src.Telephone,
                    }
                }));

            CreateMap<ExperienceRequestDto, Experience>()
                .ForMember(dest => dest.IntitulePoste, opt => opt.MapFrom(src => src.IntitulePoste))
                .ForMember(dest => dest.NomEntreprise, opt => opt.MapFrom(src => src.Entreprise))
                .ForMember(dest => dest.LieuEntreprise, opt => opt.MapFrom(src => src.Lieu))
                .ForMember(dest => dest.DomaineMetierId, opt => opt.MapFrom(src => src.DomaineMetierId))
                .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
                .ForMember(dest => dest.TypeContratId, opt => opt.MapFrom(src => src.TypeContratId))
                .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
                .ForMember(dest => dest.IsEntrepriseEsnOrInterim, opt => opt.MapFrom(src => src.IsEntrepriseEsnOrInterim))
                .ForMember(dest => dest.ProjetsOrMissionsClient, opt => opt.MapFrom(src => src.ProjetsOrMissionsClient)
                 );

            CreateMap<Experience, ExperienceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IntitulePoste, opt => opt.MapFrom(src => src.IntitulePoste))
                .ForMember(dest => dest.NomEntreprise, opt => opt.MapFrom(src => src.NomEntreprise))
                .ForMember(dest => dest.LieuEntreprise, opt => opt.MapFrom(src => src.LieuEntreprise))
                .ForMember(dest => dest.DomaineMetier, opt => opt.MapFrom(src => src.DomaineMetier))
                .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
                .ForMember(dest => dest.TypeContrat, opt => opt.MapFrom(src => src.TypeContrat))
                .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
                .ForMember(dest => dest.IsEntrepriseEsnOrInterim, opt => opt.MapFrom(src => src.IsEntrepriseEsnOrInterim))
                .ForMember(dest => dest.ProjetsOrMissionsClient, opt => opt.MapFrom(src => src.ProjetsOrMissionsClient));

            CreateMap<Certification, FormationCertificationDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<Formation, FormationCertificationDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<DossierTechniqueLangue, LangueParleeDto>()
                .ForMember(dest => dest.DossierTechniqueLangueId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdReferenceNiveau, opt => opt.MapFrom(src => src.NiveauId))
                .ForMember(dest => dest.LibelleReferenceNiveau, opt => opt.MapFrom(src => src.Niveau.Libelle))
                .ForMember(dest => dest.LibelleLangue, opt => opt.MapFrom(src => src.Langue.Libelle))
                .ForMember(dest => dest.IdLangue, opt => opt.MapFrom(src => src.LangueId));

            CreateMap<FormationCertificationRequestDto, Certification>()
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<FormationCertificationRequestDto, Formation>()
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<LangueParleeRequestDto, DossierTechniqueLangue>()
                .ForMember(dest => dest.NiveauId, opt => opt.MapFrom(src => src.NiveauId))
                .ForMember(dest => dest.LangueId, opt => opt.MapFrom(src => src.LangueId));
        }
    }
}
