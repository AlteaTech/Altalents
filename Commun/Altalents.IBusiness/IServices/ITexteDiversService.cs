using Altalents.Entities.Enum;

namespace Altalents.IBusiness.IServices
{
    public partial interface ITexteDiversService : IInjectableService
    {
        Task<List<TexteDiversDto>> GetTextesDiversByTypeAsync(EnumTypeTexteDivers type, CancellationToken cancellationToken = default);
        Task UpdateTexteDiversAsync(TexteDiversDto texteDiversModifie, CancellationToken cancellationToken = default);
    }
}
