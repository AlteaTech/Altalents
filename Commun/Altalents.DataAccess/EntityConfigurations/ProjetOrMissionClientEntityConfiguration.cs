using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class ProjetOrMissionClientEntityConfiguration : IEntityTypeConfiguration<ProjetOrMissionClient>
    {
        public void Configure(EntityTypeBuilder<ProjetOrMissionClient> builder)
        {
            EntityTypeBuilderBaseHelper<ProjetOrMissionClient>.ConfigureBase(builder);
            builder.ToTable("ProjetsOrMissionsClient");

            builder.HasOne(p => p.DomaineMetier)
                .WithMany(p => p.ProjetsOrMissions)
                .HasForeignKey(p => p.DomaineMetierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetTechnologies)
                .WithOne(x => x.ProjetOrMissionClient)
                .HasForeignKey(e => e.ProjetOrMissionClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetCompetences)
                .WithOne(x => x.ProjetOrMissionClient)
                .HasForeignKey(e => e.ProjetOrMissionClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetMethodologies)
                .WithOne(x => x.ProjetOrMissionClient)
                .HasForeignKey(e => e.ProjetOrMissionClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetOutils)
                .WithOne(x => x.ProjetOrMissionClient)
                .HasForeignKey(e => e.ProjetOrMissionClientId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
