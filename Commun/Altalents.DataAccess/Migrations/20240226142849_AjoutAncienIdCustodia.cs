using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAncienIdAltalents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AncienIdAltalents",
                table: "Marques",
                type: "varchar(400)",
                unicode: false,
                maxLength: 400,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marques_AncienIdAltalents",
                table: "Marques",
                column: "AncienIdAltalents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marques_AncienIdAltalents",
                table: "Marques");

            migrationBuilder.DropColumn(
                name: "AncienIdAltalents",
                table: "Marques");
        }
    }
}
