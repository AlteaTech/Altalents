namespace Altalents.Business.Mappings
{
    internal class CompetenceMappingProfile : Profile
    {
        public CompetenceMappingProfile()
        {
            CreateMap<LiaisonExperienceCompetence, CompetenceDto>()
              .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Competance.Libelle))
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
             ;

            CreateMap<LiaisonExperienceMethodologie, CompetenceDto>()
            .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Methodologie.Libelle))
            .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
           ;

            CreateMap<LiaisonExperienceOutil, CompetenceDto>()
            .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Outil.Libelle))
            .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
           ;

            CreateMap<LiaisonExperienceTechnologie, CompetenceDto>()
            .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Technologie.Libelle))
            .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
           ;
        }
    }
}
