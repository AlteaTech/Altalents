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


        [HttpPost("/is-email-valid", Name = "IsEmailValid")]
        public async Task<bool> IsEmailValidAsync([FromBody] string email, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.IsEmailValidAsync(email, cancellationToken);
        }

        [HttpPost("/is-idboond-valid", Name = "IsIdBoondValid")]
        public async Task<bool> IsIdBoondValidAsync([FromBody] string idboond, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.IsIdBoondValidAsync(idboond, cancellationToken);
        }

        [HttpPost("/is-trigram-valid", Name = "IsTrigrammeValid")]
        public async Task<bool> IsTrigrammeValidAsync([FromBody] string trigram, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.IsTrigrammeValidAsync(trigram, cancellationToken);
        }

        [HttpPost("/is-telephone-valid", Name = "IsTelephoneValid")]
        public bool IsTelephoneValid([FromBody] IsTelephoneValidRequestDto request)
        {
            return _dossierTechniqueService.IsTelephoneValid(request.Telephone, request.IsOptionnal);
        }

        [HttpPut("{id}/statut/{statutId}", Name = "ChangerStatutDossierTechnique")]
        public async Task ChangerStatutDossierTechniqueAsync([FromRoute] Guid id, [FromRoute] Guid statutId, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, cancellationToken);
        }

        [HttpGet("{tokenRapide}/parlons-de-vous", Name = "GetParlonsDeVous")]
        public async Task<ParlonsDeVousDto> GetParlonsDeVousAsync([FromRoute] Guid tokenRapide,CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetParlonsDeVousAsync(tokenRapide, cancellationToken);
        }

        [HttpPut("{tokenRapide}/parlons-de-vous", Name = "PutParlonsDeVous")]
        public async Task PutParlonsDeVousAsync([FromRoute] Guid tokenRapide,[FromBody] ParlonsDeVousUpdateRequestDto request, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.PutParlonsDeVousAsync(tokenRapide, request, cancellationToken);
        }
    }
}
