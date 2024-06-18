using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLiaisonsExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiaisonExperienceCompetances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonExperienceCompetances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceCompetances_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceCompetances_References_CompetanceId",
                        column: x => x.CompetanceId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiaisonExperienceTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnologieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonExperienceTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceTechnologies_References_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceCompetances_CompetanceId",
                table: "LiaisonExperienceCompetances",
                column: "CompetanceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceCompetances_ExperienceId",
                table: "LiaisonExperienceCompetances",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceTechnologies_ExperienceId",
                table: "LiaisonExperienceTechnologies",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceTechnologies_TechnologieId",
                table: "LiaisonExperienceTechnologies",
                column: "TechnologieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiaisonExperienceCompetances");

            migrationBuilder.DropTable(
                name: "LiaisonExperienceTechnologies");
        }
    }
}
