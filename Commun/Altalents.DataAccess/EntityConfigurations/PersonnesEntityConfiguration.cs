namespace Altalents.DataAccess.EntityConfigurations
{
    internal class PersonnesEntityConfiguration : IEntityTypeConfiguration<Personne>
    {
        public void Configure(EntityTypeBuilder<Personne> builder)
        {
            EntityTypeBuilderBaseHelper<Personne>.ConfigureBase(builder);
            builder.ToTable("Personnes");

            builder.Property(e => e.Nom)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Prenom)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.BoondId)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(e => e.Trigramme)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder.Property(e => e.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();
            //builder.HasIndex(e => e.Trigramme).IsUnique();
            builder.HasIndex(e => e.BoondId).IsUnique();

            builder.HasMany(navigationExpression: e => e.DossierTechniques)
                .WithOne(x => x.Personne)
                .HasForeignKey(e => e.PersonneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Contacts)
                .WithOne(x => x.Personne)
                .HasForeignKey(e => e.PersonneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Documents)
                .WithOne(x => x.Personne)
                .HasForeignKey(e => e.PersonneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Adresses)
                .WithOne(x => x.Personne)
                .HasForeignKey(e => e.PersonneId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
