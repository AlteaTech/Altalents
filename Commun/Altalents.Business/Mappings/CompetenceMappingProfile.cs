namespace Altalents.Business.Mappings
{
    internal class CompetenceMappingProfile : Profile
    {
        public CompetenceMappingProfile()
        {
            CreateMap<LiaisonProjetCompetence, CompetenceDto>()
              .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Competence.Libelle))
              .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
             ;

            CreateMap<LiaisonProjetMethodologie, CompetenceDto>()
            .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Methodologie.Libelle))
            .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
           ;

            CreateMap<LiaisonProjetOutil, CompetenceDto>()
            .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Outil.Libelle))
            .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
           ;

            CreateMap<LiaisonProjetTechnologie, CompetenceDto>()
            .ForMember(dest => dest.IdLiaison, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Technologie.Libelle))
            .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
           ;
        }
    }
}
