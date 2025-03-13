using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TrigrammeLock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrigrammeLocks",
                columns: table => new
                {
                    Trigramme = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    DateLock = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrigrammeLocks", x => x.Trigramme);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrigrammeLocks_DateLock",
                table: "TrigrammeLocks",
                column: "DateLock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrigrammeLocks");
        }
    }
}
