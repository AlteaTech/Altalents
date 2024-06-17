using AnyAscii;
using Altalents.Commun.Helpers;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class ReferenceEntityConfiguration : IEntityTypeConfiguration<Reference>
    {
        public void Configure(EntityTypeBuilder<Reference> builder)
        {
            EntityTypeBuilderBaseHelper<Reference>.ConfigureBase(builder);
            builder.HasIndex(e => new { e.TypeReferenceId, e.LibelleFr }).IsUnique();
            builder.ToTable("References");

            builder.Property(e => e.Libelle2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.LibelleFr)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.LibelleTransLitLower2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.LibelleTransLitLowerFr)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.HasOne(d => d.TypeReference)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.TypeReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(e => new { e.Ordre, e.LibelleFr });
            builder.HasIndex(e => new { e.Ordre2, e.Libelle2 });


            builder.HasIndex(e => new { e.LibelleFr, e.Libelle2 });
            builder.HasIndex(e => new { e.Libelle2 });

            Array enumReferences = Enum.GetValues(typeof(EnumReference));
            List<Reference> references = new List<Reference>();
            foreach (EnumReference enumReference in enumReferences)
            {
                references.Add(new Reference()
                {
                    Id = enumReference.GetBddId(),
                    DateCrea = enumReference.GetDateCreation(),
                    TypeReferenceId = enumReference.GetTypeReferenceIdForReferenceAttribute(),
                    LibelleFr = enumReference.GetLibelleFrForReferenceAttribute(),
                    Libelle2 = enumReference.GetLibelle2ForReferenceAttribute(),
                    LibelleTransLitLowerFr = StringsHelpers.HtmlToPlainText(enumReference.GetLibelleFrForReferenceAttribute()).Transliterate().ToLower(),
                    LibelleTransLitLower2 = StringsHelpers.HtmlToPlainText(enumReference.GetLibelle2ForReferenceAttribute()).Transliterate().ToLower(),
                    Ordre = enumReference.GetOrdreFrForReferenceAttribute(),
                    Ordre2 = enumReference.GetOrdre2ForReferenceAttribute(),
                    UtiCrea = "ALTEA"
                });

            }
            builder.HasData(references);
        }
    }
}
