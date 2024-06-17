using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLangues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Type = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    SousType = table.Column<int>(type: "int", maxLength: 250, nullable: true),
                    DateCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UtiMaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "DateCrea", "DateMaj", "Libelle", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("05c38683-5c3a-43a9-a603-c553e429ab99"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roumain", null, 1, "ALTEA", null },
                    { new Guid("077fa7cc-9f80-4d11-a791-1109ec17987b"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Croate", null, 1, "ALTEA", null },
                    { new Guid("09bf9503-dea6-4133-a3de-49d8cdcfcdc9"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lingala", null, 1, "ALTEA", null },
                    { new Guid("0f6fda7c-e474-4196-8afb-1bab65bacfd1"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quechua", null, 1, "ALTEA", null },
                    { new Guid("1aeef696-c31e-4987-84f3-2215a98bf350"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turc", null, 1, "ALTEA", null },
                    { new Guid("1fbfbf6e-957e-4565-afd1-173b5cd709d3"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Grec", null, 1, "ALTEA", null },
                    { new Guid("21a7b72e-456c-4b07-9cda-125917d43396"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kikongo", null, 1, "ALTEA", null },
                    { new Guid("224a6eb6-c5c0-44a2-8504-46fa0f158527"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malais", null, 1, "ALTEA", null },
                    { new Guid("25c764de-a813-4848-9d13-2ffea2a2ca44"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiswahili", null, 1, "ALTEA", null },
                    { new Guid("2ad460a4-afa9-4ac0-986f-42d626b82bf1"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arabe", null, 1, "ALTEA", null },
                    { new Guid("3329384f-af76-4eb6-9f15-b8b838af7999"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Slovène", null, 1, "ALTEA", null },
                    { new Guid("356fce26-caaa-4b4e-94d2-f7341d1851b1"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Français", null, 1, "ALTEA", null },
                    { new Guid("389314c5-b5b2-4055-85ef-a0a688b71d1c"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Catalan", null, 1, "ALTEA", null },
                    { new Guid("39577e09-4464-41bc-b9ad-e69b03ba3266"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Portugais", null, 1, "ALTEA", null },
                    { new Guid("3b004521-dc2f-43ec-bd60-5e8c95aa9dae"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Serbe", null, 1, "ALTEA", null },
                    { new Guid("3ca6db24-303d-4fa3-9b5b-5cd8cfd02f11"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arménien", null, 1, "ALTEA", null },
                    { new Guid("3fbcdd3e-7dfa-46bb-bf5d-ae39e4137a07"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Russe", null, 1, "ALTEA", null },
                    { new Guid("41fb2299-36ec-4854-bc78-ee7899af318f"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Éwé", null, 1, "ALTEA", null },
                    { new Guid("560f923c-27de-4891-8e96-db9fe47ca235"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Coréen", null, 1, "ALTEA", null },
                    { new Guid("57580b70-c631-4d9c-8dfa-920b54bfbfaf"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Guarani", null, 1, "ALTEA", null },
                    { new Guid("5ecd41d8-0a66-4315-b489-b26582e78e47"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mongol", null, 1, "ALTEA", null },
                    { new Guid("792a266d-f629-419a-8346-59400b460b2d"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malgache", null, 1, "ALTEA", null },
                    { new Guid("7dc19496-4d9b-413a-b088-090da9f29a08"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ourdou", null, 1, "ALTEA", null },
                    { new Guid("8883e43d-9d64-4976-a0de-cf2fce12c00d"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aymara", null, 1, "ALTEA", null },
                    { new Guid("91cad6f6-cfb2-43bc-b5f5-a1e90ceba77c"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Espagnol", null, 1, "ALTEA", null },
                    { new Guid("9a5769e9-f63f-4f30-85d6-c785247a621a"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amazigh", null, 1, "ALTEA", null },
                    { new Guid("9ed8dd18-affb-4a96-b35a-d0ed17943492"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Slovaque", null, 1, "ALTEA", null },
                    { new Guid("ac04b377-a830-43cc-b249-3ace079a4e61"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Néerlandais", null, 1, "ALTEA", null },
                    { new Guid("b25017fe-4709-474d-9d28-73489c12730b"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hongrois", null, 1, "ALTEA", null },
                    { new Guid("b78239d4-c118-4887-8296-8494cef315bc"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Italien", null, 1, "ALTEA", null },
                    { new Guid("b809599c-6b49-452a-b26c-7438c059bbf8"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tamoul", null, 1, "ALTEA", null },
                    { new Guid("bb490fb1-c45c-4735-ac44-3524dde36275"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Occitan", null, 1, "ALTEA", null },
                    { new Guid("cc2fe62f-a81d-437b-a257-7e89b150042e"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anglais", null, 1, "ALTEA", null },
                    { new Guid("cf3524e8-53a1-4170-81a0-191ebe2e9507"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sesotho", null, 1, "ALTEA", null },
                    { new Guid("cfb960f2-d501-4154-a53a-83f9497bc0ad"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Albanais", null, 1, "ALTEA", null },
                    { new Guid("d4a4a33a-f5d3-488c-89ad-7f552d262b88"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suédois", null, 1, "ALTEA", null },
                    { new Guid("d63f7ab4-b41c-40f5-867b-03b2a7571aca"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samoan", null, 1, "ALTEA", null },
                    { new Guid("e47e9d1a-590d-4b4a-8f9e-219781d36902"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chinois", null, 1, "ALTEA", null },
                    { new Guid("e673effc-4ca5-46d4-bba8-0c4e5c658cb5"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Japonais", null, 1, "ALTEA", null },
                    { new Guid("eb36539d-64bd-4cd7-adc9-27fe1c30a039"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Danois", null, 1, "ALTEA", null },
                    { new Guid("f2ed3127-4acd-4e4b-90b2-b51958dc1357"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Persan", null, 1, "ALTEA", null },
                    { new Guid("f3e4d4b8-4406-4098-ae7f-1ccbf938c5b8"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bengali", null, 1, "ALTEA", null },
                    { new Guid("fe2be6bb-fbda-4115-bc06-5603447cbcbd"), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Allemand", null, 1, "ALTEA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_References_Type_SousType",
                table: "References",
                columns: new[] { "Type", "SousType" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "References");
        }
    }
}
