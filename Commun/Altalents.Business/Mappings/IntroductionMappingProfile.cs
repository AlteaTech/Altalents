namespace Altalents.Business.Mappings
{
    internal class IntroductionMappingProfile : Profile
    {
        public IntroductionMappingProfile()
        {
            CreateMap<Introduction, IntroductionDto>()
                .ForMember(dest => dest.TitreFr, opt => opt.MapFrom(src => src.TitreFr))
                .ForMember(dest => dest.TitreEn, opt => opt.MapFrom(src => src.TitreEn))
                .ForMember(dest => dest.DetailFr, opt => opt.MapFrom(src => src.DetailFr))
                .ForMember(dest => dest.DetailEn, opt => opt.MapFrom(src => src.DetailEn))
                .ForMember(dest => dest.OrdreFr, opt => opt.MapFrom(src => src.OrdreFr))
                .ForMember(dest => dest.OrdreEn, opt => opt.MapFrom(src => src.OrdreEn));

            CreateMap<IntroductionDto, Introduction>()
                .ForMember(dest => dest.TitreFr, opt => opt.MapFrom(src => src.TitreFr))
                .ForMember(dest => dest.TitreEn, opt => opt.MapFrom(src => src.TitreEn))
                .ForMember(dest => dest.DetailFr, opt => opt.MapFrom(src => src.DetailFr))
                .ForMember(dest => dest.DetailEn, opt => opt.MapFrom(src => src.DetailEn))
                .ForMember(dest => dest.OrdreFr, opt => opt.MapFrom(src => src.OrdreFr))
                .ForMember(dest => dest.OrdreEn, opt => opt.MapFrom(src => src.OrdreEn));
        }
    }
}
