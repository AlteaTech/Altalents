namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueService : IInjectableService
    {
        IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques();
    }
}
