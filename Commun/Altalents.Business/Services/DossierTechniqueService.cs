
namespace Altalents.Business.Services
{
    public class DossierTechniqueService : BaseAppService<CustomDbContext>, IDossierTechniqueService
    {
        public DossierTechniqueService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider) : base(logger, contexte, mapper, serviceProvider)
        {
        }

        public IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques()
        {
            return DbContext.DossierTechniques
                                         .ProjectTo<DossierTechniqueDto>(Mapper.ConfigurationProvider);
        }
    }
}
