namespace Altalents.DataAccess.EntityConfigurations
{
    internal class DossierTechniqueLanguesEntityConfiguration : IEntityTypeConfiguration<DossierTechniqueLangue>
    {
        public void Configure(EntityTypeBuilder<DossierTechniqueLangue> builder)
        {
            EntityTypeBuilderBaseHelper<DossierTechniqueLangue>.ConfigureBase(builder);
            builder.ToTable("DossierTechniqueLangues");


        }
    }
}
