#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TokenAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update DossierTechniques set  TokenAccesRapide = newid()");
            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniques_TokenAccesRapide",
                table: "DossierTechniques",
                column: "TokenAccesRapide",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DossierTechniques_TokenAccesRapide",
                table: "DossierTechniques");
        }
    }
}
