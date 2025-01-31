using Altalents.Commun.Constants;

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

            builder.Property(e => e.CommentaireFun)
 .HasMaxLength(250);

            builder.Property(e => e.Type)
 .HasColumnType("varchar")
 .HasMaxLength(250)
 .IsRequired();

            builder.Property(e => e.Code)
             .HasColumnType("varchar")
             .HasMaxLength(250)
             .IsRequired();
            builder.Property(e => e.OrdreTri)
 .HasDefaultValue(0)
 .IsRequired();
            builder.Property(e => e.SousType)
 .HasColumnType("varchar")
 .HasMaxLength(250);

            builder.HasMany(navigationExpression: e => e.DossierTechniquesByDisponibilite)
 .WithOne(x => x.Disponibilite)
 .HasForeignKey(e => e.DisponibiliteId)
 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.DossierTechniquesByStatut)
 .WithOne(x => x.Statut)
 .HasForeignKey(e => e.StatutId)
 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Personnes)
 .WithOne(x => x.Type)
 .HasForeignKey(e => e.TypeId)
 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.ProjetsOrMissions)
.WithOne(x => x.DomaineMetier)
.HasForeignKey(e => e.DomaineMetierId)
.OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.Contacts)
 .WithOne(x => x.Type)
 .HasForeignKey(e => e.TypeId)
 .OnDelete(DeleteBehavior.Cascade);

 //           builder.HasMany(navigationExpression: e => e.Documents)
 //.WithOne(x => x.Type)
 //.HasForeignKey(e => e.TypeId)
 //.OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(navigationExpression: e => e.PersonneLangues)
 .WithOne(x => x.Langue)
 .HasForeignKey(e => e.LangueId)
 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.NiveauLangues)
.WithOne(x => x.Niveau)
.HasForeignKey(e => e.NiveauId)
.OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.TypeContratExperiences)
 .WithOne(x => x.TypeContrat)
 .HasForeignKey(e => e.TypeContratId)
 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.DomaineExperiences)
.WithOne(x => x.DomaineMetier)
.HasForeignKey(e => e.DomaineMetierId)
.OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetTechnologies)
 .WithOne(x => x.Technologie)
 .HasForeignKey(e => e.TechnologieId)
 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetCompetences)
 .WithOne(x => x.Competence)
 .HasForeignKey(e => e.CompetenceId)
 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetMethodologies)
 .WithOne(x => x.Methodologie)
 .HasForeignKey(e => e.MethodologieId)
 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(navigationExpression: e => e.LiaisonProjetOutils)
.WithOne(x => x.Outil)
.HasForeignKey(e => e.OutilId)
.OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(e => new { e.Type, e.SousType });

            builder.HasData(new List<Reference> {
            #region Langues
 new (){
     Libelle = "Anglais",
     Code= Commun.Enums.CodeReferenceEnum.Anglais.ToString("g"),
     Id = Guid.Parse("{cc2fe62f-a81d-437b-a257-7e89b150042e}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Arabe",
     Code= Commun.Enums.CodeReferenceEnum.Arabe.ToString("g"),
     Id = Guid.Parse("{2ad460a4-afa9-4ac0-986f-42d626b82bf1}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Chinois",
     Code= Commun.Enums.CodeReferenceEnum.Chinois.ToString("g"),
     Id = Guid.Parse("{e47e9d1a-590d-4b4a-8f9e-219781d36902}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Espagnol",
     Code= Commun.Enums.CodeReferenceEnum.Espagnol.ToString("g"),
     Id = Guid.Parse("{91cad6f6-cfb2-43bc-b5f5-a1e90ceba77c}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Français",
     Code= Commun.Enums.CodeReferenceEnum.Francais.ToString("g"),
     Id = Guid.Parse("{356fce26-caaa-4b4e-94d2-f7341d1851b1}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Russe",
     Code= Commun.Enums.CodeReferenceEnum.Russe.ToString("g"),
     Id = Guid.Parse("{3fbcdd3e-7dfa-46bb-bf5d-ae39e4137a07}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Albanais",
     Code= Commun.Enums.CodeReferenceEnum.Albanais.ToString("g"),
     Id = Guid.Parse("{cfb960f2-d501-4154-a53a-83f9497bc0ad}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Allemand",
     Code= Commun.Enums.CodeReferenceEnum.Allemand.ToString("g"),
     Id = Guid.Parse("{fe2be6bb-fbda-4115-bc06-5603447cbcbd}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Amazigh",
     Code= Commun.Enums.CodeReferenceEnum.Amazigh.ToString("g"),
     Id = Guid.Parse("{9a5769e9-f63f-4f30-85d6-c785247a621a}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Arménien",
     Code= Commun.Enums.CodeReferenceEnum.Armenien.ToString("g"),
     Id = Guid.Parse("{3ca6db24-303d-4fa3-9b5b-5cd8cfd02f11}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Aymara",
     Code= Commun.Enums.CodeReferenceEnum.Aymara.ToString("g"),
     Id = Guid.Parse("{8883e43d-9d64-4976-a0de-cf2fce12c00d}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Bengali",
     Code= Commun.Enums.CodeReferenceEnum.Bengali.ToString("g"),
     Id = Guid.Parse("{f3e4d4b8-4406-4098-ae7f-1ccbf938c5b8}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Catalan",
     Code= Commun.Enums.CodeReferenceEnum.Catalan.ToString("g"),
     Id = Guid.Parse("{389314c5-b5b2-4055-85ef-a0a688b71d1c}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Coréen",
     Code= Commun.Enums.CodeReferenceEnum.Coreen.ToString("g"),
     Id = Guid.Parse("{560f923c-27de-4891-8e96-db9fe47ca235}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Croate",
     Code= Commun.Enums.CodeReferenceEnum.Croate.ToString("g"),
     Id = Guid.Parse("{077fa7cc-9f80-4d11-a791-1109ec17987b}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Danois",
     Code= Commun.Enums.CodeReferenceEnum.Danois.ToString("g"),
     Id = Guid.Parse("{eb36539d-64bd-4cd7-adc9-27fe1c30a039}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Éwé",
     Code= Commun.Enums.CodeReferenceEnum.Ewe.ToString("g"),
     Id = Guid.Parse("{41fb2299-36ec-4854-bc78-ee7899af318f}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Guarani",
     Code= Commun.Enums.CodeReferenceEnum.Guarani.ToString("g"),
     Id = Guid.Parse("{57580b70-c631-4d9c-8dfa-920b54bfbfaf}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Grec",
     Code= Commun.Enums.CodeReferenceEnum.Grec.ToString("g"),
     Id = Guid.Parse("{1fbfbf6e-957e-4565-afd1-173b5cd709d3}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Hongrois",
     Code= Commun.Enums.CodeReferenceEnum.Hongrois.ToString("g"),
     Id = Guid.Parse("{b25017fe-4709-474d-9d28-73489c12730b}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Italien",
     Code= Commun.Enums.CodeReferenceEnum.Italien.ToString("g"),
     Id = Guid.Parse("{b78239d4-c118-4887-8296-8494cef315bc}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Japonais",
     Code= Commun.Enums.CodeReferenceEnum.Japonais.ToString("g"),
     Id = Guid.Parse("{e673effc-4ca5-46d4-bba8-0c4e5c658cb5}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Kikongo",
     Code= Commun.Enums.CodeReferenceEnum.Kikongo.ToString("g"),
     Id = Guid.Parse("{21a7b72e-456c-4b07-9cda-125917d43396}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Kiswahili",
     Code= Commun.Enums.CodeReferenceEnum.Kiswahili.ToString("g"),
     Id = Guid.Parse("{25c764de-a813-4848-9d13-2ffea2a2ca44}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Lingala",
     Code= Commun.Enums.CodeReferenceEnum.Lingala.ToString("g"),
     Id = Guid.Parse("{09bf9503-dea6-4133-a3de-49d8cdcfcdc9}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Malgache",
     Code= Commun.Enums.CodeReferenceEnum.Malgache.ToString("g"),
     Id = Guid.Parse("{792a266d-f629-419a-8346-59400b460b2d}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Malais",
     Code= Commun.Enums.CodeReferenceEnum.Malais.ToString("g"),
     Id = Guid.Parse("{224a6eb6-c5c0-44a2-8504-46fa0f158527}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Mongol",
     Code= Commun.Enums.CodeReferenceEnum.Mongol.ToString("g"),
     Id = Guid.Parse("{5ecd41d8-0a66-4315-b489-b26582e78e47}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Néerlandais",
     Code= Commun.Enums.CodeReferenceEnum.Neerlandais.ToString("g"),
     Id = Guid.Parse("{ac04b377-a830-43cc-b249-3ace079a4e61}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Occitan",
     Code= Commun.Enums.CodeReferenceEnum.Occitan.ToString("g"),
     Id = Guid.Parse("{bb490fb1-c45c-4735-ac44-3524dde36275}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Ourdou",
     Code= Commun.Enums.CodeReferenceEnum.Ourdou.ToString("g"),
     Id = Guid.Parse("{7dc19496-4d9b-413a-b088-090da9f29a08}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Persan",
     Code= Commun.Enums.CodeReferenceEnum.Persan.ToString("g"),
     Id = Guid.Parse("{f2ed3127-4acd-4e4b-90b2-b51958dc1357}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Portugais",
     Code= Commun.Enums.CodeReferenceEnum.Portugais.ToString("g"),
     Id = Guid.Parse("{39577e09-4464-41bc-b9ad-e69b03ba3266}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Quechua",
     Code= Commun.Enums.CodeReferenceEnum.Quechua.ToString("g"),
     Id = Guid.Parse("{0f6fda7c-e474-4196-8afb-1bab65bacfd1}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Roumain",
     Code= Commun.Enums.CodeReferenceEnum.Roumain.ToString("g"),
     Id = Guid.Parse("{05c38683-5c3a-43a9-a603-c553e429ab99}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Samoan",
     Code= Commun.Enums.CodeReferenceEnum.Samoan.ToString("g"),
     Id = Guid.Parse("{d63f7ab4-b41c-40f5-867b-03b2a7571aca}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Serbe",
     Code= Commun.Enums.CodeReferenceEnum.Serbe.ToString("g"),
     Id = Guid.Parse("{3b004521-dc2f-43ec-bd60-5e8c95aa9dae}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Sesotho",
     Code= Commun.Enums.CodeReferenceEnum.Sesotho.ToString("g"),
     Id = Guid.Parse("{cf3524e8-53a1-4170-81a0-191ebe2e9507}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Slovaque",
     Code= Commun.Enums.CodeReferenceEnum.Slovaque.ToString("g"),
     Id = Guid.Parse("{9ed8dd18-affb-4a96-b35a-d0ed17943492}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Slovène",
     Code= Commun.Enums.CodeReferenceEnum.Slovene.ToString("g"),
     Id = Guid.Parse("{3329384f-af76-4eb6-9f15-b8b838af7999}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Suédois",
     Code= Commun.Enums.CodeReferenceEnum.Suedois.ToString("g"),
     Id = Guid.Parse("{d4a4a33a-f5d3-488c-89ad-7f552d262b88}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Tamoul",
     Code= Commun.Enums.CodeReferenceEnum.Tamoul.ToString("g"),
     Id = Guid.Parse("{b809599c-6b49-452a-b26c-7438c059bbf8}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 new (){
     Libelle = "Turc",
     Code= Commun.Enums.CodeReferenceEnum.Turc.ToString("g"),
     Id = Guid.Parse("{1aeef696-c31e-4987-84f3-2215a98bf350}"),
     DateCrea = new DateTime(2024,6,17),
     UtiCrea= "ALTEA",IsValide=true,
     Type = Commun.Enums.TypeReferenceEnum.Langue
 },
 #endregion
            #region Disponibilite
            new (){
 Libelle = "Immédiate",
 Code= Commun.Enums.CodeReferenceEnum.Immediate.ToString("g"),
 Id = Guid.Parse("{8f486cd6-6313-47f9-a4b5-5bd535c199a9}"),
 DateCrea = new DateTime(2024,6,17),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Disponibilite,
 OrdreTri = 1
            },
            new (){
 Libelle = "Sous un mois",
 Code= Commun.Enums.CodeReferenceEnum.SousUnMois.ToString("g"),
 Id = Guid.Parse("{92dfd90f-79b4-4d5e-93e6-fb7046b3416a}"),
 DateCrea = new DateTime(2024,6,17),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Disponibilite,
 OrdreTri = 2
            },
            new (){
 Libelle = "Sous trois mois",
 Code= Commun.Enums.CodeReferenceEnum.SousTroisMois.ToString("g"),
 Id = Guid.Parse("{f35745ef-66d0-4cb0-9657-b57c2f149e3f}"),
 DateCrea = new DateTime(2024,6,17),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Disponibilite,
 OrdreTri = 3
            },
            #endregion
            #region Contact
            new (){
 Libelle = "Telephone",
 Code= Commun.Enums.CodeReferenceEnum.Telephone.ToString("g"),
 Id = Guid.Parse(IdsConstantes.ContactTelephoneId),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contact,
 OrdreTri = 1
            },
            #endregion


 //           #region Document
 //           new (){
 //Libelle = "Cv",
 //Code= Commun.Enums.CodeReferenceEnum.Cv.ToString("g"),
 //Id = Guid.Parse("{B3E98178-68DD-4DE3-9E36-A2ED571F21C5}"),
 //DateCrea = new DateTime(2024,6,18),
 //UtiCrea= "ALTEA",IsValide=true,
 //Type = Commun.Enums.TypeReferenceEnum.Document,
 //OrdreTri = 1
 //           },
 //           new (){
 //Libelle = "Dt",
 //Code= Commun.Enums.CodeReferenceEnum.Dt.ToString("g"),
 //Id = Guid.Parse("{3A325813-E79D-445A-8953-B665C7581901}"),
 //DateCrea = new DateTime(2024,6,18),
 //UtiCrea= "ALTEA",IsValide=true,
 //Type = Commun.Enums.TypeReferenceEnum.Document,
 //OrdreTri = 1
 //           },
            //#endregion


            #region Contrat
            new (){
 Libelle = "CDI",
 Code= Commun.Enums.CodeReferenceEnum.Cdi.ToString("g"),
 Id = Guid.Parse("{A60B074D-B4AF-4157-AB49-453E28DA8514}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contrat,
 OrdreTri = 1
            },
            new (){
 Libelle = "CDD",
 Code= Commun.Enums.CodeReferenceEnum.Cdd.ToString("g"),
 Id = Guid.Parse("{4C573CDA-FC0C-42FA-B571-7829F26149CC}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contrat,
 OrdreTri = 2
            },
             new (){
 Libelle = "Freelance",
 Code= Commun.Enums.CodeReferenceEnum.Freelance.ToString("g"),
 Id = Guid.Parse("{205c8084-ea26-4794-b759-a1f505192acd}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contrat,
 OrdreTri = 3
            },
                          new (){
 Libelle = "Alternance",
 Code= Commun.Enums.CodeReferenceEnum.Alternance.ToString("g"),
 Id = Guid.Parse("{6b399cf1-425b-4f33-9895-3a551043e59d}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contrat,
 OrdreTri = 4
            },
                                       new (){
 Libelle = "Stage",
 Code= Commun.Enums.CodeReferenceEnum.Stage.ToString("g"),
 Id = Guid.Parse("{72d1445f-4ade-43bd-b329-1401ea962382}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contrat,
 OrdreTri = 5
            },
            #endregion
            #region Statut
            new (){
 Libelle = Commun.Enums.CodeReferenceEnum.Cree.GetDisplayName(false),
 Code= Commun.Enums.CodeReferenceEnum.Cree.ToString("g"),
 Id = Guid.Parse(IdsConstantes.StatutDtCreeId),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.StatutDt,
 OrdreTri = 1
            },
            new (){
 Libelle = Commun.Enums.CodeReferenceEnum.AValider.GetDisplayName(false),
 Code= Commun.Enums.CodeReferenceEnum.AValider.ToString("g"),
 Id =  Guid.Parse(IdsConstantes.StatutDtAValiderId),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.StatutDt,
 OrdreTri = 2
            },
            new (){
 Libelle = Commun.Enums.CodeReferenceEnum.Termine.GetDisplayName(false),
 Code= Commun.Enums.CodeReferenceEnum.Termine.ToString("g"),
 Id = Guid.Parse(IdsConstantes.StatutDtTermineId),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.StatutDt,
 OrdreTri = 4
            },
          
            #endregion
            #region TypePersonne
            new (){
 Libelle = "Candidat",
 Code= Commun.Enums.CodeReferenceEnum.Candidat.ToString("g"),
 Id = Guid.Parse(IdsConstantes.TypePersonneCandidatId),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Contact,
 OrdreTri = 1
            },
            #endregion
            #region Niveau Langue
            new (){
 Libelle = "Basique",
 CommentaireFun = "et encore",
 Code= Commun.Enums.CodeReferenceEnum.Basique.ToString("g"),
 Id = Guid.Parse("{307B0CC3-CD1A-41B5-854F-6B9A866E7F35}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.NiveauLangue,
 OrdreTri = 1
            },new (){
 Libelle = "Intermediaire",
 CommentaireFun = "qu'est ce à dire que ceci",
 Code= Commun.Enums.CodeReferenceEnum.Intermediaire.ToString("g"),
 Id = Guid.Parse("{8B3A139D-7365-4E82-9D09-78E10A2B1919}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.NiveauLangue,
 OrdreTri = 2
            },new (){
 Libelle = "Avancé",
 Code= Commun.Enums.CodeReferenceEnum.Avance.ToString("g"),
 Id = Guid.Parse("{2AA6BDDA-0BF1-4792-9209-C3B05B37A3AF}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.NiveauLangue,
 OrdreTri = 3
            },new (){
 Libelle = "Bilingue",
 CommentaireFun = "tu te la pètes",
 Code= Commun.Enums.CodeReferenceEnum.Bilingue.ToString("g"),
 Id = Guid.Parse("{9398FFEC-86FA-43F1-A180-478CD43B85A7}"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.NiveauLangue,
 OrdreTri = 4
            },
 #endregion
            #region Competences
            new (){
 Libelle = "Gestion de projet",
 Id = Guid.Parse("104ea49e-009d-49a5-b492-97fc6635d85f"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.GestionProjet.ToString("g"),
            },
            new (){
 Libelle = "Rédaction des spécifications",
 Id = Guid.Parse("680e7b45-9a0c-4085-816d-a63d2f108b5c"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.RedactionSpecifications.ToString("g"),
            },
            new (){
 Libelle = "Développement des logiciels",
 Id = Guid.Parse("f3c51be9-857a-4096-9ec6-d51e821b3d53"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.DeveloppementLogiciels.ToString("g"),
            },
            new (){
 Libelle = "Gestion de l’équipe",
 Id = Guid.Parse("74a57be3-a87a-4d0e-8154-22bf8ba93fa4"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.GestionEquipe.ToString("g"),
            },
            new (){
 Libelle = "Design",
 Id = Guid.Parse("bd663538-52e3-49bb-8c60-4bb46a4ed9b6"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.Design.ToString("g"),
            },
            new (){
 Libelle = "Responsabilité des équipes",
 Id = Guid.Parse("5de29a71-6a7c-459f-9cdb-acf9cf2f3447"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.ResponsabiliteEquipes.ToString("g"),
            },
            new (){
 Libelle = "Analyse de données",
 Id = Guid.Parse("7de2d798-683d-493e-90b9-cd6e2c93aa18"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.AnalyseDonnees.ToString("g"),
            },
            new (){
 Libelle = "Marketing digital",
 Id = Guid.Parse("5c38dce7-20a2-4aae-a29e-ed16193e92b0"),
 DateCrea = new DateTime(2024,6,18),
 UtiCrea= "ALTEA",
 IsValide=true,
 Type = Commun.Enums.TypeReferenceEnum.Competence,
 OrdreTri = 1,
 Code=Commun.Enums.CodeReferenceEnum.MarketingDigital.ToString("g"),
 },
 #endregion
            #region Technologie
                new (){Libelle = "Linux", Id = Guid.Parse("a3853f2d-bb30-4f82-950d-77dda048c99d"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Technologie,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Linux.ToString("g")},
                new (){Libelle = "Windows", Id = Guid.Parse("a6b3992a-dd4c-4f21-b74a-5e528d47ea71"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Technologie,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Windows.ToString("g")},
                new (){Libelle = "C#", Id = Guid.Parse("9bd90bab-2825-4f36-a49f-9227be2c1f72"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Technologie,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Csharp.ToString("g")},
                new (){Libelle = "Java", Id = Guid.Parse("36ec7894-609d-4238-bdcd-5a5962a56eb8"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Technologie,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Java.ToString("g")},
                new (){Libelle = "JEE", Id = Guid.Parse("a12fecbe-e5ec-40f8-86e5-9fc7ffcf1236"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Technologie,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Jee.ToString("g")},
            #endregion
            #region Méthodologies 
                new (){Libelle = "SCRUM", Id = Guid.Parse("6a575078-66ed-4151-b089-5dad1cdacc53"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Methodologies,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.SCRUM.ToString("g")},
                new (){Libelle = "KANBAN", Id = Guid.Parse("fcda6459-bf8b-468c-b8fc-999eaa3d1500"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Methodologies,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.KANBAN.ToString("g")},
                new (){Libelle = "Cycle en V", Id = Guid.Parse("f9ed505f-8a9e-41fd-90e3-dc92bb0508c9"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Methodologies,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.CycleV.ToString("g")},
                new (){Libelle = "PERT", Id = Guid.Parse("051cbeb3-a9fe-4fad-bc3c-1cc3577d3c5d"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Methodologies,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.PERT.ToString("g")},
                new (){Libelle = "Lean", Id = Guid.Parse("88308351-55b8-4ae6-8a9a-827863f380ff"), DateCrea = new DateTime(2024,6,18), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Methodologies,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Lean.ToString("g")},
            #endregion
            #region Outils 
                new (){Libelle = "Microsoft Office 365",Id = Guid.Parse("d13fd336-150e-4cc0-bfc2-0bb974561de3"),DateCrea = new DateTime(2024,10,14),UtiCrea= "ALTEA",IsValide=true,Type = Commun.Enums.TypeReferenceEnum.Outil,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.MicrosoftOffice365.ToString("g")},
                new (){Libelle = "Microsoft Office", Id = Guid.Parse("fc88220d-c3b5-45ac-9de8-fcd406f96b11"), DateCrea = new DateTime(2024,10,14), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Outil,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.MicrosoftOffice.ToString("g")},
                new (){Libelle = "Notion.so", Id = Guid.Parse("ba160a68-8e50-4f8f-92d9-09663dc6684b"), DateCrea = new DateTime(2024,10,14), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Outil,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.Notion.ToString("g")},
                new (){Libelle = "inVision", Id = Guid.Parse("c5e29778-d6ce-4d83-a663-83fa37bf861d"), DateCrea = new DateTime(2024,10,14), UtiCrea= "ALTEA", IsValide=true, Type = Commun.Enums.TypeReferenceEnum.Outil,OrdreTri = 1,Code=Commun.Enums.CodeReferenceEnum.InVision.ToString("g")},
            #endregion

             #region Domaines 
                new () { Libelle = "Santé / Médical", Id = Guid.Parse("53f64464-3ac1-4440-9cbe-c629c0244ec7"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.SanteMedical.ToString("g") },
                new () { Libelle = "Éducation", Id = Guid.Parse("413c2810-d35c-4164-9021-73f5e50bad2b"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Education.ToString("g") },
                new () { Libelle = "Banque / Assurance", Id = Guid.Parse("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.BanqueAssurance.ToString("g") },
                new () { Libelle = "Énergie", Id = Guid.Parse("68940f3a-8d1a-43fe-afe9-a088fbf840f2"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Energie.ToString("g") },
                new () { Libelle = "Services", Id = Guid.Parse("804109be-d3de-4745-a8aa-e6535e1c3151"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Services.ToString("g") },
                new () { Libelle = "Gestion / Comptabilité", Id = Guid.Parse("e37ab257-7c00-4a8a-b71f-681ad18d1de2"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.GestionComptabilite.ToString("g") },
                new () { Libelle = "Transports / Logistique", Id = Guid.Parse("93123d1d-aa63-4e9a-b89c-72db6e616f76"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.TransportsLogistique.ToString("g") },
                new () { Libelle = "Commerce / Distribution", Id = Guid.Parse("4055b77d-03a0-44f8-84dd-926fdb07f568"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.CommerceDistribution.ToString("g") },
                new () { Libelle = "Télécom / Informatique", Id = Guid.Parse("939d7426-2069-4100-a8db-5ec86082fd49"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.TelecomInformatique.ToString("g") },
                new () { Libelle = "Industrie", Id = Guid.Parse("f57fc24d-d771-4de2-8c56-180728b027ce"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Industrie.ToString("g") },
                new () { Libelle = "Tourisme / Loisirs", Id = Guid.Parse("f5f43903-c3f7-47fd-a207-98887dd59e87"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.TourismeLoisirs.ToString("g") },
                new () { Libelle = "Environnement", Id = Guid.Parse("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Environnement.ToString("g") },
                new () { Libelle = "Immobilier", Id = Guid.Parse("4052f410-0ded-4078-b065-46139c5f7f42"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Immobilier.ToString("g") },
                new () { Libelle = "Social", Id = Guid.Parse("a1cba742-7102-432e-b7a0-55eacf200761"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Social.ToString("g") },
                new () { Libelle = "Recherche", Id = Guid.Parse("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Recherche.ToString("g") },
                new () { Libelle = "Administration", Id = Guid.Parse("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.Administration.ToString("g") },
                new () { Libelle = "Autre", Id = Guid.Parse(IdsConstantes.DomaineAutreId), DateCrea = new DateTime(2024,11,20), UtiCrea = "ALTEA", IsValide = true, Type = Commun.Enums.TypeReferenceEnum.Domaine, OrdreTri = 1, Code = Commun.Enums.CodeReferenceEnum.AutreDomaines.ToString("g") }

             #endregion
            });
        }
    }
}
