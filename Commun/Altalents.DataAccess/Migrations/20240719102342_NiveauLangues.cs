using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NiveauLangues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("2aa6bdda-0bf1-4792-9209-c3b05b37a3af"), "Avance", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Avance", 3, null, "NiveauLangue", "ALTEA", null },
                    { new Guid("307b0cc3-cd1a-41b5-854f-6b9a866e7f35"), "Basique", "et encore", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Basique", 1, null, "NiveauLangue", "ALTEA", null },
                    { new Guid("8b3a139d-7365-4e82-9d09-78e10a2b1919"), "Intermediaire", "qu'est ce à dire que ceci", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Intermediaire", 2, null, "NiveauLangue", "ALTEA", null },
                    { new Guid("9398ffec-86fa-43f1-a180-478cd43b85a7"), "Bilingue", "tu te la pète", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bilingue", 4, null, "NiveauLangue", "ALTEA", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("2aa6bdda-0bf1-4792-9209-c3b05b37a3af"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("307b0cc3-cd1a-41b5-854f-6b9a866e7f35"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8b3a139d-7365-4e82-9d09-78e10a2b1919"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9398ffec-86fa-43f1-a180-478cd43b85a7"));
        }
    }
}
