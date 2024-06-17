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

        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<VueMarqueInitialesSearch> VueMarqueInitialesSearchs { get; set; }
        public virtual DbSet<MarqueSousReferenceReference> MarqueSousReferenceReferences { get; set; }
        public virtual DbSet<OngletNoticeMarque> OngletNoticeMarques { get; set; }
        public virtual DbSet<MarqueImage> MarqueImages { get; set; }
        public virtual DbSet<MarqueNotice> MarqueNotices { get; set; }
        public virtual DbSet<MarqueReferenceLibre> MarqueReferenceLibres { get; set; }
        public virtual DbSet<MarqueRenvois> MarqueRenvois { get; set; }
        public virtual DbSet<MarqueRenvoisTemporaire> MarqueRenvoisTemporaires { get; set; }
        public virtual DbSet<TypeReference> TypeReferences { get; set; }
        public virtual DbSet<SousReference> SousReferences { get; set; }
        public virtual DbSet<Introduction> Introductions { get; set; }
        public virtual DbSet<TexteDivers> TexteDivers { get; set; }

        public override async Task<int> SaveBaseEntityChangesAsync(CancellationToken cancellationToken = default, bool withTrigger = true)
        {
            int totalModifie = await base.SaveBaseEntityChangesAsync(cancellationToken, withTrigger);
            if (withTrigger)
            {
                List<Guid> marquesIdInititalesModifie = GetMarquesIdInititalesModifie();
                if (marquesIdInititalesModifie.Any())
                {
                    BackgroundJob.Enqueue(() => MajVueMarquesReference(marquesIdInititalesModifie, cancellationToken));
                }
            }
            return totalModifie;
        }

        public async Task<int> MajVueMarquesReference(List<Guid> marquesIdInititalesModifie , CancellationToken cancellationToken)
        {
            VueMarqueInitialesSearchs.RemoveRange(await VueMarqueInitialesSearchs.Where(v => marquesIdInititalesModifie.Contains(v.MarqueId)).ToListAsync());
            await base.SaveBaseEntityChangesAsync(cancellationToken);
            await TriggerCodeMarqueInitialeAsync(marquesIdInititalesModifie);
            return await base.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private async Task TriggerCodeMarqueInitialeAsync(List<Guid> marquesIdInititalesModifie)
        {
            List<MarqueReferenceLibre> nouvelleReference = await MarqueReferenceLibres.Where(m => marquesIdInititalesModifie.Contains(m.MarqueId) && m.Type == EnumTypeMarqueReferenceLibre.InitialeLatin).ToListAsync();
            IEnumerable<IGrouping<Guid, MarqueReferenceLibre>> groupedNewReferences = nouvelleReference.GroupBy(x => x.MarqueId);
            foreach (IGrouping<Guid, MarqueReferenceLibre> group in groupedNewReferences)
            {
                IEnumerable<IGrouping<string, MarqueReferenceLibre>> groupedInitiale = group.GroupBy(x => x.TexteTransLitLowerFr);
                foreach (var initialeGrp in groupedInitiale)
                {
                    await VueMarqueInitialesSearchs.AddAsync(new()
                    {
                        TexteTransLitLowerFr = initialeGrp.Key,
                        MarqueId = group.Key,
                        Total = initialeGrp.Count(),
                    });
                }
            }
        }

        private List<Guid> GetMarquesIdInititalesModifie()
        {
            return ChangeTracker.Entries()
                    .Where(e => e.Entity is Marque)
                    .Select(e => ((Marque)e.Entity).Id)
                    .Distinct()
                    .ToList();
        }
    }
}
