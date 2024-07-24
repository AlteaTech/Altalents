
using Altalents.Commun.Enums;

namespace Altalents.Business.Services
{
    public class ReferencesService : BaseAppService<CustomDbContext>, IReferencesService
    {
        public ReferencesService(ILogger<ReferencesService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider) : base(logger, contexte, mapper, serviceProvider)
        {
        }

        public async Task<List<ReferenceDto>> GetReferencesAsync(string typeReferenceCode, CancellationToken cancellationToken)
        {
            TypeReferenceEnum typeReference = (TypeReferenceEnum)Enum.Parse(typeof(TypeReferenceEnum), typeReferenceCode);
            return await DbContext.References
                 .Where(x => x.Type == typeReference)
                 .OrderBy(x => x.OrdreTri)
                 .ThenBy(x => x.Libelle)
                 .ProjectTo<ReferenceDto>(Mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
        }
    }
}
