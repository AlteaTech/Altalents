using Altalents.Commun.Settings;
using Altalents.Entities;

using AlteaTools.EntityFramework;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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
        public virtual DbSet<ProjetOrMissionClient> ProjetsOrMissionsClient { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<TrigrammeLock> TrigrammeLocks { get; set; }

        public virtual DbSet<LiaisonProjetCompetence> LiaisonProjetCompetences { get; set; }
        public virtual DbSet<LiaisonProjetMethodologie> LiaisonProjetMethodologies { get; set; }
        public virtual DbSet<LiaisonProjetOutil> LiaisonProjetOutils { get; set; }
        public virtual DbSet<LiaisonProjetTechnologie> LiaisonProjetTechnologies { get; set; }

        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<DossierTechniqueLangue> DossierTechniqueLangues { get; set; }
        public virtual DbSet<DocumentComplementaire> DocumentComplementaires { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Adresse> Adresses { get; set; }

    }
}
