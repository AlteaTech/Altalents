using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MoveCOmpetencesFromExperienceToProjetOrMissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceCompetences_Experiences_ExperienceId",
                table: "LiaisonExperienceCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceMethodologies_Experiences_ExperienceId",
                table: "LiaisonExperienceMethodologies");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceOutils_Experiences_ExperienceId",
                table: "LiaisonExperienceOutils");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                table: "LiaisonExperienceTechnologies");

            migrationBuilder.Sql("delete from LiaisonExperienceTechnologies;");
            migrationBuilder.Sql("delete from LiaisonExperienceMethodologies;");
            migrationBuilder.Sql("delete from LiaisonExperienceOutils;");
            migrationBuilder.Sql("delete from LiaisonExperienceCompetences;");

            migrationBuilder.RenameColumn(
                name: "ExperienceId",
                table: "LiaisonExperienceTechnologies",
                newName: "ProjetOrMissionClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceTechnologies_ExperienceId",
                table: "LiaisonExperienceTechnologies",
                newName: "IX_LiaisonExperienceTechnologies_ProjetOrMissionClientId");

            migrationBuilder.RenameColumn(
                name: "ExperienceId",
                table: "LiaisonExperienceOutils",
                newName: "ProjetOrMissionClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceOutils_ExperienceId",
                table: "LiaisonExperienceOutils",
                newName: "IX_LiaisonExperienceOutils_ProjetOrMissionClientId");

            migrationBuilder.RenameColumn(
                name: "ExperienceId",
                table: "LiaisonExperienceMethodologies",
                newName: "ProjetOrMissionClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceMethodologies_ExperienceId",
                table: "LiaisonExperienceMethodologies",
                newName: "IX_LiaisonExperienceMethodologies_ProjetOrMissionClientId");

            migrationBuilder.RenameColumn(
                name: "ExperienceId",
                table: "LiaisonExperienceCompetences",
                newName: "ProjetOrMissionClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceCompetences_ExperienceId",
                table: "LiaisonExperienceCompetences",
                newName: "IX_LiaisonExperienceCompetences_ProjetOrMissionClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceCompetences_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceCompetences",
                column: "ProjetOrMissionClientId",
                principalTable: "ProjetsOrMissionsClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceMethodologies_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceMethodologies",
                column: "ProjetOrMissionClientId",
                principalTable: "ProjetsOrMissionsClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceOutils_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceOutils",
                column: "ProjetOrMissionClientId",
                principalTable: "ProjetsOrMissionsClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceTechnologies_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceTechnologies",
                column: "ProjetOrMissionClientId",
                principalTable: "ProjetsOrMissionsClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceCompetences_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceMethodologies_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceMethodologies");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceOutils_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceOutils");

            migrationBuilder.DropForeignKey(
                name: "FK_LiaisonExperienceTechnologies_ProjetsOrMissionsClient_ProjetOrMissionClientId",
                table: "LiaisonExperienceTechnologies");

            migrationBuilder.RenameColumn(
                name: "ProjetOrMissionClientId",
                table: "LiaisonExperienceTechnologies",
                newName: "ExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceTechnologies_ProjetOrMissionClientId",
                table: "LiaisonExperienceTechnologies",
                newName: "IX_LiaisonExperienceTechnologies_ExperienceId");

            migrationBuilder.RenameColumn(
                name: "ProjetOrMissionClientId",
                table: "LiaisonExperienceOutils",
                newName: "ExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceOutils_ProjetOrMissionClientId",
                table: "LiaisonExperienceOutils",
                newName: "IX_LiaisonExperienceOutils_ExperienceId");

            migrationBuilder.RenameColumn(
                name: "ProjetOrMissionClientId",
                table: "LiaisonExperienceMethodologies",
                newName: "ExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceMethodologies_ProjetOrMissionClientId",
                table: "LiaisonExperienceMethodologies",
                newName: "IX_LiaisonExperienceMethodologies_ExperienceId");

            migrationBuilder.RenameColumn(
                name: "ProjetOrMissionClientId",
                table: "LiaisonExperienceCompetences",
                newName: "ExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_LiaisonExperienceCompetences_ProjetOrMissionClientId",
                table: "LiaisonExperienceCompetences",
                newName: "IX_LiaisonExperienceCompetences_ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceCompetences_Experiences_ExperienceId",
                table: "LiaisonExperienceCompetences",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceMethodologies_Experiences_ExperienceId",
                table: "LiaisonExperienceMethodologies",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceOutils_Experiences_ExperienceId",
                table: "LiaisonExperienceOutils",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiaisonExperienceTechnologies_Experiences_ExperienceId",
                table: "LiaisonExperienceTechnologies",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
