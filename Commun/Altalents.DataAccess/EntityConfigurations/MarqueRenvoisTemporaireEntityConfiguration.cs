namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueRenvoisTemporaireEntityConfiguration : IEntityTypeConfiguration<MarqueRenvoisTemporaire>
    {
        public void Configure(EntityTypeBuilder<MarqueRenvoisTemporaire> builder)
        {
            EntityTypeBuilderBaseHelper<MarqueRenvoisTemporaire>.ConfigureBase(builder);
            builder.ToTable("MarquesRenvoisTemporaires");

            builder.HasIndex(e => new { e.MarqueId2 });
            builder.HasIndex(e => new { e.MarqueIdTravail });
            builder.HasIndex(e => new { e.MarqueId1, e.MarqueId2, e.MarqueIdTravail })
                   .IsUnique();
        }
    }
}
