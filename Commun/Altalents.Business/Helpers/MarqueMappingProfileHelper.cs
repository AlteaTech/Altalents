namespace Altalents.Business.Helpers
{
    internal static class MarqueMappingProfileHelper
    {
        internal static IMappingExpression<Marque, T> MappingMarqueBase<T>(this IMappingExpression<Marque, T> mapping) where T : MarqueDtoBase
        {
            return mapping
                .ForMember(dest => dest.ReferenceLugt, opt => opt.MapFrom(src => src.ReferenceLugt))
                .ForMember(dest => dest.NumeroLugt, opt => opt.MapFrom(src => src.NumeroLugt))
                .ForMember(dest => dest.IdMarque, opt => opt.MapFrom(src => src.Id));
        }

        internal static IMappingExpression<Marque, T> MappingIndexMarqueDtoBase<T>(this IMappingExpression<Marque, T> mapping) where T : IndexMarqueDtoBase
        {
            return mapping
                .MappingMarqueBase()
                .ForMember(dest => dest.Initiales, opt => opt.MapFrom(src => src.Initiales))
                .ForMember(dest => dest.IsFinalize, opt => opt.MapFrom(src => src.IsFinalize));
        }
    }
}
