namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonExperienceCompetancesEntityConfiguration : IEntityTypeConfiguration<LiaisonExperienceCompetance>
    {
        public void Configure(EntityTypeBuilder<LiaisonExperienceCompetance> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonExperienceCompetance>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceCompetances");
        }
    }
}
