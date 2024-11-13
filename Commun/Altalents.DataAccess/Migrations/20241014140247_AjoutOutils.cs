using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutOutils : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiaisonExperienceOutils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonExperienceOutils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceOutils_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiaisonExperienceOutils_References_OutilId",
                        column: x => x.OutilId,
                        principalTable: "References",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ba160a68-8e50-4f8f-92d9-09663dc6684b"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outil" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c5e29778-d6ce-4d83-a663-83fa37bf861d"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outil" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d13fd336-150e-4cc0-bfc2-0bb974561de3"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outil" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fc88220d-c3b5-45ac-9de8-fcd406f96b11"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outil" });

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceOutils_ExperienceId",
                table: "LiaisonExperienceOutils",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonExperienceOutils_OutilId",
                table: "LiaisonExperienceOutils",
                column: "OutilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiaisonExperienceOutils");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ba160a68-8e50-4f8f-92d9-09663dc6684b"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "OutilEtEnvironnement" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c5e29778-d6ce-4d83-a663-83fa37bf861d"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "OutilEtEnvironnement" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d13fd336-150e-4cc0-bfc2-0bb974561de3"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "OutilEtEnvironnement" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fc88220d-c3b5-45ac-9de8-fcd406f96b11"),
                columns: new[] { "DateCrea", "Type" },
                values: new object[] { new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "OutilEtEnvironnement" });
        }
    }
}
