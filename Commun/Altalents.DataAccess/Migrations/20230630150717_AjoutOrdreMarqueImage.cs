#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutOrdreMarqueImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordre",
                table: "MarqueImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarqueImages_Ordre",
                table: "MarqueImages",
                column: "Ordre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueImages_Ordre",
                table: "MarqueImages");

            migrationBuilder.DropColumn(
                name: "Ordre",
                table: "MarqueImages");
        }
    }
}
