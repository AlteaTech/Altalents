#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLiensDtUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCommercial",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                table: "DossierTechniques",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: new Guid("f05d0f23-00b2-47fe-91ab-59ebeaa867ee"),
                columns: new[] { "IsCommercial", "IsDefault" },
                values: new object[] { false, false });

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniques_UtilisateurId",
                table: "DossierTechniques",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniques_Utilisateurs_UtilisateurId",
                table: "DossierTechniques",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniques_Utilisateurs_UtilisateurId",
                table: "DossierTechniques");

            migrationBuilder.DropIndex(
                name: "IX_DossierTechniques_UtilisateurId",
                table: "DossierTechniques");

            migrationBuilder.DropColumn(
                name: "IsCommercial",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "DossierTechniques");
        }
    }
}
