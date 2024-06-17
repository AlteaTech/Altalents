using Altalents.Entities.Enum;
using Altalents.IBusiness.DTO.Requests;

namespace Altalents.IBusiness.IServices
{
    // PARTIAL INDEX
    public partial interface IMarqueService : IInjectableService
    {
        Task UpdateIndexMarqueAsync(UpdateIndexMarqueRequestDto data, CancellationToken cancellationToken = default);
        Task<IndexMarqueDto> GetUpdateIndexMarqueDtoAsync(Guid idMarque, CancellationToken cancellationToken = default);
        Task<IQueryable<MarqueLightDto>> GetMarquesAssocieesByReferenceIdAsync(Guid referenceId, Guid? sousReferenceId, CancellationToken cancellationToken = default);
        IQueryable<MarqueReferenceLibreDto> GetMarqueReferenceLibresByTypeEtMarqueId(EnumTypeMarqueReferenceLibre type, Guid marqueId);
        Task<Guid> InsertMarqueReferenceLibreAsync(MarqueReferenceLibreDto marqueReferenceLibre, CancellationToken cancellationToken = default);
        Task UpdateMarqueReferenceLibreAsync(MarqueReferenceLibreDto marqueReferenceLibreModifiee, CancellationToken cancellationToken = default);
        Task DeleteMarqueReferenceLibreAsync(Guid marqueReferenceLibreId, Guid marqueId, CancellationToken cancellationToken = default);
        Task<List<LugtDto>> GetLugtsFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken);
        Task<List<LugtDto>> GetLugtByOldIdAltalentsAsync(string oldId, CancellationToken cancellationToken);
    }
}
