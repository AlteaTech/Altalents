using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotDePasseCrypte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActif = table.Column<bool>(type: "bit", nullable: false),
                    IsSupprimable = table.Column<bool>(type: "bit", nullable: false),
                    IsModifiable = table.Column<bool>(type: "bit", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Id", "DateCrea", "DateMaj", "Email", "IsActif", "IsModifiable", "IsSupprimable", "Login", "MotDePasseCrypte", "Nom", "UtiCrea", "UtiMaj" },
                values: new object[] { new Guid("f05d0f23-00b2-47fe-91ab-59ebeaa867ee"), new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vlarguier@altea-si.com", true, false, false, "admin", "AQAAAAIAAYagAAAAEJJ8k1QzsOQCivB/OZ4fO3oRItU9ubWJwyTeSVD8FisyZN0vG9+vG72E5MCF35op2w==", "Super administrateur", "ALTEA", null });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Login",
                table: "Utilisateurs",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Nom",
                table: "Utilisateurs",
                column: "Nom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
