namespace Altalents.DataAccess.EntityConfigurations
{
    internal class ReferenceEntityConfiguration : IEntityTypeConfiguration<Reference>
    {
        public void Configure(EntityTypeBuilder<Reference> builder)
        {
            EntityTypeBuilderBaseHelper<Reference>.ConfigureBase(builder);
            builder.ToTable("References");

            builder.Property(e => e.Libelle)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.OrdreTri)
                .HasDefaultValue(0)
                .IsRequired();
            builder.Property(e => e.SousType)
                .HasColumnType("varchar")
                .HasMaxLength(250);


            builder.HasMany(navigationExpression: e => e.DossierTechniques)
                .WithOne(x => x.Disponibilite)
                .HasForeignKey(e => e.DisponibiliteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.Personnes)
                .WithOne(x => x.Type)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.Type, e.SousType });

            builder.HasData(new List<Reference> {
                #region Langues
                new Reference(){
                    Libelle = "Anglais",
                    Id = Guid.Parse("{cc2fe62f-a81d-437b-a257-7e89b150042e}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Arabe",
                    Id = Guid.Parse("{2ad460a4-afa9-4ac0-986f-42d626b82bf1}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Chinois",
                    Id = Guid.Parse("{e47e9d1a-590d-4b4a-8f9e-219781d36902}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Espagnol",
                    Id = Guid.Parse("{91cad6f6-cfb2-43bc-b5f5-a1e90ceba77c}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Français",
                    Id = Guid.Parse("{356fce26-caaa-4b4e-94d2-f7341d1851b1}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Russe",
                    Id = Guid.Parse("{3fbcdd3e-7dfa-46bb-bf5d-ae39e4137a07}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Albanais",
                    Id = Guid.Parse("{cfb960f2-d501-4154-a53a-83f9497bc0ad}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Allemand",
                    Id = Guid.Parse("{fe2be6bb-fbda-4115-bc06-5603447cbcbd}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Amazigh",
                    Id = Guid.Parse("{9a5769e9-f63f-4f30-85d6-c785247a621a}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Arménien",
                    Id = Guid.Parse("{3ca6db24-303d-4fa3-9b5b-5cd8cfd02f11}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Aymara",
                    Id = Guid.Parse("{8883e43d-9d64-4976-a0de-cf2fce12c00d}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Bengali",
                    Id = Guid.Parse("{f3e4d4b8-4406-4098-ae7f-1ccbf938c5b8}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Catalan",
                    Id = Guid.Parse("{389314c5-b5b2-4055-85ef-a0a688b71d1c}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Coréen",
                    Id = Guid.Parse("{560f923c-27de-4891-8e96-db9fe47ca235}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Croate",
                    Id = Guid.Parse("{077fa7cc-9f80-4d11-a791-1109ec17987b}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Danois",
                    Id = Guid.Parse("{eb36539d-64bd-4cd7-adc9-27fe1c30a039}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Éwé",
                    Id = Guid.Parse("{41fb2299-36ec-4854-bc78-ee7899af318f}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Guarani",
                    Id = Guid.Parse("{57580b70-c631-4d9c-8dfa-920b54bfbfaf}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Grec",
                    Id = Guid.Parse("{1fbfbf6e-957e-4565-afd1-173b5cd709d3}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Hongrois",
                    Id = Guid.Parse("{b25017fe-4709-474d-9d28-73489c12730b}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Italien",
                    Id = Guid.Parse("{b78239d4-c118-4887-8296-8494cef315bc}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Japonais",
                    Id = Guid.Parse("{e673effc-4ca5-46d4-bba8-0c4e5c658cb5}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Kikongo",
                    Id = Guid.Parse("{21a7b72e-456c-4b07-9cda-125917d43396}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Kiswahili",
                    Id = Guid.Parse("{25c764de-a813-4848-9d13-2ffea2a2ca44}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Lingala",
                    Id = Guid.Parse("{09bf9503-dea6-4133-a3de-49d8cdcfcdc9}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Malgache",
                    Id = Guid.Parse("{792a266d-f629-419a-8346-59400b460b2d}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Malais",
                    Id = Guid.Parse("{224a6eb6-c5c0-44a2-8504-46fa0f158527}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Mongol",
                    Id = Guid.Parse("{5ecd41d8-0a66-4315-b489-b26582e78e47}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Néerlandais",
                    Id = Guid.Parse("{ac04b377-a830-43cc-b249-3ace079a4e61}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Occitan",
                    Id = Guid.Parse("{bb490fb1-c45c-4735-ac44-3524dde36275}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Ourdou",
                    Id = Guid.Parse("{7dc19496-4d9b-413a-b088-090da9f29a08}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Persan",
                    Id = Guid.Parse("{f2ed3127-4acd-4e4b-90b2-b51958dc1357}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Portugais",
                    Id = Guid.Parse("{39577e09-4464-41bc-b9ad-e69b03ba3266}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Quechua",
                    Id = Guid.Parse("{0f6fda7c-e474-4196-8afb-1bab65bacfd1}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Roumain",
                    Id = Guid.Parse("{05c38683-5c3a-43a9-a603-c553e429ab99}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Samoan",
                    Id = Guid.Parse("{d63f7ab4-b41c-40f5-867b-03b2a7571aca}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Serbe",
                    Id = Guid.Parse("{3b004521-dc2f-43ec-bd60-5e8c95aa9dae}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Sesotho",
                    Id = Guid.Parse("{cf3524e8-53a1-4170-81a0-191ebe2e9507}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Slovaque",
                    Id = Guid.Parse("{9ed8dd18-affb-4a96-b35a-d0ed17943492}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Slovène",
                    Id = Guid.Parse("{3329384f-af76-4eb6-9f15-b8b838af7999}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Suédois",
                    Id = Guid.Parse("{d4a4a33a-f5d3-488c-89ad-7f552d262b88}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Tamoul",
                    Id = Guid.Parse("{b809599c-6b49-452a-b26c-7438c059bbf8}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                new Reference(){
                    Libelle = "Turc",
                    Id = Guid.Parse("{1aeef696-c31e-4987-84f3-2215a98bf350}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Langue
                },
                #endregion
                #region Disponibilite
                new Reference(){
                    Libelle = "Immédiate",
                    Id = Guid.Parse("{8f486cd6-6313-47f9-a4b5-5bd535c199a9}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Disponibilite,
                    OrdreTri = 1
                },
                new Reference(){
                    Libelle = "Sous un mois",
                    Id = Guid.Parse("{92dfd90f-79b4-4d5e-93e6-fb7046b3416a}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Disponibilite,
                    OrdreTri = 2
                },
                new Reference(){
                    Libelle = "Sous trois mois",
                    Id = Guid.Parse("{f35745ef-66d0-4cb0-9657-b57c2f149e3f}"),
                    DateCrea = new DateTime(2024,6,17),
                    UtiCrea= "ALTEA",
                    Type = Commun.Enums.TypeReferenceEnum.Disponibilite,
                    OrdreTri = 3
                },
                #endregion
            });
        }
    }
}
