namespace Altalents.Business.Mappings
{
    internal class TexteDiversMappingProfile : Profile
    {
        public TexteDiversMappingProfile()
        {
            CreateMap<TexteDivers, TexteDiversDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TitreFr, opt => opt.MapFrom(src => src.TitreFr))
                .ForMember(dest => dest.TitreEn, opt => opt.MapFrom(src => src.TitreEn))
                .ForMember(dest => dest.DetailFr, opt => opt.MapFrom(src => src.DetailFr))
                .ForMember(dest => dest.DetailEn, opt => opt.MapFrom(src => src.DetailEn))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<TexteDiversDto, TexteDivers>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TitreFr, opt => opt.MapFrom(src => src.TitreFr))
                .ForMember(dest => dest.TitreEn, opt => opt.MapFrom(src => src.TitreEn))
                .ForMember(dest => dest.DetailFr, opt => opt.MapFrom(src => src.DetailFr))
                .ForMember(dest => dest.DetailEn, opt => opt.MapFrom(src => src.DetailEn))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
