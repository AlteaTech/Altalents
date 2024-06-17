namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueReferenceLibreEntityConfiguration : IEntityTypeConfiguration<MarqueReferenceLibre>
    {
        public void Configure(EntityTypeBuilder<MarqueReferenceLibre> builder)
        {
            EntityTypeBuilderBaseHelper<MarqueReferenceLibre>.ConfigureBase(builder);

            builder.ToTable("MarqueReferenceLibres");

            builder.Property(p => p.Type)
                .HasColumnType("varchar(250)");

            builder.HasOne(d => d.Marque)
                   .WithMany(p => p.MarqueReferenceLibres)
                   .HasForeignKey(d => d.MarqueId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.Type });
        }
    }
}
