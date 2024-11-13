using Altalents.Business.Services;
using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DossiersTechniquesController
    {
        private readonly IDossierTechniqueService _dossierTechniqueService;
        private readonly ICompetencesService _competencesService;

        public DossiersTechniquesController(IDossierTechniqueService dossierTechniqueService, ICompetencesService competencesService)
        {
            _dossierTechniqueService = dossierTechniqueService;
            _competencesService = competencesService;
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

        //WARNING FROM VROMAIN : Le formatage du nom de la route contient async alors que c'est pas le cas pour les auutres routes
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

        [HttpGet("{tokenAccesRapide}/generate-dt", Name = "GenerateDossierCompetenceFile")]
        public async Task<DocumentDto> GenerateDossierCompetenceFileAsync([FromRoute] Guid tokenAccesRapide, [FromQuery]TypeExportEnum? typeExportEnum, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GenerateDossierCompetenceFileAsync(tokenAccesRapide, typeExportEnum ?? TypeExportEnum.PDF, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/competences", Name = "GetCompetences")]
        public async Task<List<CompetenceDto>> GetCompetencesAsync([FromRoute] Guid tokenAccesRapide, [FromQuery] string typeLiaisonCode, CancellationToken cancellationToken)
        {
            return await _competencesService.GetLiaisonCandidatByTypeAsync(tokenAccesRapide, typeLiaisonCode, cancellationToken);
        }

        [HttpPut("{tokenAccesRapide}/competences", Name = "PutNote")]
        public async Task PutNoteAsync([FromRoute] Guid tokenAccesRapide, [FromBody] LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken)
        {
            await _competencesService.UpdateNiveauLiaisonAsync(request, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/formations", Name = "GetAllAboutFormations")]
        public async Task<AllAboutFormationsDto> GetAllAboutFormationsAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetAllAboutFormationAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpPost("{tokenAccesRapide}/formations/AddOrUpdateFormationCertification")]
        public async Task<Guid> AddOrUpdateFormationCertificationAsync([FromRoute] Guid tokenAccesRapide, PostFormationCertificationRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddOrUpdateFormationCertification(tokenAccesRapide, request, cancellationToken);
        }

        [HttpPost("{tokenAccesRapide}/formations/AddOrUpdateLangueParlee")]
        public async Task<Guid> AddOrUpdateLangueParleeAsync([FromRoute] Guid tokenAccesRapide, PostLangueParleeRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddOrUpdateLangueParleeAsync(tokenAccesRapide, request, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/recapitulatif", Name = "GetRecapitulatif")]
        public async Task<RecapitulatifDtDto> GetRecapitulatifAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetRecapitulatifDtAsync(tokenAccesRapide, cancellationToken);
        }
    }
}
