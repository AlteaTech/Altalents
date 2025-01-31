

namespace Altalents.IBusiness.IServices
{
    public interface IReferencesService : IInjectableService
    {
        Task<Guid> CreateReferencesAsync(ReferenceRequestDto reference, CancellationToken cancellationToken);
        Task<List<ReferenceDto>> GetReferencesAsync(string typeReferenceCode, string startWith, CancellationToken cancellationToken);
        IQueryable<ReferenceAValiderDto> GetReferencesAValider(bool showAll);
        Task DeleteReference(Guid idRef, CancellationToken cancellationToken);
        Task UpdateReferenceAsync(ReferenceAValiderDto reference);
    }
}
