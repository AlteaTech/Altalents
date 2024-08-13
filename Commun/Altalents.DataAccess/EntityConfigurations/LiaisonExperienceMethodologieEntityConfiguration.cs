namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonExperienceMethodologieEntityConfiguration : IEntityTypeConfiguration<LiaisonExperienceMethodologie>
    {
        public void Configure(EntityTypeBuilder<LiaisonExperienceMethodologie> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonExperienceMethodologie>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceMethodologies");
        }
    }
}
