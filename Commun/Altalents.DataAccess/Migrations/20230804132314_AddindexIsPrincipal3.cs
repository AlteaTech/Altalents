#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddindexIsPrincipal3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId_IsPrincipal",
                table: "MarqueSousReferenceReferences");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId_IsPrincipal_ReferenceId",
                table: "MarqueSousReferenceReferences",
                columns: new[] { "MarqueId", "IsPrincipal", "ReferenceId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId_IsPrincipal_ReferenceId",
                table: "MarqueSousReferenceReferences");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueSousReferenceReferences_MarqueId_IsPrincipal",
                table: "MarqueSousReferenceReferences",
                columns: new[] { "MarqueId", "IsPrincipal" });
        }
    }
}
