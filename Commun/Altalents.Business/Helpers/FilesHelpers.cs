using Microsoft.AspNetCore.Http;

namespace Altalents.Business.Helpers
{
    internal static class FilesHelpers
    {
        internal static async Task<IEnumerable<(string NomFichier, string FullPath)>> AddImagesAsync(IEnumerable<IFormFile> files, string subDirectoryPath = "", bool isLocal = false)
        {
            List<(string NomFichier, string FullPath)> filesNames = new List<(string NomFichier, string FullPath)>();

            foreach (IFormFile file in files)
            {
                ContentDispositionHeaderValue fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                Guid guid = Guid.NewGuid();
                string fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                string newFileName = $"{guid}.{fileName.Split('.').Last()}";
                filesNames.Add(new() { NomFichier = newFileName, FullPath = await WriteFile(@"wwwroot\Images", subDirectoryPath, file, newFileName) });
            }

            return filesNames;
        }

        private static async Task<string> WriteFile(string basePath, string subDirectoryPath, IFormFile file, string newFileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), basePath + subDirectoryPath, newFileName);
            byte[] buffer = new byte[16 * 1024];
            using (Stream reader = file.OpenReadStream())
            {
                using (MemoryStream ms = new())
                {
                    int read;
                    while ((read = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    using BinaryWriter writer = new(System.IO.File.OpenWrite(filePath));
                    writer.Write(ms.ToArray());
                }
            }
            return filePath;
        }
    }
}
