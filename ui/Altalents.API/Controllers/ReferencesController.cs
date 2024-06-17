using Altalents.IBusiness.DTO.Api;
using Altalents.IBusiness.Enums;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferencesController : Controller
    {
        private readonly IReferenceService _referenceService;

        public ReferencesController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        [HttpGet("{langue}/{typeReferenceId}", Name = "GetReferenceByLangueByTypeReferenceId")]
        public async Task<List<ReferenceByLangueDto>> GetReferenceByLangueByTypeReferenceIdAsync([FromRoute] EnumLangue langue, [FromRoute] Guid typeReferenceId, CancellationToken cancellationToken)
        {
            return await _referenceService.GetReferenceByLangueByTypeReferenceIdAsync(typeReferenceId, langue, cancellationToken);
        }

        [HttpPost("/noms", Name = "GetNomsFromAutoComplete")]
        public async Task<List<NomDto>> GetNomsFromAutoCompleteAsync([FromBody] string texteAutoComplete, CancellationToken cancellationToken)
        {
            List<NomDto> nomDtos = await _referenceService.GetNomsFromAutoCompleteAsync(texteAutoComplete, cancellationToken);

            foreach (NomDto item in nomDtos)
            {
                item.Libelle = " " + item.Libelle;
                item.RechercheTransLit = texteAutoComplete;
            }

            return nomDtos.OrderBy(x => x.Order)
                        .ThenBy(x => x.Libelle)
                        .ToList();
        }

        [HttpPost("/lieux", Name = "GetLieuxFromAutoComplete")]
        public async Task<List<LieuDto>> GetLieuxFromAutoCompleteAsync([FromBody] string texteAutoComplete, CancellationToken cancellationToken)
        {

            List<LieuDto> lieuDtos = await _referenceService.GetLieuxFromAutoCompleteAsync(texteAutoComplete, cancellationToken);
            foreach (LieuDto item in lieuDtos)
            {
                item.RechercheTransLit = texteAutoComplete;
            }
            return lieuDtos.OrderBy(x => x.Order)
                        .ThenBy(x => x.Libelle)
                        .ToList();
        }

        [HttpGet("{langue}/{referenceId}/libelle", Name = "GetLibelleByLangueByReferenceIdAsync")]
        public async Task<LibelleDto> GetLibelleByLangueByReferenceIdAsync([FromRoute] EnumLangue langue, [FromRoute] Guid referenceId, CancellationToken cancellationToken)
        {
            return new LibelleDto()
            {
                Libelle = await _referenceService.GetLibelleByLangueByReferenceIdAsync(langue, referenceId, cancellationToken)
            };
        }
    }
}
