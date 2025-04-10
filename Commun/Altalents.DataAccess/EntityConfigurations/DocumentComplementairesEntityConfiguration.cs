namespace Altalents.DataAccess.EntityConfigurations
{
    internal class DocumentComplementairesEntityConfiguration : IEntityTypeConfiguration<DocumentComplementaire>
    {
        public void Configure(EntityTypeBuilder<DocumentComplementaire> builder)
        {
            EntityTypeBuilderFileHelper<DocumentComplementaire>.ConfigureBase(builder);
            builder.ToTable("DocumentComplementaires");

            builder.Property(e => e.TypeDocument)
            .HasColumnType("varchar")
            .HasMaxLength(250)
            .IsRequired();

            builder.Property(e => e.Commentaire)
                .HasColumnType("varchar(max)");

        }
    }
}
