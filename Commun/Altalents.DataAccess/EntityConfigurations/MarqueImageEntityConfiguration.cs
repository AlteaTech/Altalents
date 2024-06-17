namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueImageEntityConfiguration : IEntityTypeConfiguration<MarqueImage>
    {
        public void Configure(EntityTypeBuilder<MarqueImage> builder)
        {
            EntityTypeBuilderBaseHelper<MarqueImage>.ConfigureBase(builder);

            builder.ToTable("MarqueImages");
            builder.Property(e => e.NomFichier)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.FullPath).IsRequired()
                .HasMaxLength(400);

            builder.HasIndex(e => new { e.Ordre });

            builder.HasOne(d => d.Marque)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.MarqueId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
