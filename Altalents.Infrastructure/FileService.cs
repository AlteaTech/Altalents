namespace Altalents.Infrastructure
{
    public class FileService
    {
        private string _uploadDirectory;

        public FileService()
        {
            // Définit le répertoire d'upload dans wwwroot/upload
            _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

            // Crée le répertoire si il n'existe pas déjà
            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }
        }


        // Met à jour le répertoire d'upload
        public void UpdateUploadFolder(string subFolderName)
        {
            if (string.IsNullOrWhiteSpace(subFolderName))
            {
                throw new ArgumentException("Le nom du sous-dossier ne peut pas être vide.");
            }

            // Définit un nouveau chemin pour le répertoire d'upload
            _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", subFolderName);

            // Crée le sous-dossier s'il n'existe pas déjà
            EnsureDirectoryExists(_uploadDirectory);
        }

        // Ajouter un fichier
        public async Task<string> AddFileAsync(byte[] fileContent, string originalFileName)
        {
            if (fileContent == null || fileContent.Length == 0)
            {
                throw new ArgumentException("Le contenu du fichier ne peut pas être vide.");
            }

            string fileName = DateTime.Now.Ticks.ToString() +"_"+ originalFileName;
            string filePath = Path.Combine(_uploadDirectory, fileName);

            await File.WriteAllBytesAsync(filePath, fileContent);

            return fileName; // Retourne le nom du fichier pour le retrouver plus tard
        }

        // Supprimer un fichier
        public bool DeleteFile(string fileName)
        {
            string filePath = Path.Combine(_uploadDirectory, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false; // Si le fichier n'existe pas
        }

        // Récupérer un fichier par son nom
        public Task<byte[]> GetFileAsync(string fileName)
        {
            string filePath = Path.Combine(_uploadDirectory, fileName);

            if (File.Exists(filePath))
            {
                return File.ReadAllBytesAsync(filePath);
            }

            throw new FileNotFoundException($"Le fichier '{fileName}' n'a pas été trouvé.");
        }

        // Vérifier si un fichier existe
        public bool FileExists(string fileName)
        {
            string filePath = Path.Combine(_uploadDirectory, fileName);
            return File.Exists(filePath);
        }


        // Vérifie et crée un répertoire s'il n'existe pas
        private void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }


    }
}
