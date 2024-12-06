namespace Altalents.DataAccess.EntityConfigurations
{
    internal class DocumentEntityConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            EntityTypeBuilderFileHelper<Document>.ConfigureBase(builder);
            builder.ToTable("Documents");

            builder.Property(e => e.TypeDocument)
            .HasColumnType("varchar")
            .HasMaxLength(250)
            .IsRequired();

            builder.Property(e => e.Nom)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}
