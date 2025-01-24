using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueService : IInjectableService
    {
        Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken);
        Task ChangerStatutDossierTechniqueAsync(Guid id, Guid statutId, CancellationToken cancellationToken);
        Task<NomPrenomPersonneDto> GetNomPrenomFromTokenAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        IQueryable<DossierTechniqueForAdminDto> GetQueryDtForKendoUi();
        Task<TrigrammeDto> GetTrigrammeAsync(GetTrigrammeRequestDto request, CancellationToken cancellationToken);
        Task<bool> IsEmailValidAsync(string email, Guid? tokenRapide, CancellationToken cancellationToken);
        Task<bool> IsIdBoondValidAsync(string idboond, CancellationToken cancellationToken);
        Task<bool> IsTrigrammeValidAsync(string trigram, CancellationToken cancellationToken);
        bool IsTelephoneValid(string telephone, bool isOptionnal = false);
        Task<ParlonsDeVousDto> GetParlonsDeVousAsync(Guid tokenRapide, CancellationToken cancellationToken);
        Task PutParlonsDeVousAsync(Guid tokenRapide, ParlonsDeVousUpdateRequestDto request, CancellationToken cancellationToken);
        Task<List<QuestionnaireDto>> GetQuestionnairesAsync(Guid tokenRapide, CancellationToken cancellationToken);
        Task SetReponseQuestionnairesAsync(List<QuestionnaireUpdateDto> questionnaires, CancellationToken cancellationToken);
        Task<List<CompetenceDto>> GetLiaisonCandidatByTypeAsync(Guid tokenRapide, string typeLiaisonCode, CancellationToken cancellationToken);
        Task UpdateNiveauLiaisonAsync(LiaisonExperienceUpdateNiveauDto request, CancellationToken cancellationToken);
        Task<List<ExperienceDto>> GetExperiencesAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        Task<List<DocumentDto>> GetPiecesJointesDtAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        Task<DocumentDto> GetCvDtAsync(Guid tokenRapide, CancellationToken cancellationToken);
        Task<AllAboutFormationsDto> GetAllAboutFormationAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        Task<Guid> AddOrUpdateFormationCertificationAsync(Guid tokenAccesRapide, FormationCertificationRequestDto request, CancellationToken cancellationToken, Guid? id = null);
        Task<Guid> AddOrUpdateLangueParleeAsync(Guid tokenAccesRapide, LangueParleeRequestDto request, CancellationToken cancellationToken, Guid? id = null);
        Task<RecapitulatifDtDto> GetRecapitulatifDtAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        Task DeleteDossierTechnique(Guid idDossierTechnique, CancellationToken cancellationToken);
        Task DeleteFormationCertificationAsync(Guid tokenAccesRapide, Guid id, FormationCertificationEnum formationOrCertificationEnum, CancellationToken cancellationToken);
        Task DeleteExperienceAsync(Guid tokenAccesRapide, Guid id, CancellationToken cancellationToken);
        Task DeleteLangueParleeAsync(Guid tokenAccesRapide, Guid id, CancellationToken cancellationToken);
        Task<Guid> AddOrUpdateExperienceAsync(Guid tokenAccesRapide, ExperienceRequestDto experienceDto, CancellationToken cancellationToken, Guid? id = null);
        Task TestEnvoiEmailCreationDtAuCandidatAsync(Guid tokenAccesRapide, string emailTo, string fullNameCandidat, CancellationToken cancellationToken);
        Task TestEnvoiEmailValidationDtByCandidatAsync(Guid tokenAccesRapide, string fullNameCandidat, CancellationToken cancellationToken);
        Task ValidationDtCompletByCandidatAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        Task<PermissionConsultationDtDto> GetPermissionConsultationDtAsync(string tokenRapide, bool isUserLoggedInBackoffice, CancellationToken cancellationToken);
    }
}
