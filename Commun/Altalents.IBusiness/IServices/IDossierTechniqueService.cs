using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueService : IInjectableService
    {
        Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken);
        IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques();
        IQueryable<DossierTechniqueEnCoursDto> GetDtsEnCours(EtatFiltreDtEnum etat);
    }
}
