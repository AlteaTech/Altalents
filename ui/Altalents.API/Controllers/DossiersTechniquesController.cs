using System.Threading;
using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Request;
using Humanizer;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DossiersTechniquesController : ControllerBase
    {
        private readonly IDossierTechniqueService _dossierTechniqueService;
        private readonly IDossierTechniqueExportService _dossierTechniqueExportService;

        public DossiersTechniquesController(IDossierTechniqueService dossierTechniqueService, IDossierTechniqueExportService dossierTechniqueExportService)
        {
            _dossierTechniqueService = dossierTechniqueService;
            _dossierTechniqueExportService = dossierTechniqueExportService;
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

        [HttpGet("{tokenRapide}/validate-by-candidat", Name = "ValidationDtCompletByCandidat")]
        public async Task ValidationDtCompletByCandidatAsync([FromRoute] Guid tokenRapide, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.ValidationDtCompletByCandidatAsync(tokenRapide, cancellationToken);
        }

        [HttpGet("{tokenRapide}/parlons-de-vous", Name = "GetParlonsDeVous")]
        public async Task<ParlonsDeVousDto> GetParlonsDeVousAsync([FromRoute] Guid tokenRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetParlonsDeVousAsync(tokenRapide, cancellationToken);
        }

        [HttpGet("{tokenRapide}/test-email-creation-dt/{emailTo}/{CandidatFullName}", Name = "TestEnvoiEmailCreationDtAsync")]
        public async void TestEnvoiEmailCreationDtAsync([FromRoute] Guid tokenRapide, [FromRoute] string emailTo, [FromRoute] string CandidatFullName, CancellationToken cancellationToken)
        {
           await  _dossierTechniqueService.TestEnvoiEmailCreationDtAuCandidatAsync(tokenRapide, emailTo, CandidatFullName, cancellationToken);
        }

        [HttpGet("{tokenRapide}/test-email-validation-dt/{CandidatFullName}", Name = "TestEnvoiEmailValidationDtAsync")]
        public async void TestEnvoiEmailValidationDtAsync([FromRoute] Guid tokenRapide, [FromRoute] string CandidatFullName, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.TestEnvoiEmailValidationDtByCandidatAsync(tokenRapide, CandidatFullName, cancellationToken);
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

        [HttpGet("{tokenAccesRapide}/experiences", Name = "GetExperiences")]
        public async Task<List<ExperienceDto>> GetExperiencesAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetExperiencesAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpPost("{tokenAccesRapide}/experiences", Name = "AddExperience")]
        public async Task<Guid> AddExperienceAsync([FromRoute] Guid tokenAccesRapide, ExperienceRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddOrUpdateExperienceAsync(tokenAccesRapide, request, cancellationToken);
        }

        [HttpPut("{tokenAccesRapide}/experiences/{id}", Name = "UpdateExperience")]
        public async Task<Guid> UpdateExperienceAsync([FromRoute] Guid tokenAccesRapide, [FromRoute] Guid id, ExperienceRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddOrUpdateExperienceAsync(tokenAccesRapide, request, cancellationToken, id);
        }

        [HttpDelete("{tokenAccesRapide}/experiences/{id}", Name = "DeleteExperience")]
        public async Task DeleteExperienceAsync([FromRoute] Guid tokenAccesRapide, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.DeleteExperienceAsync(tokenAccesRapide, id, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/documents", Name = "GetDocuments")]
        public async Task<List<DocumentDto>> GetDocumentsAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetPiecesJointesDtAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/cv", Name = "GetCvFile")]
        public async Task<DocumentDto> GetCv([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetCvDtAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/generate-dt", Name = "GenerateDossierCompetenceFile")]
        public async Task<DocumentDto> GenerateDossierCompetenceFileAsync([FromRoute] Guid tokenAccesRapide, [FromQuery] TypeExportEnum? typeExportEnum, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueExportService.GenereateDtWithOpenXmlAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/download-dt", Name = "DownloadDossierCompetenceFile")]
        public IActionResult DownloadDossierCompetenceFileAsync([FromRoute] Guid tokenAccesRapide, [FromQuery] TypeExportEnum? typeExportEnum, CancellationToken cancellationToken)
        {
            DocumentDto dto = _dossierTechniqueExportService.GenereateDtWithOpenXmlAsync(tokenAccesRapide, cancellationToken).Result;
            return File(dto.Data, dto.MimeType, $"{DateTime.Now:yyyyMMdd}_{dto.NomFichier}");
        }

        [HttpGet("{tokenAccesRapide}/competences", Name = "GetCompetences")]
        public async Task<List<CompetenceDto>> GetCompetencesAsync([FromRoute] Guid tokenAccesRapide, [FromQuery] string typeLiaisonCode, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetLiaisonCandidatByTypeAsync(tokenAccesRapide, typeLiaisonCode, cancellationToken);
        }

        [HttpPut("competences", Name = "PutNote")]
        public async Task PutNoteAsync([FromBody] LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.UpdateNiveauLiaisonAsync(request, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/formations", Name = "GetAllAboutFormations")]
        public async Task<AllAboutFormationsDto> GetAllAboutFormationsAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetAllAboutFormationAsync(tokenAccesRapide, cancellationToken);
        }

        [HttpPost("{tokenAccesRapide}/formations", Name = "AddFormationCertification")]
        public async Task<Guid> AddFormationCertificationAsync([FromRoute] Guid tokenAccesRapide, FormationCertificationRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddOrUpdateFormationCertificationAsync(tokenAccesRapide, request, cancellationToken);
        }

        [HttpPut("{tokenAccesRapide}/formations/{id}", Name = "UpdateFormationCertification")]
        public async Task UpdateFormationCertificationAsync([FromRoute] Guid tokenAccesRapide, [FromRoute] Guid id, FormationCertificationRequestDto request, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.AddOrUpdateFormationCertificationAsync(tokenAccesRapide, request, cancellationToken, id);
        }

        [HttpDelete("{tokenAccesRapide}/formations/{id}", Name = "DeleteFormationCertification")]
        public async Task DeleteFormationCertificationAsync([FromRoute] Guid tokenAccesRapide, [FromRoute] Guid id, [FromQuery] FormationCertificationEnum formationCertificationEnum, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.DeleteFormationCertificationAsync(tokenAccesRapide, id, formationCertificationEnum, cancellationToken);
        }

        [HttpPost("{tokenAccesRapide}/langues", Name = "AddLangueParlee")]
        public async Task<Guid> AddLangueParleeAsync([FromRoute] Guid tokenAccesRapide, LangueParleeRequestDto request, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddOrUpdateLangueParleeAsync(tokenAccesRapide, request, cancellationToken);
        }

        [HttpPut("{tokenAccesRapide}/langues/{id}", Name = "UpdateLangueParlee")]
        public async Task UpdateLangueParleeAsync([FromRoute] Guid tokenAccesRapide, [FromRoute] Guid id, LangueParleeRequestDto request, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.AddOrUpdateLangueParleeAsync(tokenAccesRapide, request, cancellationToken, id);
        }

        [HttpDelete("{tokenAccesRapide}/langues/{id}", Name = "DeleteLangueParlee")]
        public async Task DeleteLangueParleeAsync([FromRoute] Guid tokenAccesRapide, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.DeleteLangueParleeAsync(tokenAccesRapide, id, cancellationToken);
        }

        [HttpGet("{tokenAccesRapide}/recapitulatif", Name = "GetRecapitulatif")]
        public async Task<RecapitulatifDtDto> GetRecapitulatifAsync([FromRoute] Guid tokenAccesRapide, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.GetRecapitulatifDtAsync(tokenAccesRapide, cancellationToken);
        }

    }
}
