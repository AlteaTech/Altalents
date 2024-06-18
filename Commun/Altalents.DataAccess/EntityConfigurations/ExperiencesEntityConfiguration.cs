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
            builder.Property(e => e.Entreprise)
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
            builder.Property(e => e.Lieu)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasColumnType("varchar(max)")
                .IsRequired();
            builder.Property(e => e.DomaineMetier)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.ClientFinal)
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            builder.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(e => e.DateFin)
                .HasColumnType("datetime");

            builder.HasMany(navigationExpression: e => e.LiaisonExperienceTechnologies)
                .WithOne(x => x.Experience)
                .HasForeignKey(e => e.ExperienceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.LiaisonExperienceCompetances)
                .WithOne(x => x.Experience)
                .HasForeignKey(e => e.ExperienceId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
