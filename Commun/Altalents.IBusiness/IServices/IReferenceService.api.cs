using Altalents.IBusiness.Enums;

namespace Altalents.IBusiness.IServices
{
    public partial interface IReferenceService : IInjectableService
    {
        Task<List<ReferenceByLangueDto>> GetReferenceByLangueByTypeReferenceIdAsync(Guid typeReferenceId, EnumLangue langue, CancellationToken cancellationToken = default);
        Task<List<TypeReferenceLightDto>> GetTypeReferencesLightAsync(CancellationToken cancellationToken = default);
        Task<List<NomDto>> GetNomsFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken = default);
        Task<List<LieuDto>> GetLieuxFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken = default);
        Task<string> GetLibelleByLangueByReferenceIdAsync(EnumLangue langue, Guid referenceId, CancellationToken cancellationToken = default);
    }
}
