namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueNoticesEntityConfiguration : IEntityTypeConfiguration<MarqueNotice>
    {
        public void Configure(EntityTypeBuilder<MarqueNotice> builder)
        {
            EntityTypeBuilderBaseHelper<MarqueNotice>.ConfigureBase(builder);

            builder.ToTable("MarqueNotices");

            builder.HasOne(d => d.Marque)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.MarqueId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.OngletNoticeMarque)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.OngletNoticeMarqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(e => new { e.MarqueId, e.OngletNoticeMarqueId })
                   .IsUnique();
        }
    }
}
