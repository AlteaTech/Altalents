using System.Runtime.CompilerServices;

using Hangfire;

using Microsoft.Data.SqlClient;

namespace Altalents.Business.Services
{
    public class JobService : BaseAppService<CustomDbContext>, IJobService
    {
        public JobService(
            ILogger<JobService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
        }
        public void IntegrationBdd()
        {
            string directoryPath = @"./Sql/RDD_MarquesSousRefRef_InsertScript";

            if (Directory.Exists(directoryPath))
            {
                // Obtenir la liste de tous les fichiers dans le répertoire
                string[] files = Directory.GetFiles(directoryPath);

                // Vous pouvez également spécifier un filtre par extension si nécessaire
                // Exemple : string[] files = Directory.GetFiles(directoryPath, "*.txt");
                int minute = 0;
                foreach (string file in files)
                {
                    BackgroundJob.Schedule(() => IntegrationFichierSql(file), new TimeSpan(0, minute, 10));
                    minute += 2;
                }
            }
            else
            {
                throw new Exception("Le répertoire spécifié n'existe pas.");
            }
        }

        public void IntegrationFichierSql(string file)
        {
            string sqlQuery = "";
            if (Path.GetExtension(file).ToLower() == ".sql")
            {
                // Lire le contenu du fichier en tant que chaîne de caractères
                sqlQuery = File.ReadAllText(file);
            }
            else
            {
                throw new Exception("uniquement .sql Accepté");
            }

            // Créez une commande SQL
            SqlCommand command = new(sqlQuery);

            // Exécutez la requête
            DbContext.Database.SetCommandTimeout(2400000);
            DbContext.Database.ExecuteSql(FormattableStringFactory.Create(sqlQuery));
        }
    }
}
