#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutRefeContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d62180f9-3c50-431d-aa13-cafc1f910259"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[] { new Guid("d62180f9-3c50-431d-aa13-cafc1f910259"), "Email", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Email", 1, null, "Contact", "ALTEA", null });
        }
    }
}
