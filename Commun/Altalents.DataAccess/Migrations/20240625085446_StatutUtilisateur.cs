#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StatutUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCommercial",
                table: "Utilisateurs");

            migrationBuilder.AddColumn<string>(
                name: "Poste",
                table: "Utilisateurs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Utilisateurs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeCompte",
                table: "Utilisateurs",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: new Guid("f05d0f23-00b2-47fe-91ab-59ebeaa867ee"),
                columns: new[] { "Poste", "Telephone", "TypeCompte" },
                values: new object[] { null, null, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poste",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "TypeCompte",
                table: "Utilisateurs");

            migrationBuilder.AddColumn<bool>(
                name: "IsCommercial",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: new Guid("f05d0f23-00b2-47fe-91ab-59ebeaa867ee"),
                column: "IsCommercial",
                value: false);
        }
    }
}
