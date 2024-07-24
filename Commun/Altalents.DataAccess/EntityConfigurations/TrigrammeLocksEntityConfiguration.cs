namespace Altalents.DataAccess.EntityConfigurations
{
    internal class TrigrammeLocksEntityConfiguration : IEntityTypeConfiguration<TrigrammeLock>
    {
        public void Configure(EntityTypeBuilder<TrigrammeLock> builder)
        {
            builder.ToTable("TrigrammeLocks").HasKey(e => e.Trigramme);

            builder.Property(e => e.Trigramme)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.DateLock).HasColumnType("datetime");
            builder.HasIndex(e => e.DateLock);
        }
    }
}
