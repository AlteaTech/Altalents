using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class orthograph1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("2aa6bdda-0bf1-4792-9209-c3b05b37a3af"),
                column: "Libelle",
                value: "Avancé");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9398ffec-86fa-43f1-a180-478cd43b85a7"),
                column: "CommentaireFun",
                value: "tu te la pètes");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "TourismeLoisirs", "Tourisme / Loisirs" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("2aa6bdda-0bf1-4792-9209-c3b05b37a3af"),
                column: "Libelle",
                value: "Avance");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9398ffec-86fa-43f1-a180-478cd43b85a7"),
                column: "CommentaireFun",
                value: "tu te la pète");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                columns: new[] { "Code", "Libelle" },
                values: new object[] { "TourismeLoisir", "Tourisme / Loisir" });
        }
    }
}
