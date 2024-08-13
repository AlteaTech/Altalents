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
                .ForMember(dest => dest.StatutId, opt => opt.MapFrom(src => Guid.Parse(IdsConstantes.StatutDtCreeId)))
                .ForMember(dest => dest.CommercialId, opt => opt.MapFrom(src => src.UtilisateurId))
                ;

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
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
                ;

            CreateMap<DossierTechniqueInsertRequestDto, Personne>()
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
                .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
                .ForMember(dest => dest.Trigramme, opt => opt.MapFrom(src => src.Trigramme.ToLower()))
                .ForMember(dest => dest.BoondId, opt => opt.MapFrom(src => src.IdBoond))
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
        }
    }
}
