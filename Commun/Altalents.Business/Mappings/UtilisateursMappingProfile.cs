namespace Altalents.Business.Mappings
{
    internal class UtilisateursMappingProfile : Profile
    {
        public UtilisateursMappingProfile()
        {
            CreateMap<Utilisateur, UtilisateurDto>()
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.MotDePasse, opt => opt.MapFrom(src => src.MotDePasseCrypte))
                .ForMember(dest => dest.IsModifiable, opt => opt.MapFrom(src => src.IsModifiable))
                .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCrea))
                .ForMember(dest => dest.IsSupprimable, opt => opt.MapFrom(src => src.IsSupprimable))
                .ForMember(dest => dest.IsActif, opt => opt.MapFrom(src => src.IsActif))
                .ForMember(dest => dest.TypeCompteSelected, opt => opt.MapFrom(src => new TypeCompteDto()
                {
                    Value = src.TypeCompte
                }))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UtilisateurDto, Utilisateur>()
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
                .ForMember(dest => dest.Poste, opt => opt.MapFrom(src => src.Poste))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.MotDePasseCrypte, opt => opt.MapFrom(src => src.MotDePasse))
                .ForMember(dest => dest.TypeCompte, opt => opt.MapFrom(src => src.TypeCompteSelected.Value))
                .ForMember(dest => dest.IsModifiable, opt => opt.MapFrom(src => src.IsModifiable))
                .ForMember(dest => dest.DateCrea, opt => opt.MapFrom(src => src.DateCreation))
                .ForMember(dest => dest.IsSupprimable, opt => opt.MapFrom(src => src.IsSupprimable))
                .ForMember(dest => dest.IsActif, opt => opt.MapFrom(src => src.IsActif))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
