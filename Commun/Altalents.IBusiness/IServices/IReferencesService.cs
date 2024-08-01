
namespace Altalents.IBusiness.IServices
{
    public interface IReferencesService : IInjectableService
    {
        Task<List<ReferenceDto>> GetReferencesAsync(string typeReferenceCode, string startWith, CancellationToken cancellationToken);
    }
}
