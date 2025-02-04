using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class setDomaineMetierExpNonObligatoire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DomaineMetierId",
                table: "Experiences",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DomaineMetierId",
                table: "Experiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"));
        }
    }
}
