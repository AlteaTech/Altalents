namespace Altalents.DataAccess.EntityConfigurations
{
    internal class PersonneLanguesEntityConfiguration : IEntityTypeConfiguration<DossierTechniqueLangue>
    {
        public void Configure(EntityTypeBuilder<DossierTechniqueLangue> builder)
        {
            EntityTypeBuilderBaseHelper<DossierTechniqueLangue>.ConfigureBase(builder);
            builder.ToTable("DossierTechniqueLangues");

            builder.Property(e => e.Niveau)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
