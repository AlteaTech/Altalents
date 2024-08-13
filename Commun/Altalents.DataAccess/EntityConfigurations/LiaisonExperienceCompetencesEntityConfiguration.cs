namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonExperienceCompetencesEntityConfiguration : IEntityTypeConfiguration<LiaisonExperienceCompetence>
    {
        public void Configure(EntityTypeBuilder<LiaisonExperienceCompetence> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonExperienceCompetence>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceCompetences");
        }
    }
}
