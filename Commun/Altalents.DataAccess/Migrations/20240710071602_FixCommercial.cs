#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCommercial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniques_Utilisateurs_UtilisateurId",
                table: "DossierTechniques");

            migrationBuilder.DropColumn(
                name: "Commercial",
                table: "DossierTechniques");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "DossierTechniques",
                newName: "CommercialId");

            migrationBuilder.RenameIndex(
                name: "IX_DossierTechniques_UtilisateurId",
                table: "DossierTechniques",
                newName: "IX_DossierTechniques_CommercialId");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniques_Utilisateurs_CommercialId",
                table: "DossierTechniques",
                column: "CommercialId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniques_Utilisateurs_CommercialId",
                table: "DossierTechniques");

            migrationBuilder.RenameColumn(
                name: "CommercialId",
                table: "DossierTechniques",
                newName: "UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_DossierTechniques_CommercialId",
                table: "DossierTechniques",
                newName: "IX_DossierTechniques_UtilisateurId");

            migrationBuilder.AddColumn<string>(
                name: "Commercial",
                table: "DossierTechniques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniques_Utilisateurs_UtilisateurId",
                table: "DossierTechniques",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }
    }
}
