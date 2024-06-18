using static Altalents.Entities.Extensions.EnumExtensionMethod;

namespace Altalents.DataAccess.EntityConfigurations
{
    internal class FormationsEntityConfiguration : IEntityTypeConfiguration<Formation>
    {
        public void Configure(EntityTypeBuilder<Formation> builder)
        {
            EntityTypeBuilderFormationHelper<Formation>.ConfigureBase(builder);
            builder.ToTable("Formations");
        }
    }
}
