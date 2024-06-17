using Altalents.Entities.Enum;

namespace Altalents.IBusiness.IServices
{
    public partial interface IReferenceService : IInjectableService
    {
        Task<IQueryable<ReferenceDto>> GetReferencesByTypeReferenceIdAsync(Guid typeReferenceId, CancellationToken cancellationToken = default);
        Task<List<TypeReferenceDto>> GetTypeReferencesAsync(CancellationToken cancellationToken = default);
        Task DeleteReferenceAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> InsertReferenceAsync(ReferenceDto reference, CancellationToken cancellationToken = default);
        Task UpdateReferenceAsync(ReferenceDto referenceModifie, CancellationToken cancellationToken = default);
        Task<TypeReferenceDto> GetTypeReferenceByIdAsync(Guid typeId, CancellationToken cancellationToken = default);
        Task<TypeReferenceDto> GetTypeReferenceByIdReferenceAsync(Guid idReference, CancellationToken cancellationToken = default);
        Task<List<ReferenceLightDto>> GetReferencesByTypeAsync(string text, EnumTypeReference type, CancellationToken cancellationToken = default);
        Task<bool> CheckListeReferencesHasAnySousReferenceAsync(List<Guid> referenceIds, CancellationToken cancellationToken = default);
        Task<List<Guid>> GetReferencesIdsWithAnySousReferenceAsync(List<Guid> referenceIds, CancellationToken cancellationToken = default);
    }
}
