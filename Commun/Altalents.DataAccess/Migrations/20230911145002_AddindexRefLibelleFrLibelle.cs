#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddindexRefLibelleFrLibelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_References_Libelle2",
                table: "References",
                column: "Libelle2");

            migrationBuilder.CreateIndex(
                name: "IX_References_LibelleFr_Libelle2",
                table: "References",
                columns: new[] { "LibelleFr", "Libelle2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_References_Libelle2",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_LibelleFr_Libelle2",
                table: "References");
        }
    }
}
