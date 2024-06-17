using Altalents.Business.Helpers;

using Microsoft.AspNetCore.Http;

namespace Altalents.Business.Services
{
    // PARTIAL IMAGES
    public partial class MarqueService : BaseAppService<CustomDbContext>, IMarqueService
    {
        public async Task AddFileAsync(IEnumerable<IFormFile> filesUploadFileMarque, Guid idMarque, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(idMarque, cancellationToken);
            await CheckCanAddImagesAsync(idMarque, cancellationToken);
            IEnumerable<(string NomFichier, string FullPath)> filesInfos = new List<(string NomFichier, string FullPath)>();

            if (filesUploadFileMarque != null)
            {
                filesInfos = await FilesHelpers.AddImagesAsync(filesUploadFileMarque, "/Marques");
            }

            await DbContext.MarqueImages.AddRangeAsync(filesInfos.Select(filesInfo => new MarqueImage()
            {
                MarqueId = idMarque,
                NomFichier = filesInfo.NomFichier,
                FullPath = filesInfo.FullPath

            }), cancellationToken);

            await MajDateMajMarqueAsync(idMarque, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private async Task CheckCanAddImagesAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            if (await HasMaxImageAsync(idMarque, cancellationToken))
            {
                throw new BusinessException(BusinessExceptionsResources.MAXIMUM_IMAGE_ATTEINT);
            }
        }

        public async Task<List<ImageDto>> GetImagesAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            return await DbContext.MarqueImages
                .Where(x => x.MarqueId == idMarque)
                .ProjectTo<ImageDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountImageAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            return await DbContext.MarqueImages
                .CountAsync(x => x.MarqueId == idMarque, cancellationToken);
        }

        public async Task<bool> HasMaxImageAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            int totalImageAjoutee = await GetCountImageAsync(idMarque, cancellationToken);
            return totalImageAjoutee >= _marqueSettings.MaxImageCount;
        }

        public async Task UpdateOrdresImagesMarqueAsync(List<ImageDto> images, CancellationToken cancellationToken = default)
        {
            // Au moins une image pour enregistrer
            if (!images.Any())
            {
                throw new BusinessException(BusinessExceptionsResources.IMAGE_OBLIGATOIRE);
            }

            foreach (ImageDto imageModifiee in images)
            {
                await DbSetHelper<MarqueImage>.CheckIdExistAsync(DbContext.MarqueImages, imageModifiee.ImageId, cancellationToken);
                MarqueImage imageActuelle = await DbContext.MarqueImages.Where(x => x.Id == imageModifiee.ImageId)
                                                                        .AsTracking()
                                                                        .SingleAsync(cancellationToken);

                if (imageModifiee.Ordre < 1)
                {
                    throw new BusinessException(BusinessExceptionsResources.ORDRE_APPARITION_REQUIRED);
                }

                imageActuelle.Ordre = imageModifiee.Ordre;
            }

            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task DeleteImagesMarqueAsync(Guid imageId, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<MarqueImage>.CheckIdExistAsync(DbContext.MarqueImages, imageId, cancellationToken);
            MarqueImage image = await DbContext.MarqueImages.Where(x => x.Id == imageId)
                                                            .AsTracking()
                                                            .SingleAsync(cancellationToken);
            DbContext.MarqueImages.Remove(image);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }
    }
}
