using Altalents.Commun.Settings;
using Altalents.Entities;

using AlteaTools.EntityFramework;

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

        public virtual DbSet<QuestionDossierTechnique> QuestionDossierTechniques { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<DossierTechnique> DossierTechniques { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<TrigrammeLock> TrigrammeLocks { get; set; }


        public virtual DbSet<LiaisonExperienceCompetence> LiaisonExperienceCompetences { get; set; }
        public virtual DbSet<LiaisonExperienceMethodologie> LiaisonExperienceMethodologies { get; set; }
        public virtual DbSet<LiaisonExperienceOutil> LiaisonExperienceOutils { get; set; }
        public virtual DbSet<LiaisonExperienceTechnologie> LiaisonExperienceTechnologies { get; set; }


    }
}
