using AnyAscii;
using Altalents.Commun.Helpers;
using Altalents.Entities.Enum;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class SousReferenceEntityConfiguration : IEntityTypeConfiguration<SousReference>
    {
        public void Configure(EntityTypeBuilder<SousReference> builder)
        {
            EntityTypeBuilderBaseHelper<SousReference>.ConfigureBase(builder);
            builder.ToTable("SousReferences");

            builder.Property(e => e.LibelleFr)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.HasIndex(e => new { e.ReferenceId, e.LibelleFr }).IsUnique();

            builder.Property(e => e.Libelle2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.LibelleTransLitLower2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.LibelleTransLitLowerFr)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.HasOne(d => d.Reference)
                    .WithMany(p => p.SousReferences)
                    .HasForeignKey(d => d.ReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(e => new { e.OrdreFr, e.LibelleFr });
            builder.HasIndex(e => new { e.Ordre2, e.Libelle2 });

            Array enumSousReferences = Enum.GetValues(typeof(EnumSousReference));
            List<SousReference> sousReferences = new List<SousReference>();
            foreach (EnumSousReference enumSousReference in enumSousReferences)
            {
                sousReferences.Add(new SousReference()
                {
                    Id = enumSousReference.GetBddId(),
                    DateCrea = enumSousReference.GetDateCreation(),
                    ReferenceId = enumSousReference.GetReferenceIdForSousReferenceAttribute(),
                    LibelleFr = enumSousReference.GetLibelleFrForSousReferenceAttribute(),
                    Libelle2 = enumSousReference.GetLibelle2ForSousReferenceAttribute(),
                    LibelleTransLitLowerFr = StringsHelpers.HtmlToPlainText(enumSousReference.GetLibelleFrForSousReferenceAttribute()).Transliterate().ToLower(),
                    LibelleTransLitLower2 = StringsHelpers.HtmlToPlainText(enumSousReference.GetLibelle2ForSousReferenceAttribute()).Transliterate().ToLower(),
                    OrdreFr = enumSousReference.GetOrdreFrForSousReferenceAttribute(),
                    Ordre2 = enumSousReference.GetOrdre2ForSousReferenceAttribute(),
                    UtiCrea = "ALTEA"
                });
            }
            builder.HasData(sousReferences);
        }
    }
}
