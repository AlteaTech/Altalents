namespace Altalents.Business.Mappings
{


    internal class ReferenceMappingProfile : Profile
    {
        public ReferenceMappingProfile()
        {
            CreateMap<Reference, ReferenceAValiderDto>()
                .ForMember(dest => dest.CommentaireFun, opt => opt.MapFrom(src => src.CommentaireFun))
                .ForMember(dest => dest.TypeReference, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
                .ForMember(dest => dest.Validated, opt => opt.MapFrom(src => src.IsValide))
                .ForMember(dest => dest.NbDtAssocie, opt => opt.MapFrom(src => src.LiaisonProjetCompetences.Count() + src.LiaisonProjetMethodologies.Count() + src.LiaisonProjetTechnologies.Count()))
                ;
        }
    }
}
