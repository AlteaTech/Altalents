using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCompetences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("104ea49e-009d-49a5-b492-97fc6635d85f"), "GestionProjet", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gestion de projet", 1, null, "Competence", "ALTEA", null },
                    { new Guid("5c38dce7-20a2-4aae-a29e-ed16193e92b0"), "MarketingDigital", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Marketing digital", 1, null, "Competence", "ALTEA", null },
                    { new Guid("5de29a71-6a7c-459f-9cdb-acf9cf2f3447"), "ResponsabiliteEquipes", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Responsabilité des équipes", 1, null, "Competence", "ALTEA", null },
                    { new Guid("680e7b45-9a0c-4085-816d-a63d2f108b5c"), "RedactionSpecifications", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Rédaction des spécifications", 1, null, "Competence", "ALTEA", null },
                    { new Guid("74a57be3-a87a-4d0e-8154-22bf8ba93fa4"), "GestionEquipe", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gestion de l’équipe", 1, null, "Competence", "ALTEA", null },
                    { new Guid("7de2d798-683d-493e-90b9-cd6e2c93aa18"), "AnalyseDonnees", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Analyse de données", 1, null, "Competence", "ALTEA", null },
                    { new Guid("bd663538-52e3-49bb-8c60-4bb46a4ed9b6"), "Design", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Design", 1, null, "Competence", "ALTEA", null },
                    { new Guid("f3c51be9-857a-4096-9ec6-d51e821b3d53"), "DeveloppementLogiciels", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Développement des logiciels", 1, null, "Competence", "ALTEA", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("104ea49e-009d-49a5-b492-97fc6635d85f"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5c38dce7-20a2-4aae-a29e-ed16193e92b0"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5de29a71-6a7c-459f-9cdb-acf9cf2f3447"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("680e7b45-9a0c-4085-816d-a63d2f108b5c"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74a57be3-a87a-4d0e-8154-22bf8ba93fa4"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7de2d798-683d-493e-90b9-cd6e2c93aa18"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bd663538-52e3-49bb-8c60-4bb46a4ed9b6"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f3c51be9-857a-4096-9ec6-d51e821b3d53"));
        }
    }
}
