using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Requesst;
using Microsoft.AspNetCore.Mvc;

namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueService : IInjectableService
    {
        Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken);
        Task ChangerStatutDossierTechniqueAsync(Guid id, Guid statutId, CancellationToken cancellationToken);
        Task<NomPrenomPersonneDto> GetNomPrenomFromTokenAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
        IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques();
        IQueryable<DossierTechniqueEnCoursDto> GetDtsEnCours(EtatFiltreDtEnum etat);
        Task<TrigrammeDto> GetTrigrammeAsync(GetTrigrammeRequestDto request, CancellationToken cancellationToken);
        Task<bool> IsEmailValidAsync(string email,Guid? tokenRapide, CancellationToken cancellationToken);
        Task<bool> IsIdBoondValidAsync(string idboond, CancellationToken cancellationToken);
        Task<bool> IsTrigrammeValidAsync(string trigram, CancellationToken cancellationToken);
        bool IsTelephoneValid(string telephone, bool isOptionnal = false);
        Task<ParlonsDeVousDto> GetParlonsDeVousAsync(Guid tokenRapide, CancellationToken cancellationToken);
        Task PutParlonsDeVousAsync(Guid tokenRapide, ParlonsDeVousUpdateRequestDto request, CancellationToken cancellationToken);
    }
}
