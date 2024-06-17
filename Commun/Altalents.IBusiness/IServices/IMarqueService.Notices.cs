using Altalents.IBusiness.DTO.Requests;

namespace Altalents.IBusiness.IServices
{
    // PARTIAL NOTICES
    public partial interface IMarqueService : IInjectableService
    {
        Task<List<NoticeMarqueDto>> GetNoticesMarquesDto(Guid idMarque, CancellationToken cancellationToken = default);
        Task UpdateNoticesMarqueAsync(Dictionary<Guid, UpdateNoticeRequestDto> data, CancellationToken cancellationToken = default);
        Task<Guid> InsertOngletNoticeMarqueAsync(OngletNoticeMarqueDto ongletNoticeMarque, Guid marqueId, CancellationToken cancellationToken = default);
    }
}
