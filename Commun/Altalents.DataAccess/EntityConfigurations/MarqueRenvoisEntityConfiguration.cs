namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueRenvoisEntityConfiguration : IEntityTypeConfiguration<MarqueRenvois>
    {
        public void Configure(EntityTypeBuilder<MarqueRenvois> builder)
        {
            EntityTypeBuilderBaseHelper<MarqueRenvois>.ConfigureBase(builder);
            builder.ToTable("MarquesRenvois");

            builder.HasOne(d => d.Marque1)
                   .WithMany(p => p.MarqueRenvois1)
                   .HasForeignKey(d => d.MarqueId1)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Marque2)
                   .WithMany(p => p.MarqueRenvois2)
                   .HasForeignKey(d => d.MarqueId2)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(e => new { e.MarqueId2 });
            builder.HasIndex(e => new { e.MarqueId1, e.MarqueId2 })
                   .IsUnique();
        }
    }
}
