using Altalents.IBusiness.Enums;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SousReferencesController : Controller
    {
        private readonly ISousReferenceService _sousReferenceService;

        public SousReferencesController(ISousReferenceService sousReferenceService)
        {
            _sousReferenceService = sousReferenceService;
        }

        [HttpGet("{langue}/{referenceId}", Name = "GetSousReferenceByLangueByReferenceId")]
        public async Task<List<SousReferenceByLangueDto>> GetSousReferenceByLangueByReferenceIdAsync([FromRoute] EnumLangue langue, [FromRoute] Guid referenceId, CancellationToken cancellationToken)
        {
            return await _sousReferenceService.GetSousReferenceByLangueByReferenceIdAsync(referenceId, langue, cancellationToken);
        }

        [HttpGet("{langue}/{sousReferenceId}/libelle", Name = "GetLibelleByLangueBySousReferenceIdAsync")]
        public async Task<LibelleDto> GetLibelleByLangueBySousReferenceIdAsync([FromRoute] EnumLangue langue, [FromRoute] Guid sousReferenceId, CancellationToken cancellationToken)
        {
            return new LibelleDto()
            {
                Libelle = await _sousReferenceService.GetLibelleByLangueBySousReferenceIdAsync(langue, sousReferenceId, cancellationToken)
            };
        }
    }
}
