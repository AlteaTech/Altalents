using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.Business.Mappings
{
    internal class DossiersTechniquesMappingProfile : Profile
    {

        public DossiersTechniquesMappingProfile()
        {
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
                .ForMember(dest => dest.Entreprise, opt => opt.MapFrom(src => src.Entreprise))
                .ForMember(dest => dest.Lieu, opt => opt.MapFrom(src => src.Lieu))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DomaineMetier, opt => opt.MapFrom(src => src.DomaineMetier))
                .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
                .ForMember(dest => dest.TypeContratId, opt => opt.MapFrom(src => src.TypeContratId))
                .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
                .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
                .ForMember(dest => dest.ClientFinal, opt => opt.MapFrom(src => src.ClientFinal))
                .ForMember(dest => dest.LiaisonExperienceTechnologies, opt => opt.MapFrom(src => src.TechnologieIds.Select(x => new LiaisonExperienceTechnologie()
                {
                    TechnologieId = x,
                }).ToList()
                ))
                .ForMember(dest => dest.LiaisonExperienceCompetences, opt => opt.MapFrom(src => src.CompetenceIds.Select(x => new LiaisonExperienceCompetence()
                {
                    CompetenceId = x,
                }).ToList()
                ))
                .ForMember(dest => dest.LiaisonExperienceMethodologies, opt => opt.MapFrom(src => src.MethodologieIds.Select(x => new LiaisonExperienceMethodologie()
                {
                    MethodologieId = x,
                }).ToList()
                ))
                .ForMember(dest => dest.LiaisonExperienceOutils, opt => opt.MapFrom(src => src.OutilIds.Select(x => new LiaisonExperienceOutil()
                {
                    OutilId = x,
                }).ToList()
                ));

            CreateMap<Experience, ExperienceDto>()
                .ForMember(dest => dest.IntitulePoste, opt => opt.MapFrom(src => src.IntitulePoste))
                .ForMember(dest => dest.Entreprise, opt => opt.MapFrom(src => src.Entreprise))
                .ForMember(dest => dest.Lieu, opt => opt.MapFrom(src => src.Lieu))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DomaineMetier, opt => opt.MapFrom(src => src.DomaineMetier))
                .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
                .ForMember(dest => dest.TypeContrat, opt => opt.MapFrom(src => src.TypeContrat))
                .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
                .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
                .ForMember(dest => dest.ClientFinal, opt => opt.MapFrom(src => src.ClientFinal))
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.LiaisonExperienceTechnologies.Select(x => x.Technologie)))
                .ForMember(dest => dest.Competences, opt => opt.MapFrom(src => src.LiaisonExperienceCompetences.Select(x => x.Competance)))
                .ForMember(dest => dest.Methodologies, opt => opt.MapFrom(src => src.LiaisonExperienceMethodologies.Select(x => x.Methodologie)));

            CreateMap<Certification, FormationCertificationDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Domaine, opt => opt.MapFrom(src => src.Domaine))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<Formation, FormationCertificationDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Domaine, opt => opt.MapFrom(src => src.Domaine))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<DossierTechniqueLangue, LangueParleeDto>()
                .ForMember(dest => dest.DossierTechniqueLangueId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
                .ForMember(dest => dest.LibelleLangue, opt => opt.MapFrom(src => src.Langue.Libelle))
                .ForMember(dest => dest.IdLangue, opt => opt.MapFrom(src => src.LangueId));

            CreateMap<PostFormationCertificationRequestDto, Certification>()
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Domaine, opt => opt.MapFrom(src => src.Domaine))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<PostFormationCertificationRequestDto, Formation>()
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
              .ForMember(dest => dest.DateDebut, opt => opt.MapFrom(src => src.DateDebut))
              .ForMember(dest => dest.DateFin, opt => opt.MapFrom(src => src.DateFin))
              .ForMember(dest => dest.Domaine, opt => opt.MapFrom(src => src.Domaine))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
              .ForMember(dest => dest.Organisme, opt => opt.MapFrom(src => src.Organisme));

            CreateMap<PostLangueParleeRequestDto, DossierTechniqueLangue>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DossierTechniqueLangueId))
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
                .ForMember(dest => dest.LangueId, opt => opt.MapFrom(src => src.LangueId));

        }
    }
}
