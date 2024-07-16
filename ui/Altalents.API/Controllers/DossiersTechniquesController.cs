using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DossiersTechniquesController
    {
        private readonly IDossierTechniqueService _dossierTechniqueService;

        public DossiersTechniquesController(IDossierTechniqueService dossierTechniqueService)
        {
            _dossierTechniqueService = dossierTechniqueService;
        }

        [HttpPost("", Name = "AddDossierTechnique")]
        public async Task<Guid> AddDossierTechniqueAsync([FromBody] DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddDossierTechniqueAsync(dossierTechnique, cancellationToken);
        }

        [HttpPut("{id}/statut/{statutId}", Name = "ChangerStatutDossierTechnique")]
        public async Task ChangerStatutDossierTechniqueAsync([FromRoute] Guid id, [FromRoute] Guid statutId, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, cancellationToken);
        }
    }
}
