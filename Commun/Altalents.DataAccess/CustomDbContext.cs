using AlteaTools.EntityFramework;

using Altalents.Commun.Settings;

using Hangfire;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Altalents.DataAccess
{
    public class CustomDbContext : AbstractDbContext
    {
        public CustomDbContext(DbContextOptions options, ILogger<CustomDbContext> logger,
            IOptionsMonitor<GlobalSettings> globalSettings,
            IHttpContextAccessor httpContextAccessor)
            : base(options, httpContextAccessor, globalSettings.CurrentValue.BddSettings, logger)
        {
        }

        // ne pas utiliser là que pour les migration
        public CustomDbContext() : base()
        {

        }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}
