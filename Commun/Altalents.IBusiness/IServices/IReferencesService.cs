

namespace Altalents.IBusiness.IServices
{
    public interface IReferencesService : IInjectableService
    {
        Task<Guid> CreateReferencesAsync(ReferenceRequestDto reference, CancellationToken cancellationToken);
        Task<List<ReferenceDto>> GetReferencesAsync(string typeReferenceCode, string startWith, CancellationToken cancellationToken);
        IQueryable<ReferenceAValiderDto> GetReferencesAValider();
        Task UpdateReferenceAsync(ReferenceAValiderDto reference);
    }
}
