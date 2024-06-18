namespace Altalents.DataAccess.EntityConfigurations
{
    internal class QuestionDocumentComplementairesEntityConfiguration : IEntityTypeConfiguration<QuestionDossierTechnique>
    {
        public void Configure(EntityTypeBuilder<QuestionDossierTechnique> builder)
        {
            EntityTypeBuilderBaseHelper<QuestionDossierTechnique>.ConfigureBase(builder);
            builder.ToTable("QuestionDossierTechniques");

            builder.Property(e => e.Question)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Reponse)
                .HasColumnType("varchar(max)");
        }
    }
}
