using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutVueMarqueInitialesSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VueMarqueInitialesSearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TexteTransLitLowerFr = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VueMarqueInitialesSearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VueMarqueInitialesSearch_Marques_MarqueId",
                        column: x => x.MarqueId,
                        principalTable: "Marques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VueMarqueInitialesSearch_MarqueId_TexteTransLitLowerFr_Total",
                table: "VueMarqueInitialesSearch",
                columns: new[] { "MarqueId", "TexteTransLitLowerFr", "Total" });

            migrationBuilder.CreateIndex(
                name: "IX_VueMarqueInitialesSearch_TexteTransLitLowerFr_Total",
                table: "VueMarqueInitialesSearch",
                columns: new[] { "TexteTransLitLowerFr", "Total" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VueMarqueInitialesSearch");
        }
    }
}
