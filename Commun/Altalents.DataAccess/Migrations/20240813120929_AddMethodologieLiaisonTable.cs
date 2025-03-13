using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMethodologieLiaisonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiaisonExperienceMethodologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MethodologieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonExperienceMethodologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceMethodologies_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceMethodologies_References_MethodologieId",
                        column: x => x.MethodologieId,
                        principalTable: "References",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceMethodologies_ExperienceId",
                table: "LiaisonExperienceMethodologies",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceMethodologies_MethodologieId",
                table: "LiaisonExperienceMethodologies",
                column: "MethodologieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiaisonExperienceMethodologies");
        }
    }
}
