using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateRefDesSTatusPossible2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                column: "Libelle",
                value: "À valider");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                column: "Libelle",
                value: "à valider");
        }
    }
}
