using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ajustFormationEtCertificationWithOnlyObtentionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personnes_Trigramme",
                table: "Personnes");

            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "Certifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateObtention",
                table: "Formations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateObtention",
                table: "Certifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                column: "Libelle",
                value: "À Valider");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateObtention",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "DateObtention",
                table: "Certifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebut",
                table: "Formations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "Formations",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebut",
                table: "Certifications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "Certifications",
                type: "datetime",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                column: "Libelle",
                value: "À valider");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Trigramme",
                table: "Personnes",
                column: "Trigramme",
                unique: true,
                filter: "[Trigramme] IS NOT NULL");
        }
    }
}
