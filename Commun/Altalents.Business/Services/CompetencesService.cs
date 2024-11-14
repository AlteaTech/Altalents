using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Altalents.Business.Extensions;
using Altalents.Commun.Enums;
using Altalents.Commun.Settings;
using Altalents.IBusiness.DTO.Request;
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
            using CustomDbContext context = GetScopedDbContexte();
            return await context.GetLiaisonCandidatByTypeAsync(Mapper, tokenRapide, typeLiaisonCode, cancellationToken);
        }


        public async Task UpdateNiveauLiaisonAsync(LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken)
        {

            TypeLiaisonEnum typeLiaisonEnum = (TypeLiaisonEnum)Enum.Parse(typeof(TypeLiaisonEnum), request.TypeLiaisonCode);

            using CustomDbContext context = GetScopedDbContexte();

            switch (typeLiaisonEnum)
            {
                case TypeLiaisonEnum.Competence:

                    LiaisonExperienceCompetence liaisonCompetence = await context.LiaisonExperienceCompetences.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonCompetence.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Methodologie:

                    LiaisonExperienceMethodologie liaisonMethodo = await context.LiaisonExperienceMethodologies.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonMethodo.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Outil:

                    LiaisonExperienceOutil liaisonOutil = await context.LiaisonExperienceOutils.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonOutil.Niveau = request.Note;
                    break;

                case TypeLiaisonEnum.Technologie:

                    LiaisonExperienceTechnologie liaisonTechno = await context.LiaisonExperienceTechnologies.AsTracking().SingleAsync(x => x.Id == request.LiaisonId, cancellationToken);
                    liaisonTechno.Niveau = request.Note;
                    break;

                default:
                    break;

            }

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);

        }
    }
}
