using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueService : IInjectableService
    {
        Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken);
        Task ChangerStatutDossierTechniqueAsync(Guid id, Guid statutId, CancellationToken cancellationToken);
        IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques();
        IQueryable<DossierTechniqueEnCoursDto> GetDtsEnCours(EtatFiltreDtEnum etat);
        Task<TrigrammeDto> GetTrigrammeAsync(GetTrigrammeRequestDto request, CancellationToken cancellationToken);
        Task<bool> IsEmailValidAsync(string email, CancellationToken cancellationToken);
        Task<bool> IsIdBoondValidAsync(string idboond, CancellationToken cancellationToken);
        Task<bool> IsTrigrammeValidAsync(string trigram, CancellationToken cancellationToken);
    }
}
