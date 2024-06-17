namespace Altalents.DataAccess.EntityConfigurations
{
    internal class UtilisateursEntityConfiguration : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            EntityTypeBuilderBaseHelper<Utilisateur>.ConfigureBase(builder);
            builder.ToTable("Utilisateurs");

            builder.Property(e => e.Nom)
                .HasMaxLength(100);

            builder.Property(e => e.Login)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.MotDePasseCrypte)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.IsActif)
                .IsRequired();

            builder.Property(e => e.IsSupprimable)
                .IsRequired();

            builder.Property(e => e.IsModifiable)
                .IsRequired();

            builder.HasIndex(e => e.Nom);
            builder.HasIndex(e => e.Login).IsUnique();

            builder.HasData(new List<Utilisateur> {
                new Utilisateur(){
                    Nom = "Super administrateur",
                    Id = Guid.Parse("{F05D0F23-00B2-47FE-91AB-59EBEAA867EE}"),
                    DateCrea = new DateTime(2021, 4, 22),
                    UtiCrea= "ALTEA",
                    Login = "admin",
                    MotDePasseCrypte = "AQAAAAIAAYagAAAAEJJ8k1QzsOQCivB/OZ4fO3oRItU9ubWJwyTeSVD8FisyZN0vG9+vG72E5MCF35op2w==",
                    Email = "vlarguier@altea-si.com",
                    IsActif = true,
                    IsSupprimable = false,
                    IsModifiable = false,
                },
                new Utilisateur(){
                    Nom = "Rhea",
                    Id = Guid.Parse("{8DBB6E85-B206-4A61-853E-736F7262E317}"),
                    DateCrea = new DateTime(2023, 5, 4),
                    UtiCrea= "ALTEA",
                    Login = "Kolb",
                    MotDePasseCrypte = "AQAAAAIAAYagAAAAEORXWMmOL09K5Hw4hq9n/i7RFz5WbYH27+XaGvlcJADKOPosPP+a9R91OVHRBS7ASg==",
                    Email = "rsblok@fondationAltalents.fr",
                    IsActif = true,
                    IsSupprimable = false,
                    IsModifiable = true,
                },
                new Utilisateur(){
                    Nom = "Marie-Claire",
                    Id = Guid.Parse("{D88C83CF-8203-46BD-821F-F9AF527B2703}"),
                    DateCrea = new DateTime(2023, 5, 4),
                    UtiCrea= "ALTEA",
                    Login = "MC",
                    MotDePasseCrypte = "AQAAAAIAAYagAAAAEORXWMmOL09K5Hw4hq9n/i7RFz5WbYH27+XaGvlcJADKOPosPP+a9R91OVHRBS7ASg==",
                    Email = "mcnathan@fondationAltalents.fr",
                    IsActif = true,
                    IsSupprimable = false,
                    IsModifiable = true,
                },
                new Utilisateur(){
                    Nom = "Laurence",
                    Id = Guid.Parse("{8155F3B1-08A2-402E-9807-1E7D17307848}"),
                    DateCrea = new DateTime(2023, 5, 4),
                    UtiCrea= "ALTEA",
                    Login = "laurence",
                    MotDePasseCrypte = "AQAAAAIAAYagAAAAEORXWMmOL09K5Hw4hq9n/i7RFz5WbYH27+XaGvlcJADKOPosPP+a9R91OVHRBS7ASg==",
                    Email = "l.lhinares@fondationAltalents.fr",
                    IsActif = true,
                    IsSupprimable = false,
                    IsModifiable = true,
                }
            });
        }
    }
}
