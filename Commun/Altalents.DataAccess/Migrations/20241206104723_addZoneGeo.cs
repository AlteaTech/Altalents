using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addZoneGeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_References_TypeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TypeId",
                table: "Documents");

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3a325813-e79d-445a-8953-b665c7581901"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b3e98178-68dd-4de3-9e36-a2ed571f21c5"));

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "ZoneGeo",
                table: "DossierTechniques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReferenceId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                table: "DocumentComplementaires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceId",
                table: "Documents",
                column: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_References_ReferenceId",
                table: "Documents",
                column: "ReferenceId",
                principalTable: "References",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_References_ReferenceId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ReferenceId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ZoneGeo",
                table: "DossierTechniques");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                table: "DocumentComplementaires");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("3a325813-e79d-445a-8953-b665c7581901"), "Dt", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Dt", 1, null, "Document", "ALTEA", null },
                    { new Guid("b3e98178-68dd-4de3-9e36-a2ed571f21c5"), "Cv", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Cv", 1, null, "Document", "ALTEA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_References_TypeId",
                table: "Documents",
                column: "TypeId",
                principalTable: "References",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
