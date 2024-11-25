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
                .ForMember(dest => dest.Trigrame, opt => opt.MapFrom(src => src.Personne.Trigramme));

            CreateMap<DossierTechnique, DossierCompetenceDso>()
                .ForMember(dest => dest.NumeroDt, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Commercial, opt => opt.Ignore())
                .ForMember(dest => dest.Poste, opt => opt.MapFrom(src => src.Poste))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.Trigrame, opt => opt.MapFrom(src => src.Personne.Trigramme));

            CreateMap<Experience, ExperienceDso>()
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.LiaisonExperienceTechnologies))
                .ForMember(dest => dest.Methodologies, opt => opt.MapFrom(src => src.LiaisonExperienceMethodologies))
                .ForMember(dest => dest.Competences, opt => opt.MapFrom(src => src.LiaisonExperienceCompetences))
                .ForMember(dest => dest.IntitulePoste, opt => opt.MapFrom(src => src.IntitulePoste))
                .ForMember(dest => dest.Entreprise, opt => opt.MapFrom(src => src.NomEntreprise));

            CreateMap<LiaisonExperienceTechnologie, ConnaissanceDso>()
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Technologie.Libelle));

            CreateMap<LiaisonExperienceMethodologie, ConnaissanceDso>()
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Methodologie.Libelle));

            CreateMap<LiaisonExperienceCompetence, ConnaissanceDso>()
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau))
                .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Competance.Libelle));
        }
    }
}
