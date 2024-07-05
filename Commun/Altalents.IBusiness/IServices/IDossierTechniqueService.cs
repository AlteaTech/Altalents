using Altalents.Commun.Enums;

namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueService : IInjectableService
    {
        IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques();
        IQueryable<DossierTechniqueEnCoursDto> GetDtsEnCours(EnumEtatFiltreDt etat);
    }
}
