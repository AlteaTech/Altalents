using Altalent.ReportLibrary.DSO;

using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.Business.Mappings
{
    internal class ReportingMappingProfile : Profile
    {

        public ReportingMappingProfile()
        {
            CreateMap<DossierTechnique, DossierCompetenceDso>()
                .ForMember(dest => dest.NumeroDt, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.Trigrame, opt => opt.MapFrom(src => src.Personne.Trigramme))
                ;

            CreateMap<Experience, ExperienceDso>()
                                .ForMember(dest => dest.IntitulePoste, opt => opt.MapFrom(src => src.IntitulePoste))
                                ;


        }
    }
}
