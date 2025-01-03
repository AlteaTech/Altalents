using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomaineRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("89810245-c71d-4772-b648-3fa7b626ea69"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("babdff53-7380-48df-81ca-30e6da210010"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"));

            migrationBuilder.DropColumn(
                name: "Domaine",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "Domaine",
                table: "Certifications");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                column: "Code",
                value: "AutreDomaines");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "CommerceDistribution", "Commerce / Distribution" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "Education", "Éducation" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "SanteMedical", "Santé / Médical" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "BanqueAssurance", "Banque / Assurance" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "Services", "Services" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "Administration", "Administration" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "TransportsLogistique", "Transports / Logistique" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "TelecomInformatique", "Télécom / Informatique" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "GestionComptabilite", "Gestion / Comptabilité" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "TourismeLoisir", "Tourisme / Loisir" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Domaine",
                table: "Formations",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domaine",
                table: "Certifications",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                column: "Code",
                value: "Tourismne");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "CommerceEtDistribution", "Commerce Et Distribution" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "EnseignementEtFormation", "Enseignement Et Formation" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "Santé", "Santé" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "FinanceBanqueEtAssurance", "Finance Banque Et Assurance" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "ServiceALaPersonne", "Service À La Personne" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "ServicePublicDefenseSecurite", "Service Public Défense Et Sécurité" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "LogistiqueEtTransport", "Logistique Et Transport" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "InformatiqueEtTelecommunication", "Informatique Et Télécommunication" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "ActivitesJuridiquesEtComptables", "Activités Juridiques Et Comptables" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "SportAnimationLoisir", "Sport, Animation Et Loisir" });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"), "AgricultureEtElevage", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Agriculture Et Élevage", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"), "Tourismne", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tourisme", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"), "BatimentEtTravauxPublic", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bâtiment Et Travaux Publics", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"), "ArchitectureEtudesEtNormes", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Architecture Études Et Normes", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"), "MaintenanceEntretienEtNotoyage", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Maintenance Entretien Et Nettoyage", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("89810245-c71d-4772-b648-3fa7b626ea69"), "Automobile", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Automobile", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"), "HotellerieEtRestauration", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Hôtellerie Et Restauration", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"), "ArtAudiovisuelEtSpectacle", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Art Audiovisuel Et Spectacle", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("babdff53-7380-48df-81ca-30e6da210010"), "CommunicationMarketing", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Communication Et Marketing", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"), "GestionAdministrativeEtRessourcesHumaine", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gestion Administrative Et Ressources Humaines", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"), "Edition", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Édition", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"), "CulturePatrimoine", null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Culture Et Patrimoine", 1, null, "Domaine", "ALTEA", null }
                });
        }
    }
}
