#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexIsPrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId",
                table: "MarqueSousReferenceReferences");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId_IsPrincipal",
                table: "MarqueSousReferenceReferences",
                columns: new[] { "MarqueId", "IsPrincipal" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId_IsPrincipal",
                table: "MarqueSousReferenceReferences");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId",
                table: "MarqueSousReferenceReferences",
                column: "MarqueId");
        }
    }
}
