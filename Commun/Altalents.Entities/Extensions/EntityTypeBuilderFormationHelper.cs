using Altalents.Entities.BaseEntities;

using AlteaTools.EntityFramework.Helper;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altalents.Entities.Extensions
{
    public static class EntityTypeBuilderFormationHelper<T> where T : BaseFormationEntity
    {
        public static void ConfigureBase(EntityTypeBuilder<T> builder)
        {
            EntityTypeBuilderBaseHelper<T>.ConfigureBase(builder);

            builder.Property(e => e.Libelle)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.Niveau)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(e => e.DateFin)
                .HasColumnType("datetime");
            builder.Property(e => e.Organisme)
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
        }
    }

}
