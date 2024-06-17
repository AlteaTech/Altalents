#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceLugtLight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceLugtLight",
                table: "Marques",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marques_ReferenceLugtLight",
                table: "Marques",
                column: "ReferenceLugtLight",
                unique: true,
                filter: "[ReferenceLugtLight] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_ReferenceLugtLight",
                table: "Marques");

            migrationBuilder.DropColumn(
                name: "ReferenceLugtLight",
                table: "Marques");
        }
    }
}
