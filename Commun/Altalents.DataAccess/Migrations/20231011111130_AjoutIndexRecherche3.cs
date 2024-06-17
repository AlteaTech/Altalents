using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutIndexRecherche3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Marques_Initiales_NumeroLugt_ReferenceLugtLight",
                table: "Marques",
                columns: new[] { "Initiales", "NumeroLugt", "ReferenceLugtLight" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_Initiales_NumeroLugt_ReferenceLugtLight",
                table: "Marques");
        }
    }
}
