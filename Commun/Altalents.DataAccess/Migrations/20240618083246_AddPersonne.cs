using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonneId",
                table: "DossierTechniques",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Prenom = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Trigramme = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BoondId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnes_References_TypeId",
                        column: x => x.TypeId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniques_PersonneId",
                table: "DossierTechniques",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_BoondId",
                table: "Personnes",
                column: "BoondId",
                unique: true,
                filter: "[BoondId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Email",
                table: "Personnes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Trigramme",
                table: "Personnes",
                column: "Trigramme",
                unique: true,
                filter: "[Trigramme] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_TypeId",
                table: "Personnes",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniques_Personnes_PersonneId",
                table: "DossierTechniques",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniques_Personnes_PersonneId",
                table: "DossierTechniques");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropIndex(
                name: "IX_DossierTechniques_PersonneId",
                table: "DossierTechniques");

            migrationBuilder.DropColumn(
                name: "PersonneId",
                table: "DossierTechniques");
        }
    }
}
