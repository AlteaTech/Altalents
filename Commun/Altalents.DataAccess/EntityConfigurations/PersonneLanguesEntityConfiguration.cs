namespace Altalents.DataAccess.EntityConfigurations
{
    internal class PersonneLanguesEntityConfiguration : IEntityTypeConfiguration<PersonneLangue>
    {
        public void Configure(EntityTypeBuilder<PersonneLangue> builder)
        {
            EntityTypeBuilderBaseHelper<PersonneLangue>.ConfigureBase(builder);
            builder.ToTable("PersonneLangues");

            builder.Property(e => e.Niveau)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
