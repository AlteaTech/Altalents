using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnecesaryFieldsFromExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CompositionEquipe",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Experiences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Experiences",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompositionEquipe",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Experiences",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
