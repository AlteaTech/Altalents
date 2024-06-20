namespace Altalents.DataAccess.EntityConfigurations
{
    internal class DossierTechniquesEntityConfiguration : IEntityTypeConfiguration<DossierTechnique>
    {
        public void Configure(EntityTypeBuilder<DossierTechnique> builder)
        {
            EntityTypeBuilderBaseHelper<DossierTechnique>.ConfigureBase(builder);
            builder.ToTable("DossierTechniques");

            builder.HasMany(navigationExpression: e => e.DocumentComplementaires)
                .WithOne(x => x.DossierTechnique)
                .HasForeignKey(e => e.DossierTechniqueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.QuestionDossierTechniques)
                .WithOne(x => x.DossierTechnique)
                .HasForeignKey(e => e.DossierTechniqueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.Formations)
                .WithOne(x => x.DossierTechnique)
                .HasForeignKey(e => e.DossierTechniqueId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Certifications)
                .WithOne(x => x.DossierTechnique)
                .HasForeignKey(e => e.DossierTechniqueId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Experiences)
                .WithOne(x => x.DossierTechnique)
                .HasForeignKey(e => e.DossierTechniqueId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.DossierTechniqueLangues)
                .WithOne(x => x.DossierTechnique)
                .HasForeignKey(e => e.DossierTechniqueId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
