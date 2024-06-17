#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddindexIsFinalize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_ReferenceLugt",
                table: "Marques");

            migrationBuilder.CreateIndex(
                name: "IX_Marques_IsFinalize_DatePublication",
                table: "Marques",
                columns: new[] { "IsFinalize", "DatePublication" });

            migrationBuilder.CreateIndex(
                name: "IX_Marques_ReferenceLugt_IsFinalize",
                table: "Marques",
                columns: new[] { "ReferenceLugt", "IsFinalize" },
                unique: true,
                filter: "[ReferenceLugt] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_IsFinalize_DatePublication",
                table: "Marques");

            migrationBuilder.DropIndex(
                name: "IX_Marques_ReferenceLugt_IsFinalize",
                table: "Marques");

            migrationBuilder.CreateIndex(
                name: "IX_Marques_ReferenceLugt",
                table: "Marques",
                column: "ReferenceLugt",
                unique: true,
                filter: "[ReferenceLugt] IS NOT NULL");
        }
    }
}
