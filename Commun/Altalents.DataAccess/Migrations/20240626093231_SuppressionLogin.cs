using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SuppressionLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_Login",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Utilisateurs");

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: new Guid("f05d0f23-00b2-47fe-91ab-59ebeaa867ee"),
                column: "Email",
                value: "admin@altea-si.com");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Email",
                table: "Utilisateurs",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_Email",
                table: "Utilisateurs");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Utilisateurs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: new Guid("f05d0f23-00b2-47fe-91ab-59ebeaa867ee"),
                columns: new[] { "Email", "Login" },
                values: new object[] { "vlarguier@altea-si.com", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Login",
                table: "Utilisateurs",
                column: "Login",
                unique: true);
        }
    }
}
