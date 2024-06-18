using static Altalents.Entities.Extensions.EnumExtensionMethod;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class DocumentComplementairesEntityConfiguration : IEntityTypeConfiguration<DocumentComplementaire>
    {
        public void Configure(EntityTypeBuilder<DocumentComplementaire> builder)
        {
            EntityTypeBuilderFileHelper<DocumentComplementaire>.ConfigureBase(builder);
            builder.ToTable("DocumentComplementaires");


            builder.Property(e => e.Commentaire)
                .HasColumnType("varchar(max)");

        }
    }
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
