#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddindexIsPrincipal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MarqueSousReferenceReferences_IsPrincipal",
                table: "MarqueSousReferenceReferences",
                column: "IsPrincipal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueSousReferenceReferences_IsPrincipal",
                table: "MarqueSousReferenceReferences");
        }
    }
}
