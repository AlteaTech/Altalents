namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonExperienceMethodologieEntityConfiguration : IEntityTypeConfiguration<LiaisonProjetMethodologie>
    {
        public void Configure(EntityTypeBuilder<LiaisonProjetMethodologie> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonProjetMethodologie>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceMethodologies");
        }
    }
}
