using Altalents.IBusiness.Enums;

namespace Altalents.IBusiness.IServices
{
    public partial interface ISousReferenceService : IInjectableService
    {
        Task<List<SousReferenceByLangueDto>> GetSousReferenceByLangueByReferenceIdAsync(Guid referenceId, EnumLangue langue, CancellationToken cancellationToken = default);
        Task<string> GetLibelleByLangueBySousReferenceIdAsync(EnumLangue langue, Guid sousReferenceId, CancellationToken cancellationToken = default);
    }
}
