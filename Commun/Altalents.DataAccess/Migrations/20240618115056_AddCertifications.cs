#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCertifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Personnes_PersonneId",
                table: "Formations");

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Domaine = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Niveau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Organisme = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateDebut = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_PersonneId",
                table: "Certifications",
                column: "PersonneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Personnes_PersonneId",
                table: "Formations",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Personnes_PersonneId",
                table: "Formations");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Personnes_PersonneId",
                table: "Formations",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
