using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutSyntheseToDtAndProjectsToExp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Synthese",
                table: "DossierTechniques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtiMaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projet_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"), "AgricultureEtElevage", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(142), null, true, "Agriculture Et Élevage", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("4052f410-0ded-4078-b065-46139c5f7f42"), "Immobilier", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(201), null, true, "Immobilier", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"), "CommerceEtDistribution", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(163), null, true, "Commerce Et Distribution", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"), "EnseignementEtFormation", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(182), null, true, "Enseignement Et Formation", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"), "Tourismne", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(251), null, true, "Tourisme", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"), "Santé", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(231), null, true, "Santé", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"), "BatimentEtTravauxPublic", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(159), null, true, "Bâtiment Et Travaux Publics", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"), "ArchitectureEtudesEtNormes", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(147), null, true, "Architecture Études Et Normes", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"), "Energie", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(178), null, true, "Énergie", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"), "MaintenanceEntretienEtNotoyage", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(217), null, true, "Maintenance Entretien Et Nettoyage", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"), "FinanceBanqueEtAssurance", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(190), null, true, "Finance Banque Et Assurance", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"), "Recherche", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(220), null, true, "Recherche", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"), "ServiceALaPersonne", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(235), null, true, "Service À La Personne", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"), "ServicePublicDefenseSecurite", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(239), null, true, "Service Public Défense Et Sécurité", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("89810245-c71d-4772-b648-3fa7b626ea69"), "Automobile", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(155), null, true, "Automobile", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"), "HotellerieEtRestauration", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(197), null, true, "Hôtellerie Et Restauration", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"), "LogistiqueEtTransport", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(213), null, true, "Logistique Et Transport", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("939d7426-2069-4100-a8db-5ec86082fd49"), "InformatiqueEtTelecommunication", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(209), null, true, "Informatique Et Télécommunication", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"), "ArtAudiovisuelEtSpectacle", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(151), null, true, "Art Audiovisuel Et Spectacle", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("a1cba742-7102-432e-b7a0-55eacf200761"), "Social", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(243), null, true, "Social", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("babdff53-7380-48df-81ca-30e6da210010"), "CommunicationMarketing", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(166), null, true, "Communication Et Marketing", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"), "GestionAdministrativeEtRessourcesHumaine", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(193), null, true, "Gestion Administrative Et Ressources Humaines", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"), "Edition", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(175), null, true, "Édition", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"), "ActivitesJuridiquesEtComptables", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(58), null, true, "Activités Juridiques Et Comptables", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"), "CulturePatrimoine", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(170), null, true, "Culture Et Patrimoine", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"), "Environnement", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(186), null, true, "Environnement", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"), "Industrie", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(205), null, true, "Industrie", 1, null, "Domaine", "ALTEA", null },
                    { new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"), "SportAnimationLoisir", null, new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(247), null, true, "Sport, Animation Et Loisir", 1, null, "Domaine", "ALTEA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projet_ExperienceId",
                table: "Projet",
                column: "ExperienceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4052f410-0ded-4078-b065-46139c5f7f42"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"));

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
                keyValue: new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"));

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
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a1cba742-7102-432e-b7a0-55eacf200761"));

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
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"));

            migrationBuilder.DropColumn(
                name: "Synthese",
                table: "DossierTechniques");
        }
    }
}
