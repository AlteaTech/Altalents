using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntitulePoste = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Entreprise = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lieu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    DomaineMetier = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ClientFinal = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateDebut = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    PersonneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeContratId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Experiences_References_TypeContratId",
                        column: x => x.TypeContratId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "DateCrea", "DateMaj", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("4c573cda-fc0c-42fa-b571-7829f26149cc"), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CDD", 2, null, "Contrat", "ALTEA", null },
                    { new Guid("a60b074d-b4af-4157-ab49-453e28da8514"), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CDI", 1, null, "Contrat", "ALTEA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PersonneId",
                table: "Experiences",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_TypeContratId",
                table: "Experiences",
                column: "TypeContratId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4c573cda-fc0c-42fa-b571-7829f26149cc"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a60b074d-b4af-4157-ab49-453e28da8514"));
        }
    }
}
