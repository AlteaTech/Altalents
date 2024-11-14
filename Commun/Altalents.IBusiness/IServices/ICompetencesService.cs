using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altalents.IBusiness.DTO.Request;

namespace Altalents.IBusiness.IServices
{
    public interface ICompetencesService : IInjectableService
    {

        Task<List<CompetenceDto>> GetLiaisonCandidatByTypeAsync(Guid tokenRapide, string typeLiaisonCode, CancellationToken cancellationToken);

        Task UpdateNiveauLiaisonAsync(LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken);
    }
}
