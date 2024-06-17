using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutIndexREcherche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_NumeroLugt",
                table: "Marques");

            migrationBuilder.CreateIndex(
                name: "IX_Marques_NumeroLugt_ReferenceLugt",
                table: "Marques",
                columns: new[] { "NumeroLugt", "ReferenceLugt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_NumeroLugt_ReferenceLugt",
                table: "Marques");

            migrationBuilder.CreateIndex(
                name: "IX_Marques_NumeroLugt",
                table: "Marques",
                column: "NumeroLugt");
        }
    }
}
