using Altalents.Commun.Constants;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class MarqueEntityConfiguration : IEntityTypeConfiguration<Marque>
    {
        public void Configure(EntityTypeBuilder<Marque> builder)
        {
            EntityTypeBuilderBaseHelper<Marque>.ConfigureBase(builder);
            builder.ToTable("Marques");

            builder.Property(e => e.ReferenceLugt)
                .HasMaxLength(MaxSizeConstantes.MARQUE_NUMERO_LUGT)
                .IsUnicode(false);

            builder.Property(e => e.ReferenceLugtLight)
                .HasMaxLength(MaxSizeConstantes.MARQUE_NUMERO_LUGT)
                .IsUnicode(false);

            builder.Property(e => e.Initiales)
                .HasMaxLength(MaxSizeConstantes.MARQUE_INITIALES)
                .IsUnicode(false);

            builder.Property(e => e.InitialesTransLitLowerFr)
                .HasMaxLength(MaxSizeConstantes.MARQUE_INITIALES)
                .IsUnicode(false);

            builder.Property(e => e.AncienIdAltalents)
                .HasMaxLength(400)
                .IsUnicode(false);

            builder.Property(e => e.Hauteur).HasColumnType("decimal(18, 10)");
            builder.Property(e => e.Largeur).HasColumnType("decimal(18, 10)");

            builder.HasIndex(e => new { e.NumeroLugt, e.ReferenceLugtLight });
            builder.HasIndex(e => new { e.AncienIdAltalents });
            builder.HasIndex(e => new { e.Initiales, e.NumeroLugt, e.ReferenceLugtLight });
            builder.HasIndex(e => new { e.NumeroLugt, e.ReferenceLugt });
            builder.HasIndex(e => new { e.IsFinalize, e.DatePublication });
            builder.HasIndex(e => new { e.ReferenceLugt, e.IsFinalize })
                   .IsUnique();
            builder.HasIndex(e => new { e.ReferenceLugtLight })
                   .IsUnique();
        }
    }
}
