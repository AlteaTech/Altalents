using AnyAscii;
using Altalents.Commun.Helpers;

namespace Altalents.Business.Mappings
{
    internal class ReferenceMappingProfile : Profile
    {
        public ReferenceMappingProfile()
        {
            CreateMap<Reference, ReferenceLightDto>()
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Libelle2))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.LibelleFr));

            CreateMap<Reference, NomDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.LibelleFr))
                .ForMember(dest => dest.LibelleTransLit, opt => opt.MapFrom(src => src.LibelleTransLitLowerFr));

            CreateMap<Marque, LugtDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.ReferenceLugt))
                .ForMember(dest => dest.ReferenceLugtLight, opt => opt.MapFrom(src => src.ReferenceLugtLight));

            CreateMap<Reference, ReferenceByLangueDto>()
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Libelle2))
                .ForMember(dest => dest.Ordre2, opt => opt.MapFrom(src => src.Ordre2))
                .ForMember(dest => dest.OrdreFr, opt => opt.MapFrom(src => src.Ordre))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.LibelleFr))
                .ForMember(dest => dest.HasSousReference, opt => opt.MapFrom(src => src.SousReferences.Any()));

            CreateMap<Reference, ReferenceDto>()
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TypeReferenceId, opt => opt.MapFrom(src => src.TypeReferenceId))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Libelle2))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.LibelleFr))
                .ForMember(dest => dest.OrdreFr, opt => opt.MapFrom(src => src.Ordre))
                .ForMember(dest => dest.Ordre2, opt => opt.MapFrom(src => src.Ordre2))
                .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCrea))
                .ForMember(dest => dest.NombreSousReference, opt => opt.MapFrom(src => src.SousReferences.Count))
                .ForMember(dest => dest.NombreMarque, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Select(x => x.MarqueId).Distinct().Count()));

            CreateMap<ReferenceDto, Reference>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ReferenceId))
                .ForMember(dest => dest.TypeReferenceId, opt => opt.MapFrom(src => src.TypeReferenceId))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Libelle2))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.LibelleFr))
                .ForMember(dest => dest.LibelleTransLitLower2, opt => opt.MapFrom(src => StringsHelpers.HtmlToPlainText(src.Libelle2).Transliterate().ToLower()))
                .ForMember(dest => dest.LibelleTransLitLowerFr, opt => opt.MapFrom(src => StringsHelpers.HtmlToPlainText(src.LibelleFr).Transliterate().ToLower()))
                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.OrdreFr))
                .ForMember(dest => dest.Ordre2, opt => opt.MapFrom(src => src.Ordre2))
                .ForMember(dest => dest.DateCrea, opt => opt.MapFrom(src => src.DateCreation));

            CreateMap<TypeReference, TypeReferenceDto>()
                .ForMember(dest => dest.TypeReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.Ordre))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.WithSecondeLangue, opt => opt.MapFrom(src => src.WithSecondeLangue))
                .ForMember(dest => dest.WithSousReference, opt => opt.MapFrom(src => src.WithSousReference));

            CreateMap<TypeReference, TypeReferenceLightDto>()
                .ForMember(dest => dest.TypeReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
                .ForMember(dest => dest.WithSousReference, opt => opt.MapFrom(src => src.WithSousReference));

            CreateMap<SousReference, SousReferenceDto>()
                .ForMember(dest => dest.SousReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.ReferenceId))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Libelle2))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.LibelleFr))
                .ForMember(dest => dest.Ordre2, opt => opt.MapFrom(src => src.Ordre2))
                .ForMember(dest => dest.OrdreFr, opt => opt.MapFrom(src => src.OrdreFr))
                .ForMember(dest => dest.NombreMarque, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Count));

            CreateMap<SousReference, SousReferenceLightDto>()
                .ForMember(dest => dest.SousReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Reference.Libelle2 + " - " + src.Libelle2))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.Reference.LibelleFr + " - " + src.LibelleFr));

            CreateMap<SousReferenceDto, SousReference>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SousReferenceId))
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.ReferenceId))
                .ForMember(dest => dest.Libelle2, opt => opt.MapFrom(src => src.Libelle2))
                .ForMember(dest => dest.LibelleFr, opt => opt.MapFrom(src => src.LibelleFr))
                .ForMember(dest => dest.LibelleTransLitLower2, opt => opt.MapFrom(src => StringsHelpers.HtmlToPlainText(src.Libelle2).Transliterate().ToLower()))
                .ForMember(dest => dest.LibelleTransLitLowerFr, opt => opt.MapFrom(src => StringsHelpers.HtmlToPlainText(src.LibelleFr).Transliterate().ToLower()))
                .ForMember(dest => dest.Ordre2, opt => opt.MapFrom(src => src.Ordre2))
                .ForMember(dest => dest.OrdreFr, opt => opt.MapFrom(src => src.OrdreFr));
        }
    }
}
