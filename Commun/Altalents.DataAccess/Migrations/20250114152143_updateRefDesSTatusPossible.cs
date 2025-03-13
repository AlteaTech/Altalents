using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateRefDesSTatusPossible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

       migrationBuilder.Sql("UPDATE dbo.DossierTechniques SET StatutId = '5f92b7d6-4ddf-4ec5-965b-9824387afa57'");

       migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("02e3d3ee-f745-4bf1-a00d-61e640dac8ae"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("610f6ca4-0f22-44ec-9269-f744873b92f2"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("78a3cb44-9fd3-4c6c-9848-677937324ecd"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c09db97a-1547-41c1-afa9-428dd1d5ba55"));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "AValider", "à valider" });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[] { new Guid("d47e05b8-3e19-4a31-bd82-b28e8fc97060"), "Termine", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Terminé", 4, null, "StatutDt", "ALTEA", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d47e05b8-3e19-4a31-bd82-b28e8fc97060"));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "EnCours", "En Cours" });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("02e3d3ee-f745-4bf1-a00d-61e640dac8ae"), "AModifier", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "A Modifier", 5, null, "StatutDt", "ALTEA", null },
                    { new Guid("610f6ca4-0f22-44ec-9269-f744873b92f2"), "NonValide", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Non valide", 3, null, "StatutDt", "ALTEA", null },
                    { new Guid("78a3cb44-9fd3-4c6c-9848-677937324ecd"), "Valide", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Valide", 4, null, "StatutDt", "ALTEA", null },
                    { new Guid("c09db97a-1547-41c1-afa9-428dd1d5ba55"), "Inactif", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Inactif", 1, null, "StatutDt", "ALTEA", null }
                });
        }
    }
}
