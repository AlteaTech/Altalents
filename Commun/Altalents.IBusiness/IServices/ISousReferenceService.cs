namespace Altalents.IBusiness.IServices
{
    public partial interface ISousReferenceService : IInjectableService
    {
        Task DeleteSousReferenceAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IQueryable<SousReferenceDto>> GetSousReferencesByReferenceIdAsync(Guid referenceId, CancellationToken cancellationToken = default);
        Task<Guid> InsertSousReferenceAsync(SousReferenceDto sousReference, CancellationToken cancellationToken = default);
        Task UpdateSousReferenceAsync(SousReferenceDto sousReferenceModifie, CancellationToken cancellationToken = default);
        Task<List<SousReferenceLightDto>> GetAllSousReferencesAsync(List<Guid> referenceIds, CancellationToken cancellationToken = default);
    }
}
