using Altalents.Report.Library.DSO;

namespace Altalents.Business.Mappings
{
    internal class ReportingMappingProfile : Profile
    {

        public ReportingMappingProfile()
        {
            CreateMap<DossierTechnique, DossierCompetenceDso>()
                .ForMember(dest => dest.NumeroDt, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Poste, opt => opt.MapFrom(src => src.Poste))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.Trigrame, opt => opt.MapFrom(src => src.Personne.Trigramme))
                ;

            CreateMap<DossierTechnique, DossierCompetenceDso>()
                .ForMember(dest => dest.NumeroDt, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Commercial, opt => opt.Ignore())
                .ForMember(dest => dest.Poste, opt => opt.MapFrom(src => src.Poste))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.Trigrame, opt => opt.MapFrom(src => src.Personne.Trigramme))
                ;

            CreateMap<Experience, ExperienceDso>()
                                .ForMember(dest => dest.IntitulePoste, opt => opt.MapFrom(src => src.IntitulePoste))
                                ;


        }
    }
}
