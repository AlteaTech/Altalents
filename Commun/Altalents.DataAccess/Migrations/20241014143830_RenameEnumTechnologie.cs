using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameEnumTechnologie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("36ec7894-609d-4238-bdcd-5a5962a56eb8"),
                column: "Type",
                value: "Technologie");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9bd90bab-2825-4f36-a49f-9227be2c1f72"),
                column: "Type",
                value: "Technologie");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a12fecbe-e5ec-40f8-86e5-9fc7ffcf1236"),
                column: "Type",
                value: "Technologie");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a3853f2d-bb30-4f82-950d-77dda048c99d"),
                column: "Type",
                value: "Technologie");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a6b3992a-dd4c-4f21-b74a-5e528d47ea71"),
                column: "Type",
                value: "Technologie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("36ec7894-609d-4238-bdcd-5a5962a56eb8"),
                column: "Type",
                value: "OutilEtEnvironnement");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9bd90bab-2825-4f36-a49f-9227be2c1f72"),
                column: "Type",
                value: "OutilEtEnvironnement");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a12fecbe-e5ec-40f8-86e5-9fc7ffcf1236"),
                column: "Type",
                value: "OutilEtEnvironnement");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a3853f2d-bb30-4f82-950d-77dda048c99d"),
                column: "Type",
                value: "OutilEtEnvironnement");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a6b3992a-dd4c-4f21-b74a-5e528d47ea71"),
                column: "Type",
                value: "OutilEtEnvironnement");
        }
    }
}
