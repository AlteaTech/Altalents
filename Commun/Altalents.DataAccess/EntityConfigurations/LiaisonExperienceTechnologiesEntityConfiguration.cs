namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonProjetTechnologiesEntityConfiguration : IEntityTypeConfiguration<LiaisonProjetTechnologie>
    {
        public void Configure(EntityTypeBuilder<LiaisonProjetTechnologie> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonProjetTechnologie>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceTechnologies");
        }
    }
}
