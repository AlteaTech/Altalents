using Microsoft.AspNetCore.Http;

namespace Altalents.IBusiness.IServices
{
    // PARTIAL IMAGES
    public partial interface IMarqueService : IInjectableService
    {
        Task AddFileAsync(IEnumerable<IFormFile> filesUploadFileMarque, Guid idMarque, CancellationToken cancellationToken = default);
        Task<int> GetCountImageAsync(Guid idMarque, CancellationToken cancellationToken = default);
        Task<bool> HasMaxImageAsync(Guid idMarque, CancellationToken cancellationToken = default);
        Task<List<ImageDto>> GetImagesAsync(Guid idMarque, CancellationToken cancellationToken = default);
        Task UpdateOrdresImagesMarqueAsync(List<ImageDto> images, CancellationToken cancellationToken = default);
        Task DeleteImagesMarqueAsync(Guid imageId, CancellationToken cancellationToken = default);
    }
}
