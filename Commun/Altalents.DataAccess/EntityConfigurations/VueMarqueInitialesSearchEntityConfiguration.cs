namespace Altalents.DataAccess.EntityConfigurations
{
    internal class VueMarqueInitialesSearchEntityConfiguration : IEntityTypeConfiguration<VueMarqueInitialesSearch>
    {
        public void Configure(EntityTypeBuilder<VueMarqueInitialesSearch> builder)
        {
            EntityTypeBuilderBaseHelper<VueMarqueInitialesSearch>.ConfigureBase(builder);

            builder.ToTable("VueMarqueInitialesSearch");

            builder.HasOne(d => d.Marque)
                   .WithMany(p => p.VueMarqueInitialesSearchs)
                   .HasForeignKey(d => d.MarqueId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.MarqueId, e.TexteTransLitLowerFr, e.Total });
            builder.HasIndex(e => new { e.TexteTransLitLowerFr, e.Total });
        }
    }
}
