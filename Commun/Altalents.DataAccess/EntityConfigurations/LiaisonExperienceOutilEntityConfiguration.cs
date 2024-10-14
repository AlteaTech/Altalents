namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonExperienceOutilEntityConfiguration : IEntityTypeConfiguration<LiaisonExperienceOutil>
    {
        public void Configure(EntityTypeBuilder<LiaisonExperienceOutil> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonExperienceOutil>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceOutils");
        }
    }
}
