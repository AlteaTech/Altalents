using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddInfoDt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "References",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commercial",
                table: "DossierTechniques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "DossierTechniques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StatutId",
                table: "DossierTechniques",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("05c38683-5c3a-43a9-a603-c553e429ab99"),
                column: "Code",
                value: "Roumain");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("077fa7cc-9f80-4d11-a791-1109ec17987b"),
                column: "Code",
                value: "Croate");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("09bf9503-dea6-4133-a3de-49d8cdcfcdc9"),
                column: "Code",
                value: "Lingala");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("0f6fda7c-e474-4196-8afb-1bab65bacfd1"),
                column: "Code",
                value: "Quechua");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1aeef696-c31e-4987-84f3-2215a98bf350"),
                column: "Code",
                value: "Turc");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1fbfbf6e-957e-4565-afd1-173b5cd709d3"),
                column: "Code",
                value: "Grec");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21a7b72e-456c-4b07-9cda-125917d43396"),
                column: "Code",
                value: "Kikongo");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("224a6eb6-c5c0-44a2-8504-46fa0f158527"),
                column: "Code",
                value: "Malais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("25c764de-a813-4848-9d13-2ffea2a2ca44"),
                column: "Code",
                value: "Kiswahili");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("2ad460a4-afa9-4ac0-986f-42d626b82bf1"),
                column: "Code",
                value: "Arabe");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3329384f-af76-4eb6-9f15-b8b838af7999"),
                column: "Code",
                value: "Slovene");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("356fce26-caaa-4b4e-94d2-f7341d1851b1"),
                column: "Code",
                value: "Francais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("389314c5-b5b2-4055-85ef-a0a688b71d1c"),
                column: "Code",
                value: "Catalan");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("39577e09-4464-41bc-b9ad-e69b03ba3266"),
                column: "Code",
                value: "Portugais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3a325813-e79d-445a-8953-b665c7581901"),
                column: "Code",
                value: "Dt");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b004521-dc2f-43ec-bd60-5e8c95aa9dae"),
                column: "Code",
                value: "Serbe");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3ca6db24-303d-4fa3-9b5b-5cd8cfd02f11"),
                column: "Code",
                value: "Armenien");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3fbcdd3e-7dfa-46bb-bf5d-ae39e4137a07"),
                column: "Code",
                value: "Russe");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41fb2299-36ec-4854-bc78-ee7899af318f"),
                column: "Code",
                value: "Ewe");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4c573cda-fc0c-42fa-b571-7829f26149cc"),
                column: "Code",
                value: "Cdd");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("560f923c-27de-4891-8e96-db9fe47ca235"),
                column: "Code",
                value: "Coreen");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("57580b70-c631-4d9c-8dfa-920b54bfbfaf"),
                column: "Code",
                value: "Guarani");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5ecd41d8-0a66-4315-b489-b26582e78e47"),
                column: "Code",
                value: "Mongol");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("792a266d-f629-419a-8346-59400b460b2d"),
                column: "Code",
                value: "Malgache");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7dc19496-4d9b-413a-b088-090da9f29a08"),
                column: "Code",
                value: "Ourdou");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8883e43d-9d64-4976-a0de-cf2fce12c00d"),
                column: "Code",
                value: "Aymara");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8f486cd6-6313-47f9-a4b5-5bd535c199a9"),
                column: "Code",
                value: "Immediate");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("91cad6f6-cfb2-43bc-b5f5-a1e90ceba77c"),
                column: "Code",
                value: "Espagnol");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("92dfd90f-79b4-4d5e-93e6-fb7046b3416a"),
                column: "Code",
                value: "SousUnMois");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9a5769e9-f63f-4f30-85d6-c785247a621a"),
                column: "Code",
                value: "Amazigh");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9ed8dd18-affb-4a96-b35a-d0ed17943492"),
                column: "Code",
                value: "Slovaque");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a60b074d-b4af-4157-ab49-453e28da8514"),
                column: "Code",
                value: "Cdi");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("aad8f403-76c8-4dee-b9b5-8ed5a8a28eec"),
                column: "Code",
                value: "Telephone");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ac04b377-a830-43cc-b249-3ace079a4e61"),
                column: "Code",
                value: "Neerlandais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b25017fe-4709-474d-9d28-73489c12730b"),
                column: "Code",
                value: "Hongrois");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b3e98178-68dd-4de3-9e36-a2ed571f21c5"),
                column: "Code",
                value: "Cv");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b78239d4-c118-4887-8296-8494cef315bc"),
                column: "Code",
                value: "Italien");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b809599c-6b49-452a-b26c-7438c059bbf8"),
                column: "Code",
                value: "Tamoul");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bb490fb1-c45c-4735-ac44-3524dde36275"),
                column: "Code",
                value: "Occitan");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cc2fe62f-a81d-437b-a257-7e89b150042e"),
                column: "Code",
                value: "Anglais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cf3524e8-53a1-4170-81a0-191ebe2e9507"),
                column: "Code",
                value: "Sesotho");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cfb960f2-d501-4154-a53a-83f9497bc0ad"),
                column: "Code",
                value: "Albanais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d4a4a33a-f5d3-488c-89ad-7f552d262b88"),
                column: "Code",
                value: "Suedois");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d63f7ab4-b41c-40f5-867b-03b2a7571aca"),
                column: "Code",
                value: "Samoan");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e47e9d1a-590d-4b4a-8f9e-219781d36902"),
                column: "Code",
                value: "Chinois");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e673effc-4ca5-46d4-bba8-0c4e5c658cb5"),
                column: "Code",
                value: "Japonais");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("eb36539d-64bd-4cd7-adc9-27fe1c30a039"),
                column: "Code",
                value: "Danois");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f2ed3127-4acd-4e4b-90b2-b51958dc1357"),
                column: "Code",
                value: "Persan");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f35745ef-66d0-4cb0-9657-b57c2f149e3f"),
                column: "Code",
                value: "SousTroisMois");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f3e4d4b8-4406-4098-ae7f-1ccbf938c5b8"),
                column: "Code",
                value: "Bengali");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fe2be6bb-fbda-4115-bc06-5603447cbcbd"),
                column: "Code",
                value: "Allemand");

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "DateCrea", "DateMaj", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("02e3d3ee-f745-4bf1-a00d-61e640dac8ae"), "AModifier", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Modifier", 5, null, "StatutDt", "ALTEA", null },
                    { new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"), "EnCours", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "En Cours", 2, null, "StatutDt", "ALTEA", null },
                    { new Guid("5f92b7d6-4ddf-4ec5-965b-9824387afa57"), "Cree", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Créé", 1, null, "StatutDt", "ALTEA", null },
                    { new Guid("610f6ca4-0f22-44ec-9269-f744873b92f2"), "NonValide", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Non valide", 3, null, "StatutDt", "ALTEA", null },
                    { new Guid("78a3cb44-9fd3-4c6c-9848-677937324ecd"), "Valide", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Valide", 4, null, "StatutDt", "ALTEA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierTechniques_StatutId",
                table: "DossierTechniques",
                column: "StatutId");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierTechniques_References_StatutId",
                table: "DossierTechniques",
                column: "StatutId",
                principalTable: "References",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierTechniques_References_StatutId",
                table: "DossierTechniques");

            migrationBuilder.DropIndex(
                name: "IX_DossierTechniques_StatutId",
                table: "DossierTechniques");

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("02e3d3ee-f745-4bf1-a00d-61e640dac8ae"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f1d5f70-c35d-45c2-b0b8-6ee8ff2ea1a5"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5f92b7d6-4ddf-4ec5-965b-9824387afa57"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("610f6ca4-0f22-44ec-9269-f744873b92f2"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("78a3cb44-9fd3-4c6c-9848-677937324ecd"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "References");

            migrationBuilder.DropColumn(
                name: "Commercial",
                table: "DossierTechniques");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "DossierTechniques");

            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "DossierTechniques");
        }
    }
}
