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
        public async Task<bool> IsEmailValidAsync([FromBody] string email, [FromQuery] Guid? tokenRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.IsEmailValidAsync(email, tokenRapide, cancellationToken);
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
        public async Task<ParlonsDeVousDto> GetParlonsDeVousAsync([FromRoute] Guid tokenRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetParlonsDeVousAsync(tokenRapide, cancellationToken);
        }

        [HttpGet("{tokenRapide}/questionnaires", Name = "GetQuestionnaires")]
        public async Task<List<QuestionnaireDto>> GetQuestionnairesAsync([FromRoute] Guid tokenRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetQuestionnairesAsync(tokenRapide, cancellationToken);
        }


        [HttpPut("questionnaires-reponse", Name = "SetReponseQuestionnaires")]
        public async Task SetReponseQuestionnairesAsync([FromBody] List<QuestionnaireUpdateDto> questionnaires, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.SetReponseQuestionnairesAsync(questionnaires, cancellationToken);
        }

        [HttpPut("{tokenRapide}/parlons-de-vous", Name = "PutParlonsDeVous")]
        public async Task PutParlonsDeVousAsync([FromRoute] Guid tokenRapide, [FromBody] ParlonsDeVousUpdateRequestDto request, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.PutParlonsDeVousAsync(tokenRapide, request, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/nom-prenom", Name = "GetNomPrenomFromTokenAsync")]
        public async Task<NomPrenomPersonneDto> GetNomPrenomFromTokenAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetNomPrenomFromTokenAsync(tokenAccesRapide, cancellationToken);
        }


        [HttpPut("{tokenAccesRapide}/experiences", Name = "PutExperiences")]
        public async Task PutExperiencesAsync([FromRoute] Guid tokenAccesRapide, [FromBody] PutExperiencesRequestDto request, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.PutExperiencesAsync(tokenAccesRapide, request, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/experiences", Name = "GetExperiences")]
        public async Task<List<ExperienceDto>> GetExperiencesAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
           return await _dossierTechniqueService.GetExperiencesAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/documents", Name = "GetDocuments")]
        public async Task<List<DocumentDto>> GetDocumentsAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetDocumentsAsync(tokenAccesRapide, cancellationToken);
        }
        [HttpGet("{tokenAccesRapide}/generate-dt", Name = "GenerateDossierCometanceFile")]
        public async Task<DocumentDto> GenerateDossierCometanceFileAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GenerateDossierCometanceFileAsync(tokenAccesRapide, cancellationToken);
        }
    }
}
