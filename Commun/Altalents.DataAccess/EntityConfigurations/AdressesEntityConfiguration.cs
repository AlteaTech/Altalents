namespace Altalents.DataAccess.EntityConfigurations
{
    internal class AdressesEntityConfiguration : IEntityTypeConfiguration<Adresse>
    {
        public void Configure(EntityTypeBuilder<Adresse> builder)
        {
            EntityTypeBuilderBaseHelper<Adresse>.ConfigureBase(builder);
            builder.ToTable("Adresses");

            builder.Property(e => e.Adresse1)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.Adresse2)
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
            builder.Property(e => e.Adresse1)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.CodePostal)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(e => e.Ville)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}
