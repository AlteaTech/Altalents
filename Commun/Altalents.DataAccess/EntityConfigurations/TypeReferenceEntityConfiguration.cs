namespace Altalents.DataAccess.EntityConfigurations
{
    internal class TypeReferenceEntityConfiguration : IEntityTypeConfiguration<TypeReference>
    {
        public void Configure(EntityTypeBuilder<TypeReference> builder)
        {
            EntityTypeBuilderBaseHelper<TypeReference>.ConfigureBase(builder);
            builder.ToTable("TypesReferences");

            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Libelle)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.HasIndex(e => new { e.Ordre, e.Libelle });

            Array enumTypeReferences = Enum.GetValues(typeof(EnumTypeReference));
            List<TypeReference> typeReferences = new List<TypeReference>();
            foreach (EnumTypeReference enumTypeReference in enumTypeReferences)
            {
                typeReferences.Add(new TypeReference()
                {
                    Code = enumTypeReference.ToString("g"),
                    Id = enumTypeReference.GetBddId(),
                    DateCrea = enumTypeReference.GetDateCreation(),
                    Libelle = enumTypeReference.GetDisplayName(toLower: false),
                    Ordre = enumTypeReference.GetOrdreForTypeReferenceAttribute(),
                    WithSecondeLangue = enumTypeReference.GetWithSecondeLangueForTypeReferenceAttribute(),
                    WithSousReference = enumTypeReference.GetWithSousReferenceForTypeReferenceAttribute(),
                    UtiCrea = "ALTEA"
                });
            }
            builder.HasData(typeReferences);
        }
    }
}
