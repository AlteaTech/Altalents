using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AutoIncrementNumDt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "DossierTechniques");

            migrationBuilder.AddColumn<int>(
                name: "NumeroUnique",
                table: "DossierTechniques",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniques_NumeroUnique",
                table: "DossierTechniques",
                column: "NumeroUnique",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DossierTechniques_NumeroUnique",
                table: "DossierTechniques");

            migrationBuilder.RenameColumn(
                name: "NumeroUnique",
                table: "DossierTechniques",
                newName: "Numero");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "DossierTechniques",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
