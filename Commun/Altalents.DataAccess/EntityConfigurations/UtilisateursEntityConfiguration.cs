using Altalents.Commun.Enums;

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
            builder.Property(e => e.Telephone)
                .HasMaxLength(100);
            builder.Property(e => e.Poste)
                .HasMaxLength(200);

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

            builder.Property(e => e.TypeCompte)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(navigationExpression: e => e.DossierTechniques)
                .WithOne(x => x.Utilisateur)
                .HasForeignKey(e => e.UtilisateurId)
                .OnDelete(DeleteBehavior.NoAction);

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
                    TypeCompte = TypeUtilisateurEnum.Admin
                }
            });
        }
    }
}
