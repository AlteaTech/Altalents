using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFkNiveauLangue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniqueLangues_References_LangueId",
                table: "DossierTechniqueLangues");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "DossierTechniqueLangues");

            migrationBuilder.AddColumn<Guid>(
                name: "NiveauId",
                table: "DossierTechniqueLangues",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniqueLangues_NiveauId",
                table: "DossierTechniqueLangues",
                column: "NiveauId");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniqueLangues_References_LangueId",
                table: "DossierTechniqueLangues",
                column: "LangueId",
                principalTable: "References",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniqueLangues_References_NiveauId",
                table: "DossierTechniqueLangues",
                column: "NiveauId",
                principalTable: "References",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniqueLangues_References_LangueId",
                table: "DossierTechniqueLangues");

            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniqueLangues_References_NiveauId",
                table: "DossierTechniqueLangues");

            migrationBuilder.DropIndex(
                name: "IX_DossierTechniqueLangues_NiveauId",
                table: "DossierTechniqueLangues");

            migrationBuilder.DropColumn(
                name: "NiveauId",
                table: "DossierTechniqueLangues");

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "DossierTechniqueLangues",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniqueLangues_References_LangueId",
                table: "DossierTechniqueLangues",
                column: "LangueId",
                principalTable: "References",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
