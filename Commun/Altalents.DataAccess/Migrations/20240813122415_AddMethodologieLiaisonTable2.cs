using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMethodologieLiaisonTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceCompetances_Experiences_ExperienceId",
                table: "LiaisonExperienceCompetances");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceCompetances_References_CompetanceId",
                table: "LiaisonExperienceCompetances");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                table: "LiaisonExperienceTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceTechnologies_References_TechnologieId",
                table: "LiaisonExperienceTechnologies");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceCompetances_Experiences_ExperienceId",
                table: "LiaisonExperienceCompetances",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceCompetances_References_CompetanceId",
                table: "LiaisonExperienceCompetances",
                column: "CompetanceId",
                principalTable: "References",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                table: "LiaisonExperienceTechnologies",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceTechnologies_References_TechnologieId",
                table: "LiaisonExperienceTechnologies",
                column: "TechnologieId",
                principalTable: "References",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceCompetances_Experiences_ExperienceId",
                table: "LiaisonExperienceCompetances");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceCompetances_References_CompetanceId",
                table: "LiaisonExperienceCompetances");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                table: "LiaisonExperienceTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceTechnologies_References_TechnologieId",
                table: "LiaisonExperienceTechnologies");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceCompetances_Experiences_ExperienceId",
                table: "LiaisonExperienceCompetances",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceCompetances_References_CompetanceId",
                table: "LiaisonExperienceCompetances",
                column: "CompetanceId",
                principalTable: "References",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                table: "LiaisonExperienceTechnologies",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceTechnologies_References_TechnologieId",
                table: "LiaisonExperienceTechnologies",
                column: "TechnologieId",
                principalTable: "References",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
