#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CUS115 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TypesReferences",
                keyColumn: "Id",
                keyValue: new Guid("0335d175-3378-43f4-8683-e9d7bad3cdc4"),
                column: "WithSousReference",
                value: false);

            migrationBuilder.UpdateData(
                table: "TypesReferences",
                keyColumn: "Id",
                keyValue: new Guid("a84d4874-3577-46b8-853b-25910a0f67c8"),
                column: "WithSousReference",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TypesReferences",
                keyColumn: "Id",
                keyValue: new Guid("0335d175-3378-43f4-8683-e9d7bad3cdc4"),
                column: "WithSousReference",
                value: true);

            migrationBuilder.UpdateData(
                table: "TypesReferences",
                keyColumn: "Id",
                keyValue: new Guid("a84d4874-3577-46b8-853b-25910a0f67c8"),
                column: "WithSousReference",
                value: true);
        }
    }
}
