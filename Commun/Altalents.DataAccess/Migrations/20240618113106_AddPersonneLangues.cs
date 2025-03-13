#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonneLangues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonneLangues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PersonneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LangueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneLangues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonneLangues_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonneLangues_References_LangueId",
                        column: x => x.LangueId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonneLangues_LangueId",
                table: "PersonneLangues",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneLangues_PersonneId",
                table: "PersonneLangues",
                column: "PersonneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonneLangues");
        }
    }
}
