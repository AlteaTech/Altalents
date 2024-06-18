namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonExperienceTechnologiesEntityConfiguration : IEntityTypeConfiguration<LiaisonExperienceTechnologie>
    {
        public void Configure(EntityTypeBuilder<LiaisonExperienceTechnologie> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonExperienceTechnologie>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceTechnologies");
        }
    }
}
