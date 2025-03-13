namespace Altalents.DataAccess.EntityConfigurations
{
    internal class LiaisonProjetOutilEntityConfiguration : IEntityTypeConfiguration<LiaisonProjetOutil>
    {
        public void Configure(EntityTypeBuilder<LiaisonProjetOutil> builder)
        {
            EntityTypeBuilderBaseHelper<LiaisonProjetOutil>.ConfigureBase(builder);
            builder.ToTable("LiaisonExperienceOutils");
        }
    }
}
