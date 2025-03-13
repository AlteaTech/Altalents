namespace Altalents.DataAccess.EntityConfigurations
{
    internal class ContactsEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            EntityTypeBuilderBaseHelper<Contact>.ConfigureBase(builder);
            builder.ToTable("Contacts");

            builder.Property(e => e.Valeur)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}
