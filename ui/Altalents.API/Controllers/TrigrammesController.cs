using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrigrammesController
    {
        private readonly IDossierTechniqueService _dossierTechniqueService;

        public TrigrammesController(IDossierTechniqueService dossierTechniqueService)
        {
            _dossierTechniqueService = dossierTechniqueService;
        }

        [HttpPost("", Name = "GetTrigramme")]
        public async Task<TrigrammeDto> GetTrigrammeAsync([FromBody] GetTrigrammeRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetTrigrammeAsync(request, cancellationToken);
        }
    }
}
