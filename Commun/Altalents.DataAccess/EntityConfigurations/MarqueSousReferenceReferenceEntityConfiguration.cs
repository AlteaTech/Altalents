namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueSousReferenceReferenceEntityConfiguration : IEntityTypeConfiguration<MarqueSousReferenceReference>
    {
        public void Configure(EntityTypeBuilder<MarqueSousReferenceReference> builder)
        {
            EntityTypeBuilderBaseHelper<MarqueSousReferenceReference>.ConfigureBase(builder);

            builder.ToTable("MarqueSousReferenceReferences");

            builder.HasOne(d => d.Marque)
                    .WithMany(p => p.MarqueSousReferenceReferences)
                    .HasForeignKey(d => d.MarqueId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.SousReference)
                    .WithMany(p => p.MarqueSousReferenceReferences)
                    .HasForeignKey(d => d.SousReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Reference)
                    .WithMany(p => p.MarqueSousReferenceReferences)
                    .HasForeignKey(d => d.ReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(e => new
            {
                e.MarqueId,
                e.IsPrincipal,
                e.ReferenceId
            });

            builder.HasIndex(e => new
            {
                e.IsPrincipal
            });
        }
    }
}
