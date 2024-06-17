using Altalents.IBusiness.Enums;

namespace Altalents.IBusiness.IServices
{
    public partial interface IIntroductionService : IInjectableService
    {
        Task<List<IntroductionByLangueDto>> GetIntroductionsByLangueAsync(EnumLangue langue, CancellationToken cancellationToken = default);
    }
}
