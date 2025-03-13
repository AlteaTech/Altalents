using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFreelanceINTypeCOntrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RempliParCandidat",
                table: "DossierTechniques");

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[] { new Guid("205c8084-ea26-4794-b759-a1f505192acd"), "Freelance", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Freelance", 3, null, "Contrat", "ALTEA", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("205c8084-ea26-4794-b759-a1f505192acd"));

            migrationBuilder.AddColumn<bool>(
                name: "RempliParCandidat",
                table: "DossierTechniques",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
