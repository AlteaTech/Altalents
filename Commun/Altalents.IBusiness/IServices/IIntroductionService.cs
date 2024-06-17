namespace Altalents.IBusiness.IServices
{
    public partial interface IIntroductionService : IInjectableService
    {
        Task DeleteIntroductionAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IntroductionDto> GetIntroductionByIdAsync(Guid introductionId, CancellationToken cancellationToken = default);
        Task<List<IntroductionDto>> GetIntroductionsAsync(CancellationToken cancellationToken = default);
        Task<Guid> InsertIntroductionAsync(IntroductionDto introduction, CancellationToken cancellationToken = default);
        Task UpdateIntroductionAsync(IntroductionDto introductionModifiee, CancellationToken cancellationToken = default);
    }
}
