#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AutoIncrementNumDtPart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroUnique",
                table: "DossierTechniques",
                newName: "Numero");

            migrationBuilder.RenameIndex(
                name: "IX_DossierTechniques_NumeroUnique",
                table: "DossierTechniques",
                newName: "IX_DossierTechniques_Numero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "DossierTechniques",
                newName: "NumeroUnique");

            migrationBuilder.RenameIndex(
                name: "IX_DossierTechniques_Numero",
                table: "DossierTechniques",
                newName: "IX_DossierTechniques_NumeroUnique");
        }
    }
}
