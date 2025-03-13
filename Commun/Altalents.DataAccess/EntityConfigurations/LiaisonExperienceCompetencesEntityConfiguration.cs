namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonProjetCompetencesEntityConfiguration : IEntityTypeConfiguration<LiaisonProjetCompetence>
    {
        public void Configure(EntityTypeBuilder<LiaisonProjetCompetence> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonProjetCompetence>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceCompetences");
        }
    }
}
