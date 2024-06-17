using AlteaTools.Api.Core.Extensions;
using AnyAscii;
using Altalents.Business.Helpers;
using Altalents.Commun.Helpers;
using Altalents.Entities.Enum;

namespace Altalents.Business.Mappings
{
    internal class MarqueMappingProfile : Profile
    {
        public static Guid TypeReferenceNomId = EnumTypeReference.Nom.GetBddId();
        public static Guid TypeReferencePaysId = EnumTypeReference.Pays.GetBddId();

        public MarqueMappingProfile()
        {
            CreateMap<MarqueImage, ImageDto>()
                .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomFichier, opt => opt.MapFrom(src => src.NomFichier))
                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.Ordre));

            CreateMap<MarqueImage, ImageLightDto>()
                .ForMember(dest => dest.NomFichier, opt => opt.MapFrom(src => src.NomFichier))
                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.Ordre));

            CreateMap<MarqueNotice, NoticeMarqueDto>()
                .ForMember(dest => dest.Texte, opt => opt.MapFrom(src => src.Texte))
                .ForMember(dest => dest.MarqueId, opt => opt.MapFrom(src => src.MarqueId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OngletName, opt => opt.MapFrom(src => src.OngletNoticeMarque.Libelle))
                .ForMember(dest => dest.OngletOrdre, opt => opt.MapFrom(src => src.OngletNoticeMarque.Ordre))
                .ForMember(dest => dest.IsPublie, opt => opt.MapFrom(src => src.IsPublie));

            CreateMap<MarqueNotice, NoticeMarqueLightDto>()
                .ForMember(dest => dest.Titre, opt => opt.MapFrom(src => src.OngletNoticeMarque.Libelle))
                .ForMember(dest => dest.Texte, opt => opt.MapFrom(src => src.Texte))
                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.OngletNoticeMarque.Ordre));

            CreateMap<Marque, IndexMarqueDto>()
                .MappingIndexMarqueDtoBase()
                .ForMember(dest => dest.Largeur, opt => opt.MapFrom(src => src.Largeur))
                .ForMember(dest => dest.Hauteur, opt => opt.MapFrom(src => src.Hauteur));

            CreateMap<Marque, IndexMarqueDtoBase>().MappingIndexMarqueDtoBase();

            CreateMap<Marque, MarqueDtoBase>().MappingMarqueBase();
            CreateMap<Marque, MarqueLightDto>().MappingMarqueBase()
                .ForMember(dest => dest.NombreRenvois, opt => opt.MapFrom(src => src.MarqueRenvois1.Count))
                .ForMember(dest => dest.NomPrincipalLibelleFr, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.IsPrincipal)
                                                                                                                    .Where(x => x.Reference.TypeReferenceId == TypeReferenceNomId)
                                                                                                                    .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                                    .FirstOrDefault()));

            CreateMap<OngletNoticeMarqueDto, OngletNoticeMarque>()
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle))
                .ForMember(dest => dest.Ordre, opt => opt.MapFrom(src => src.Ordre));

            CreateMap<MarqueReferenceLibre, MarqueReferenceLibreDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdMarque, opt => opt.MapFrom(src => src.MarqueId))
                .ForMember(dest => dest.Texte, opt => opt.MapFrom(src => src.Texte))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<MarqueReferenceLibreDto, MarqueReferenceLibre>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MarqueId, opt => opt.MapFrom(src => src.IdMarque))
                .ForMember(dest => dest.Texte, opt => opt.MapFrom(src => src.Texte))
                .ForMember(dest => dest.TexteTransLitLowerFr, opt => opt.MapFrom(src => StringsHelpers.HtmlToPlainText(src.Texte).Transliterate().ToLower()))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<Marque, MarqueFullDto>()
                .ForMember(dest => dest.IdMarque, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReferenceLugt, opt => opt.MapFrom(src => src.ReferenceLugtLight))
                .ForMember(dest => dest.Hauteur, opt => opt.MapFrom(src => src.Hauteur))
                .ForMember(dest => dest.Largeur, opt => opt.MapFrom(src => src.Largeur))
                .ForMember(dest => dest.Initiales, opt => opt.MapFrom(src => src.Initiales));

            CreateMap<Marque, MarqueRechercheDto>()
                .ForMember(dest => dest.IdMarque, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Initiales, opt => opt.MapFrom(src => src.Initiales))
                .ForMember(dest => dest.PathImagePrincipale, opt => opt.MapFrom(src => src.Images.OrderBy(x => x.Ordre).Select(x => x.NomFichier).FirstOrDefault()))
                .ForMember(dest => dest.ReferenceLugt, opt => opt.MapFrom(src => src.ReferenceLugtLight))
                .ForMember(dest => dest.ReferenceLugtFull, opt => opt.MapFrom(src => src.ReferenceLugt))
                .ForMember(dest => dest.NomPrincipal, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.IsPrincipal)
                                                                                                                 .Where(x => x.Reference.TypeReferenceId == TypeReferenceNomId)
                                                                                                                 .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                                 .FirstOrDefault()));

            CreateMap<Marque, MarqueNouveauteDto>()
                .ForMember(dest => dest.IdMarque, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PathImagePrincipale, opt => opt.MapFrom(src => src.Images.OrderBy(x => x.Ordre).Select(x => x.NomFichier).FirstOrDefault()))
                .ForMember(dest => dest.ReferenceLugt, opt => opt.MapFrom(src => src.ReferenceLugtLight))
                .ForMember(dest => dest.ReferenceLugtFull, opt => opt.MapFrom(src => src.ReferenceLugt))
                .ForMember(dest => dest.NomPrincipal, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.IsPrincipal)
                                                                                                                 .Where(x => x.Reference.TypeReferenceId == TypeReferenceNomId)
                                                                                                                 .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                                 .FirstOrDefault()));
            CreateMap<Marque, MarqueNonPublieDto>()
                .ForMember(dest => dest.IdMarque, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReferenceLugt, opt => opt.MapFrom(src => src.ReferenceLugt))
                .ForMember(dest => dest.ReferenceLugtFull, opt => opt.MapFrom(src => src.ReferenceLugt))
                .ForMember(dest => dest.NomPrincipal, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.IsPrincipal)
                                                                                                                 .Where(x => x.Reference.TypeReferenceId == TypeReferenceNomId)
                                                                                                                 .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                                 .FirstOrDefault()));

            CreateMap<Marque, MarqueExportDto>()
                .ForMember(dest => dest.MarqueId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReferenceLugtLight, opt => opt.MapFrom(src => src.ReferenceLugtLight))
                .ForMember(dest => dest.NomPrincipal, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.IsPrincipal)
                                                                                                                 .Where(x => x.Reference.TypeReferenceId == TypeReferenceNomId)
                                                                                                                 .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                                 .FirstOrDefault()));

            CreateMap<Marque, MarquePublicationDto>()
                .ForMember(dest => dest.MarqueId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReferenceLugtLight, opt => opt.MapFrom(src => src.ReferenceLugtLight))
                .ForMember(dest => dest.NomPrincipal, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.IsPrincipal)
                                                                                                                 .Where(x => x.Reference.TypeReferenceId == TypeReferenceNomId)
                                                                                                                 .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                                 .FirstOrDefault()))
                .ForMember(dest => dest.Pays, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.Reference.TypeReferenceId == TypeReferencePaysId)
                                                                                                         .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                                                         .FirstOrDefault()))
                .ForMember(dest => dest.Ville, opt => opt.MapFrom(src => src.MarqueSousReferenceReferences.Where(x => x.Reference.TypeReferenceId == TypeReferencePaysId)
                                                                                                          .Select(x => x.SousReference == null ? "" : x.SousReference.LibelleFr)
                                                                                                          .FirstOrDefault()));
        }
    }
}
