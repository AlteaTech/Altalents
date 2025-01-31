using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add2TypeContatsAlternanceAndStage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("72d1445f-4ade-43bd-b329-1401ea962382"),
                column: "Libelle",
                value: "Stage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("72d1445f-4ade-43bd-b329-1401ea962382"),
                column: "Libelle",
                value: "STage");
        }
    }
}
