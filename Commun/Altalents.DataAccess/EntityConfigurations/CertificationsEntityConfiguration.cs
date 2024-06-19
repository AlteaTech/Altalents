namespace Altalents.DataAccess.EntityConfigurations
{
    internal class CertificationsEntityConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            EntityTypeBuilderFormationHelper<Certification>.ConfigureBase(builder);
            builder.ToTable("Certifications");
        }
    }
}
