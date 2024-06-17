using Altalents.Entities.Enum;
using Altalents.IBusiness.Enums;

namespace Altalents.IBusiness.IServices
{
    public partial interface ITexteDiversService : IInjectableService
    {
        Task<List<TexteDiversByLangueDto>> GetTextesDiversByLangueByTypeAsync(EnumLangue langue, EnumTypeTexteDivers typeTexteDivers, CancellationToken cancellationToken = default);
    }
}
