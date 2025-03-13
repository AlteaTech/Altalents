using Altalents.Entities.BaseEntities;

using AlteaTools.EntityFramework.Helper;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altalents.Entities.Extensions
{
    public static class EntityTypeBuilderFileHelper<T> where T : FileEntity
    {
        public static void ConfigureBase(EntityTypeBuilder<T> builder)
        {
            EntityTypeBuilderBaseHelper<T>.ConfigureBase(builder);

            builder.Property(e => e.Nom)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Data)
                .IsRequired();

            builder.Property(e => e.MimeType)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();
        }
    }

}
