using Altalents.Entities;
using Altalents.IBusiness.Enums;

namespace Altalents.IBusiness.IServices
{
    public partial interface IMarqueService : IInjectableService
    {
        Task<List<MarqueNonPublieDto>> GetMarquesNonPublieesAsync(CancellationToken cancellationToken = default);
        Task<MarqueFullDto> GetMarqueFullByIdAsync(EnumLangue langue, Guid marqueId, bool isPrevisualisation, CancellationToken cancellationToken = default);
        Task<List<MarqueRechercheDto>> GetMarquesRechercheAsync(EnumLangue langue, RechercheRequestDto rechercheRequest, CancellationToken cancellationToken = default);
        Task<List<MarqueNouveauteDto>> GetMarquesNouveautesAsync(EnumLangue langue, CancellationToken cancellationToken = default);
    }
}
