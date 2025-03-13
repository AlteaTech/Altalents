using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altalents.Commun.Enums;

namespace Altalents.Business.Extensions
{
    public static class CustomDbContextExtension
    {
        //public static async Task<List<CompetenceDto>> GetLiaisonCandidatByTypeAsync(this CustomDbContext context, IMapper mapper,Guid tokenRapide, string typeLiaisonCode, CancellationToken cancellationToken)
        //{
        //    TypeLiaisonEnum typeLiaisonEnum = (TypeLiaisonEnum)Enum.Parse(typeof(TypeLiaisonEnum), typeLiaisonCode);
        //    switch (typeLiaisonEnum)
        //    {
        //        case TypeLiaisonEnum.Competence:

        //            List<LiaisonExperienceCompetence> competences = await context.LiaisonExperienceCompetences.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
        //                             .Include(x => x.Competance)
        //                             .GroupBy(e => e.CompetenceId)
        //                             .Select(g => g.OrderByDescending(e => e.Niveau).First())
        //                             .ToListAsync(cancellationToken);

        //            return mapper.Map<List<CompetenceDto>>(competences);


        //        case TypeLiaisonEnum.Methodologie:

        //            List<LiaisonExperienceMethodologie> methodologies = await context.LiaisonExperienceMethodologies.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
        //                             .Include(x => x.Methodologie)
        //                             .GroupBy(e => e.MethodologieId)
        //                             .Select(g => g.OrderByDescending(e => e.Niveau).First())
        //                             .ToListAsync(cancellationToken);

        //            return mapper.Map<List<CompetenceDto>>(methodologies);


        //        case TypeLiaisonEnum.Outil:

        //            List<LiaisonExperienceOutil> Outils = await context.LiaisonExperienceOutils.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
        //                             .Include(x => x.Outil)
        //                             .GroupBy(e => e.OutilId)
        //                             .Select(g => g.OrderByDescending(e => e.Niveau).First())
        //                             .ToListAsync(cancellationToken);

        //            return mapper.Map<List<CompetenceDto>>(Outils);


        //        case TypeLiaisonEnum.Technologie:

        //            List<LiaisonExperienceTechnologie> technologies = await context.LiaisonExperienceTechnologies.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
        //                            .Include(x => x.Technologie)
        //                             .GroupBy(e => e.TechnologieId)
        //                             .Select(g => g.OrderByDescending(e => e.Niveau).First())
        //                             .ToListAsync(cancellationToken);

        //            return mapper.Map<List<CompetenceDto>>(technologies);


        //        default:
        //            return new List<CompetenceDto>();
        //    }
        //}

    }
}
