#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFkDt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Personnes_PersonneId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Personnes_PersonneId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Personnes_PersonneId",
                table: "Formations");

            migrationBuilder.DropTable(
                name: "PersonneLangues");

            migrationBuilder.RenameColumn(
                name: "PersonneId",
                table: "Formations",
                newName: "DossierTechniqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Formations_PersonneId",
                table: "Formations",
                newName: "IX_Formations_DossierTechniqueId");

            migrationBuilder.RenameColumn(
                name: "PersonneId",
                table: "Experiences",
                newName: "DossierTechniqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_PersonneId",
                table: "Experiences",
                newName: "IX_Experiences_DossierTechniqueId");

            migrationBuilder.RenameColumn(
                name: "PersonneId",
                table: "Certifications",
                newName: "DossierTechniqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_PersonneId",
                table: "Certifications",
                newName: "IX_Certifications_DossierTechniqueId");

            migrationBuilder.AddColumn<string>(
                name: "CommentaireFun",
                table: "References",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValide",
                table: "References",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DossierTechniqueLangues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DossierTechniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LangueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierTechniqueLangues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierTechniqueLangues_DossierTechniques_DossierTechniqueId",
                        column: x => x.DossierTechniqueId,
                        principalTable: "DossierTechniques",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DossierTechniqueLangues_References_LangueId",
                        column: x => x.LangueId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("02e3d3ee-f745-4bf1-a00d-61e640dac8ae"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("05c38683-5c3a-43a9-a603-c553e429ab99"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("077fa7cc-9f80-4d11-a791-1109ec17987b"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("09bf9503-dea6-4133-a3de-49d8cdcfcdc9"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("0f6fda7c-e474-4196-8afb-1bab65bacfd1"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1aeef696-c31e-4987-84f3-2215a98bf350"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1fbfbf6e-957e-4565-afd1-173b5cd709d3"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21a7b72e-456c-4b07-9cda-125917d43396"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("224a6eb6-c5c0-44a2-8504-46fa0f158527"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("25c764de-a813-4848-9d13-2ffea2a2ca44"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("2ad460a4-afa9-4ac0-986f-42d626b82bf1"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3329384f-af76-4eb6-9f15-b8b838af7999"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("356fce26-caaa-4b4e-94d2-f7341d1851b1"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("389314c5-b5b2-4055-85ef-a0a688b71d1c"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("39577e09-4464-41bc-b9ad-e69b03ba3266"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3a325813-e79d-445a-8953-b665c7581901"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b004521-dc2f-43ec-bd60-5e8c95aa9dae"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3ca6db24-303d-4fa3-9b5b-5cd8cfd02f11"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3fbcdd3e-7dfa-46bb-bf5d-ae39e4137a07"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41fb2299-36ec-4854-bc78-ee7899af318f"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4c573cda-fc0c-42fa-b571-7829f26149cc"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("560f923c-27de-4891-8e96-db9fe47ca235"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("57580b70-c631-4d9c-8dfa-920b54bfbfaf"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5ecd41d8-0a66-4315-b489-b26582e78e47"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f92b7d6-4ddf-4ec5-965b-9824387afa57"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("610f6ca4-0f22-44ec-9269-f744873b92f2"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("78a3cb44-9fd3-4c6c-9848-677937324ecd"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("792a266d-f629-419a-8346-59400b460b2d"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7dc19496-4d9b-413a-b088-090da9f29a08"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8883e43d-9d64-4976-a0de-cf2fce12c00d"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8f486cd6-6313-47f9-a4b5-5bd535c199a9"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("91cad6f6-cfb2-43bc-b5f5-a1e90ceba77c"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("92dfd90f-79b4-4d5e-93e6-fb7046b3416a"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9a5769e9-f63f-4f30-85d6-c785247a621a"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9ed8dd18-affb-4a96-b35a-d0ed17943492"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a60b074d-b4af-4157-ab49-453e28da8514"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("aad8f403-76c8-4dee-b9b5-8ed5a8a28eec"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ac04b377-a830-43cc-b249-3ace079a4e61"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b25017fe-4709-474d-9d28-73489c12730b"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b3e98178-68dd-4de3-9e36-a2ed571f21c5"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b78239d4-c118-4887-8296-8494cef315bc"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b809599c-6b49-452a-b26c-7438c059bbf8"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bb490fb1-c45c-4735-ac44-3524dde36275"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cc2fe62f-a81d-437b-a257-7e89b150042e"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cf3524e8-53a1-4170-81a0-191ebe2e9507"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cfb960f2-d501-4154-a53a-83f9497bc0ad"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d4a4a33a-f5d3-488c-89ad-7f552d262b88"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d63f7ab4-b41c-40f5-867b-03b2a7571aca"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e47e9d1a-590d-4b4a-8f9e-219781d36902"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e673effc-4ca5-46d4-bba8-0c4e5c658cb5"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("eb36539d-64bd-4cd7-adc9-27fe1c30a039"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f2ed3127-4acd-4e4b-90b2-b51958dc1357"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f35745ef-66d0-4cb0-9657-b57c2f149e3f"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f3e4d4b8-4406-4098-ae7f-1ccbf938c5b8"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fe2be6bb-fbda-4115-bc06-5603447cbcbd"),
                columns: new[] { "CommentaireFun", "IsValide" },
                values: new object[] { null, true });

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniqueLangues_DossierTechniqueId",
                table: "DossierTechniqueLangues",
                column: "DossierTechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniqueLangues_LangueId",
                table: "DossierTechniqueLangues",
                column: "LangueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_DossierTechniques_DossierTechniqueId",
                table: "Certifications",
                column: "DossierTechniqueId",
                principalTable: "DossierTechniques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_DossierTechniques_DossierTechniqueId",
                table: "Experiences",
                column: "DossierTechniqueId",
                principalTable: "DossierTechniques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_DossierTechniques_DossierTechniqueId",
                table: "Formations",
                column: "DossierTechniqueId",
                principalTable: "DossierTechniques",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_DossierTechniques_DossierTechniqueId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_DossierTechniques_DossierTechniqueId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Formations_DossierTechniques_DossierTechniqueId",
                table: "Formations");

            migrationBuilder.DropTable(
                name: "DossierTechniqueLangues");

            migrationBuilder.DropColumn(
                name: "CommentaireFun",
                table: "References");

            migrationBuilder.DropColumn(
                name: "IsValide",
                table: "References");

            migrationBuilder.RenameColumn(
                name: "DossierTechniqueId",
                table: "Formations",
                newName: "PersonneId");

            migrationBuilder.RenameIndex(
                name: "IX_Formations_DossierTechniqueId",
                table: "Formations",
                newName: "IX_Formations_PersonneId");

            migrationBuilder.RenameColumn(
                name: "DossierTechniqueId",
                table: "Experiences",
                newName: "PersonneId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_DossierTechniqueId",
                table: "Experiences",
                newName: "IX_Experiences_PersonneId");

            migrationBuilder.RenameColumn(
                name: "DossierTechniqueId",
                table: "Certifications",
                newName: "PersonneId");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_DossierTechniqueId",
                table: "Certifications",
                newName: "IX_Certifications_PersonneId");

            migrationBuilder.CreateTable(
                name: "PersonneLangues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LangueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    Niveau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Personnes_PersonneId",
                table: "Certifications",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Personnes_PersonneId",
                table: "Experiences",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Personnes_PersonneId",
                table: "Formations",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id");
        }
    }
}
