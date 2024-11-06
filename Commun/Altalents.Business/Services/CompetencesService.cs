using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Altalents.Commun.Enums;
using Altalents.Commun.Settings;
using Altalents.IBusiness.DTO.Requesst;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.X509.Qualified;
using static System.Net.Mime.MediaTypeNames;

namespace Altalents.Business.Services
{
    public class CompetencesService : BaseAppService<CustomDbContext>, ICompetencesService
    {

  

        public CompetencesService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider) : base(logger, contexte, mapper, serviceProvider)
        {
  
        }

        public async Task<List<CompetenceDto>> GetLiaisonCandidatByTypeAsync(Guid tokenRapide, string typeLiaisonCode, CancellationToken cancellationToken)
        {

            TypeLiaisonEnum typeLiaisonEnum = (TypeLiaisonEnum)Enum.Parse(typeof(TypeLiaisonEnum), typeLiaisonCode);


            switch (typeLiaisonEnum)
            {
                case TypeLiaisonEnum.Competence:

                    List<LiaisonExperienceCompetence> competences = await DbContext.LiaisonExperienceCompetences.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                     .Include(x => x.Competance)
                                     .GroupBy(e => e.CompetenceId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);

                    return Mapper.Map<List<CompetenceDto>>(competences);


                case TypeLiaisonEnum.Methodologie:

                    List<LiaisonExperienceMethodologie> methodologies = await DbContext.LiaisonExperienceMethodologies.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                     .Include(x => x.Methodologie)
                                     .GroupBy(e => e.MethodologieId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);

                    return Mapper.Map<List<CompetenceDto>>(methodologies);


                case TypeLiaisonEnum.Outil:

                    List<LiaisonExperienceOutil> Outils = await DbContext.LiaisonExperienceOutils.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                    .Include(x => x.Outil)
                                     .GroupBy(e => e.OutilId)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);

                    return Mapper.Map<List<CompetenceDto>>(Outils);


                case TypeLiaisonEnum.Technologie:

                    List<LiaisonExperienceTechnologie> technologies = await DbContext.LiaisonExperienceTechnologies.Where(x => x.Experience.DossierTechnique.TokenAccesRapide == tokenRapide)
                                    .Include(x => x.Technologie)
                                     .GroupBy(e => e.Technologie)
                                     .Select(g => g.OrderByDescending(e => e.Niveau).First())
                                     .ToListAsync(cancellationToken);

                    return Mapper.Map<List<CompetenceDto>>(technologies);


                default:
                    return new List<CompetenceDto>();
            }

            
        }




        public async Task UpdateNiveauLiaisonAsync(LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken)
        {

            TypeLiaisonEnum typeLiaisonEnum = (TypeLiaisonEnum)Enum.Parse(typeof(TypeLiaisonEnum), request.TypeLiaisonCode);

            switch (typeLiaisonEnum)
            {
                case TypeLiaisonEnum.Competence:

                    LiaisonExperienceCompetence liaisonCompetence = await DbContext.LiaisonExperienceCompetences.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonCompetence.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Methodologie:

                    LiaisonExperienceMethodologie liaisonMethodo = await DbContext.LiaisonExperienceMethodologies.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonMethodo.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Outil:

                    LiaisonExperienceOutil liaisonOutil = await DbContext.LiaisonExperienceOutils.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonOutil.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Technologie:

                    LiaisonExperienceTechnologie liaisonTechno = await DbContext.LiaisonExperienceTechnologies.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonTechno.Niveau = request.Note;
                    break;

                default:
                    break;

            }

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);




        }


    }
}
