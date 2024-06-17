#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutIndexOrdreTypeReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TypesReferences_Libelle",
                table: "TypesReferences");

            migrationBuilder.CreateIndex(
                name: "IX_TypesReferences_Ordre_Libelle",
                table: "TypesReferences",
                columns: new[] { "Ordre", "Libelle" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TypesReferences_Ordre_Libelle",
                table: "TypesReferences");

            migrationBuilder.CreateIndex(
                name: "IX_TypesReferences_Libelle",
                table: "TypesReferences",
                column: "Libelle");
        }
    }
}
