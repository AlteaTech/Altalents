using Altalents.Commun.Constants;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class ExperiencesEntityConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            EntityTypeBuilderBaseHelper<Experience>.ConfigureBase(builder);
            builder.ToTable("Experiences");

            builder.Property(e => e.IntitulePoste)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.NomEntreprise)
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
            builder.Property(e => e.LieuEntreprise)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasColumnType("varchar(max)")
                .IsRequired();
            builder.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(e => e.DateFin)
                .HasColumnType("datetime");
            builder.Property(e => e.DomaineMetierId)
                .HasDefaultValue(new Guid(IdsConstantes.DomaineAutreId));

            builder.HasMany(navigationExpression: e => e.LiaisonExperienceTechnologies)
                .WithOne(x => x.Experience)
                .HasForeignKey(e => e.ExperienceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.LiaisonExperienceCompetences)
                .WithOne(x => x.Experience)
                .HasForeignKey(e => e.ExperienceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.LiaisonExperienceMethodologies)
                .WithOne(x => x.Experience)
                .HasForeignKey(e => e.ExperienceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.LiaisonExperienceOutils)
                .WithOne(x => x.Experience)
                .HasForeignKey(e => e.ExperienceId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
