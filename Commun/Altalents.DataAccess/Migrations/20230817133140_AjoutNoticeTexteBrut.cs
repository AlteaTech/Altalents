#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutNoticeTexteBrut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TexteBrut",
                table: "MarqueNotices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TexteBrut",
                table: "MarqueNotices");
        }
    }
}
