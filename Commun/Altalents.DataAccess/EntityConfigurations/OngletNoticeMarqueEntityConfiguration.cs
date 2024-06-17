namespace Altalents.DataAccess.EntityConfigurations
{
    internal class OngletNoticeMarqueEntityConfiguration : IEntityTypeConfiguration<OngletNoticeMarque>
    {
        public void Configure(EntityTypeBuilder<OngletNoticeMarque> builder)
        {
            EntityTypeBuilderBaseHelper<OngletNoticeMarque>.ConfigureBase(builder);
            builder.ToTable("OngletsNoticeMarque");

            builder.Property(e => e.Libelle)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.HasIndex(e => new { e.Ordre });

            Array enumOngletsNoticesMarques = Enum.GetValues(typeof(EnumOngletNoticeMarque));
            List<OngletNoticeMarque> ongletsNoticesMarques = new();
            foreach (EnumOngletNoticeMarque enumOngletNoticeMarque in enumOngletsNoticesMarques)
            {
                ongletsNoticesMarques.Add(new OngletNoticeMarque()
                {
                    Id = enumOngletNoticeMarque.GetBddId(),
                    DateCrea = enumOngletNoticeMarque.GetDateCreation(),
                    Libelle = enumOngletNoticeMarque.GetLibelleForOngletNoticeMarqueAttribute(),
                    Ordre = enumOngletNoticeMarque.GetOrdreForOngletNoticeMarqueAttribute(),
                    IsDefaultCreation = enumOngletNoticeMarque.GetIsDefaultCreationForOngletNoticeMarqueAttribute(),
                    UtiCrea = "ALTEA",
                    IsSupprimable = false
                });

            }
            builder.HasData(ongletsNoticesMarques);
        }
    }
}
