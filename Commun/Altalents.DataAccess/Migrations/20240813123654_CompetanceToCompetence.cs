using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CompetanceToCompetence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiaisonExperienceCompetances");

            migrationBuilder.CreateTable(
                name: "LiaisonExperienceCompetences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonExperienceCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceCompetences_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceCompetences_References_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "References",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceCompetences_CompetenceId",
                table: "LiaisonExperienceCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceCompetences_ExperienceId",
                table: "LiaisonExperienceCompetences",
                column: "ExperienceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiaisonExperienceCompetences");

            migrationBuilder.CreateTable(
                name: "LiaisonExperienceCompetances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    Niveau = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceCompetances_References_CompetanceId",
                        column: x => x.CompetanceId,
                        principalTable: "References",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceCompetances_CompetanceId",
                table: "LiaisonExperienceCompetances",
                column: "CompetanceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceCompetances_ExperienceId",
                table: "LiaisonExperienceCompetances",
                column: "ExperienceId");
        }
    }
}
