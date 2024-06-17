using Altalents.IBusiness.Enums;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarquesController : Controller
    {
        private readonly IMarqueService _marqueService;

        public MarquesController(IMarqueService marqueService)
        {
            _marqueService = marqueService;
        }

        [HttpGet("{langue}/{marqueId}", Name = "GetMarqueFullById")]
        public async Task<MarqueFullDto> GetMarqueFullByIdAsync([FromRoute] EnumLangue langue, [FromRoute] Guid marqueId, [FromQuery] bool isPrevisualisation, CancellationToken cancellationToken)
        {
            return await _marqueService.GetMarqueFullByIdAsync(langue, marqueId, isPrevisualisation, cancellationToken);
        }

        [HttpPost("{langue}", Name = "GetMarquesRecherche")]
        public async Task<List<MarqueRechercheDto>> GetMarquesRechercheAsync([FromRoute] EnumLangue langue, [FromBody] RechercheRequestDto rechercheRequest, CancellationToken cancellationToken)
        {
            return await _marqueService.GetMarquesRechercheAsync(langue, rechercheRequest, cancellationToken);
        }

        [HttpGet("{langue}/nouveautes", Name = "GetMarquesNouveautes")]
        public async Task<List<MarqueNouveauteDto>> GetMarquesNouveautesAsync([FromRoute] EnumLangue langue, CancellationToken cancellationToken)
        {
            return await _marqueService.GetMarquesNouveautesAsync(langue, cancellationToken);
        }

        [HttpPost("/lugt", Name = "GetLugtsFromAutoComplete")]
        public async Task<List<LugtDto>> GetLugtsFromAutoCompleteAsync([FromBody] string texteAutoComplete, CancellationToken cancellationToken)
        {
            return await _marqueService.GetLugtsFromAutoCompleteAsync(texteAutoComplete, cancellationToken);
        }


        [HttpPost("/oldId", Name = "GetLugtByOldIdAltalents")]
        public async Task<List<LugtDto>> GetLugtByOldIdAltalentsAsync([FromBody] string oldId, CancellationToken cancellationToken)
        {
            return await _marqueService.GetLugtByOldIdAltalentsAsync(oldId, cancellationToken);
        }
    }
}
