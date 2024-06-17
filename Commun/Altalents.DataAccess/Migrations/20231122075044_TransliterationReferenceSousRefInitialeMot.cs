using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TransliterationReferenceSousRefInitialeMot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LibelleTransLitLower2",
                table: "SousReferences",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LibelleTransLitLowerFr",
                table: "SousReferences",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LibelleTransLitLower2",
                table: "References",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LibelleTransLitLowerFr",
                table: "References",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialesTransLitLowerFr",
                table: "Marques",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TexteTransLitLowerFr",
                table: "MarqueReferenceLibres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("050a2cf0-68ab-e846-bb93-beae8caf2e73"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stencilled mark", "marque au pochoir" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("0d02021a-1cc2-4c4f-b40e-c0fbd430264e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "initial", "initiale" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("0e3d3ac7-e706-114d-91e1-a407a37a22c4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "other", "autre" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("0ea93d49-c025-9d44-8063-79738942d02d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "merchant mark", "marque de marchand" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1003b140-2a85-ec4c-9593-2214ead7b7ca"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "object or representation", "objet ou representation divers" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("16291a5b-c359-4c46-a0a7-e3915a6d79f2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "south america", "amerique du sud" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1958866d-f7d7-4d40-a49d-b96e74d80057"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "russia", "russie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1a829dde-a7a1-2142-8ef2-7c5259c1f5c0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "verso", "verso" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1ccc9766-665c-e544-ac97-6690eb4a7ea7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "publisher", "editeur" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1ccdbb6f-0dd1-334f-ac19-b682d598e684"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "black", "noir" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1d5a2106-a203-0241-a8a1-2298137c2129"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "germany", "allemagne" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("1d98bf80-69af-2540-9ea2-bf59c9eb6848"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "assembly", "montage" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("22aeaecd-6c67-584d-94fa-f1d87ab4a5f9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cyprus", "chypre" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("23b035e7-90a3-1b4b-b736-07d307efeed7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oval", "ovale" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("249d2961-b052-9946-9349-14fd7f10642d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "norway", "norvege" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("2759e2f0-b831-e345-a369-616a16978fa0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "green", "vert" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("37e2419f-1366-4f44-8b64-3e5ae3cee3fe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "purple", "violet" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("426156e4-9be6-9247-b94b-c312b824f5e9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "octagonal shape", "forme a pans coupes" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("42869a21-c6e6-5745-9729-469d1e536618"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "egypt", "egypte" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("47952cb9-f66c-7f4c-acc0-a0f1d8753c62"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "portugal", "portugal" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("48f2cf10-21ef-2d4e-82f0-eb19075a779a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "collector", "collectionneur" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4a109cc4-73be-5a4a-a5d7-691b8253c23a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "blue", "bleu" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4ae98b22-d56b-1847-9193-ebb732852bb4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "canada", "canada" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4d918a28-4fbc-f943-a845-f9954d937f44"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "czech republic", "republique tcheque" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("504bad24-cdcf-b849-a93d-e003bdb2b4a1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "estonia", "estonie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("50f53bbd-091d-4647-a57c-97cdc00fe2e6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "finland", "finlande" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5222535c-70eb-ee42-8a6a-957e378716dc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "united kingdom", "royaume-uni" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("525a0b2e-5390-784d-8f7f-27f6344a0e3c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "italy", "italie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("592c4b7a-af4f-d54f-99ec-d28788fa4888"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rectangular", "rectangulaire" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5cb62f81-5f2e-4847-b384-a4ce50dd2894"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "orange", "orange" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("6234127c-cce0-bf4c-bce3-f4f68568f276"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "other", "autre" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("623a987e-f9f5-744a-bd6f-be49708d5872"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "animal", "animal" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("639a1da5-2e79-fe42-9b2a-d668827c344a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "israel", "israel" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("665f0321-3716-da45-a83c-e589e301a9ca"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "denmark", "danemark" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("6a5fe636-58f0-7447-8066-2c27e033f8f0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gold", "or" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("6e59d4d7-42c9-914e-9c32-21148735ba71"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ireland", "irlande" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("6f07069f-9215-e845-8930-ca0b25650f5b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "czechia", "tchequie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("6f2a1ebf-04b5-424f-b87a-758eda1e4df8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "coat of arms", "armoirie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("726beeb0-5e15-ec44-aabb-3b8f963d6744"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hungary", "hongrie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("728ae5cd-712a-7d41-9d42-d1a9691596f9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "spain", "espagne" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("73277e87-09c2-1d49-ac87-79599a1bf91d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "slovakia", "slovaquie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7472764b-6144-0a41-9235-668533e1a190"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "netherlands", "pays-bas" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("79bd59d1-fb0d-214e-ac1e-f9ab7c409aa1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "australia", "australie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7a0e83be-e8d6-a741-8503-34e5527c055d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "writing sample", "specimen d'ecriture" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7ac19e77-d0fe-c84c-b58b-e27fe34c2a8b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "austria", "autriche" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7daf94a0-5fec-b444-bc61-5f94b455c9f2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "jersey", "jersey" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("80457266-c806-6d40-9d5f-c169cea93ba0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ukraine", "ukraine" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("84884424-1252-f040-9b38-66da045fae71"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "circular", "circulaire" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8de86e9c-4fb8-9b41-ae58-8be834d6b9bd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "silver", "argent" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("97227b33-2075-1e4f-911c-0e3a371fd512"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "yellow", "jaune" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("98318d36-ccc8-0340-9daa-6b80422b44c9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "india", "inde" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9b168893-47fa-0040-ba31-eb0121824724"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "geometric figure", "figure geometrique" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9b50adb6-07d6-8948-b41e-50ac82517576"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "number", "numero" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a41440d5-fa01-3f49-8041-0f89024bf1fe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lithuania", "lituanie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ad901aae-b7ff-7d44-b14a-2437b5e868ac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stamped mark", "marque estampee" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("aefc01cf-f4db-fc43-908e-040e1c9c8041"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "belgium", "belgique" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b06a7b0b-d3c3-cd48-a59c-13f31b30b1d2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "japanese characters", "caractere japonais" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b4d86f62-46c2-4d41-a8b1-f515f2a22103"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "france", "france" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b68e5a21-d66c-ab41-916e-400651cae666"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "japan", "japon" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("b74c6220-78d4-bf47-9e6b-0458d09eae0e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "algeria", "algerie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c6390328-0de8-be45-bf77-e48b931845e3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vegetation", "vegetal" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c9036798-1132-654c-9392-466ea95460c6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "library mark", "marque de bibliotheque" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c9b48a64-7214-1745-978b-8cacebe6097c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "word", "mot" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ca1ef0c1-265c-254e-9036-feb6e774f3d7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "romania", "roumanie" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("cb382fd0-0139-5e4d-8018-75b8a55985b5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "paraph", "paraphe" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d16e329c-98b2-e64d-8d2a-d8c3e0d2217a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brown", "brun" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d1bc641a-3d92-c84a-855d-47598dae9f07"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sweden", "suede" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d65d993f-0b27-df45-8c0e-9ff31f041b63"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "united states", "etats-unis" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d8ad71ed-1695-6040-bd41-a3cca4228706"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "collection, artist's, workshop's, or estate mark", "marque de collection, d'artiste, d'atelier ou de succession" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("da06a210-3153-b647-a20a-a03f4ab2df8b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "human body", "corps humain" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e1bf3579-e349-5645-9faa-a7b490d9acc6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "red", "rouge" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e21e87b9-24e5-7e49-805d-a4f5c5479bd4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "museum, academy, foundation, or library mark", "marque de musee, d'academie, fondation ou bibliotheque" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e489d0a4-5d50-9041-a03b-f0a13952cd62"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "label", "marque rapportee" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e575f758-2278-e346-a582-94ade12fe933"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "morocco", "maroc" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e972150d-51e0-1944-9519-a18de1f2688a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "switzerland", "suisse" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("eba70e62-956d-174b-8704-4bd821367ea5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "printer's, publisher's, or company's mark", "marque d'imprimeur, editeur ou de societe" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ec790a75-4fbd-4e4b-8fcf-6ff51a77f708"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "liechtenstein", "liechtenstein" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ef66f1b2-04f8-7b47-a17d-6d3da3820167"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "recto", "recto" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f4301c0a-8fab-c940-aebe-9192c43582b0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hawaii", "hawai" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f53b3305-97f9-7147-91e6-90c520d24ccc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brazil", "bresil" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f97784e0-13c4-8843-a9c1-c0a4953239b9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "poland", "pologne" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f9dce163-b6ab-7244-901c-97a146e87956"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "argentina", "argentine" });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fe9fa763-f5a7-2d44-a611-837cba4615df"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "written mark", "marque ecrite" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0018f941-9bee-5d4d-b00b-364de5667dc3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "leipzig", "leipzig" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("00370b34-8c3b-8246-a417-3882204e0df5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "copenhagen", "copenhague" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("01302a58-f496-fd4d-b66e-840a6138d9cd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "le pouldu", "le pouldu" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("02277430-8a16-3046-8fb9-1d1ea5b49906"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "portland", "portland" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0261d20e-2548-4a45-a1c2-e49f1adc294f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "orleans", "orleans" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("02685361-dd6c-1640-aa00-c81231a353fd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "orrouy", "orrouy" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0268ee25-fc4d-414b-aafe-8b53510b45ef"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rhoon", "rhoon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("026f9a84-4f43-b749-afe8-24da03006067"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "flag or banner", "drapeau ou banderole" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("027c4fbc-4352-ec4a-85ca-afb2261f683e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "munich", "munich" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("027de199-51ab-9e42-a268-f6a6c83ed4ac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "olesnica mala", "olesnica mala" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0386d6ec-0a41-0e47-9ee6-bec46c161978"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "devonport", "devonport" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("039b3eca-1f74-4f4c-8d85-4104c4c49e4b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "arrow", "fleche" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("041a1940-28f0-234c-9814-3e801bbdaff7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fasces", "faisceau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("04b044c5-5324-0e49-9143-6f69fe0fc26a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stafford", "stafford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("04c7d840-537b-e246-b462-804696875915"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dumbarton", "dumbarton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("05177ba2-2151-f642-9e05-b556ea699ead"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "intaglio press", "presse a taille douce" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("062ef8a7-0a77-ec42-89a1-cc16a4e5bc9c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "shenley", "shenley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("066315a9-7c36-2c4a-8751-2e302dd62eed"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mechelen", "malines" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("06a274ff-dbd4-e749-be08-83cc32442ee3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "circle", "cercle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0714fe23-6eb5-2c4b-b8b9-e29448e4787c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "abbenbroek", "abbenbroek" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("07b62772-f871-2b4b-9e48-d6129535d73f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "loberod", "loberod" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("07e9d83e-174e-3c45-ac53-1ef792e7d83b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "essen", "essen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("08acfea5-72ac-4f4c-93e9-cba55799e723"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "figure", "figure" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("092781ca-cac0-d84c-8b77-69510272073d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "glasgow", "glasgow" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("097649b3-8dd3-9843-a8d4-4abe014156a5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wroclaw", "wroclaw (anc. breslau)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0983a3d2-e920-9a4d-b71a-bab0e589589d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "alcobaca", "alcobaca" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0990ae74-f213-a54d-b317-8787bc765b65"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cernay-la-ville", "cernay-la-ville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0a48f6fb-0469-7048-8a2d-57c024c0f15e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nancy", "nancy" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0af22c8b-cb26-1f45-8931-bfb98974002b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "schaffhausen", "schaffhouse" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0b69dfd0-1f71-e04b-8969-cc7a7430031d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kiev", "kiev" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0ba6ef0f-5e59-b44a-8217-7b0de67218bf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hilo farm", "hilo farm" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0bd564df-f841-c04c-a941-d706f891390b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "geneva", "geneve" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0bed756b-5ee7-db4e-b0d5-50487f0d447a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bude", "bude" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0c2d1dd6-3366-0044-a157-5084a49d61a9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "evesham", "evesham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0ccebe5f-c343-8a44-a6bc-7339261c84fe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gottingen", "gottingen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0d22fa8b-13aa-5d41-b558-817e1290a550"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "soelen", "soelen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0d3f902a-0cdd-3948-8318-8e684260233e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "baarn", "baarn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0d666a3b-0080-6043-98c6-b5fefc40ef6c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ermlitz", "ermlitz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0dc4eb0b-165e-d842-81d2-e01de150e9a5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "edam", "edam" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0e23d5f5-4585-7d4c-bc10-a8af35a8a962"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "potsdam", "potsdam" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0e798cff-e5a1-0b43-b9ed-6005d293e5f4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint ingbert", "saint ingbert" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("0f0f7eff-5da8-3846-84ef-7e2d8591b488"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "alveslohe", "alveslohe" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("103d59d9-cba5-2f40-be2a-c1193b6abf8f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "schiedam", "schiedam" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("10585d48-b75b-c046-a9dc-83d59b62ba5c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dolsk", "dolsk" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1058ff07-3da9-034f-94f4-c4e67ec84b67"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "manchester", "manchester" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("105ec988-0f0b-7247-9039-e4bbd5252ce9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ansbach", "ansbach" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1102d32c-29e8-da49-b83e-e7c56c624527"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "carpentras", "carpentras" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("11e523dd-db5d-3845-8018-50c55ac4d656"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "berck-sur-mer", "berck-sur-mer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("12462fa6-3f03-a842-b9f8-68840e928b3f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mildenhall", "mildenhall" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("138895ae-9cb5-3e4a-ad4d-d894d68d1657"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oosterbeek", "oosterbeek" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("13e42627-7b5c-d346-b2e7-a5c7e2d63c27"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bayonne", "bayonne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("15d3d62a-f86e-044c-8add-78a71ab8092a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dijon", "dijon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("15de249b-4a64-0345-a3dc-799bccd85a98"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lausanne", "lausanne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1606e01e-fd5d-a247-8737-bbe1e98eff49"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bucharest", "bucarest" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("16c4668b-1ead-e74d-80d2-234b0ef07f40"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chateauvieux", "chateauvieux" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("16e4fdb4-604e-9b4f-8068-be1d82e2093c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nemours", "nemours" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("17f0b228-c5f1-774e-8fd5-3070b861eef9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rancho palos verdes", "rancho palos verdes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("17f5246e-139e-864f-be96-43edb2ee950e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "leiden", "leyde" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("180de05e-26d5-c247-b805-2e7936a763e3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rueil-malmaison", "rueil-malmaison" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("18227856-338b-2e4a-a660-a4472b912657"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "quimper", "quimper" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("18796728-080d-f649-8545-e7b60aeb9bfc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "easton court", "easton court" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("189fe094-e8c9-b049-9065-932ca392332e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cronberg", "cronberg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("18abeee2-c226-bb44-8968-d40ec33f0293"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "laon", "laon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("18c51840-e273-b24d-9431-0996fc2a7bcf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "liverpool", "liverpool" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("18c7c5cc-8164-9644-9f2f-bda2792e30eb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "giessen", "giessen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("18c96252-ec85-104e-b389-964b7d25a98a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chambourcy", "chambourcy" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("19cc8e64-2ad7-7f45-bff1-df807471a325"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "thornton-le-street", "thornton-le-street" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1a4bb102-54f5-7745-9a52-b8b0872e016a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cagnes-sur-mer", "cagnes-sur-mer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1a7a59de-12a4-c141-914a-bbe309ab80f3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bath", "bath" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1a88b193-0a9e-194a-9f42-de61025d73e7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "alton", "alton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1ac6a785-6ef1-9441-8948-dcceec4ee640"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "epping", "epping" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1b69a31e-35ee-954a-bc7c-d03f7fb94aea"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "innsbruck", "innsbruck" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1bee23e3-8961-314a-967f-d668adc7aa82"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "elberfeld", "elberfeld" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1c5f72c7-358c-2e4e-ac04-2e6d99fb3766"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "toulon", "toulon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1caa93dd-765d-9e4d-85f0-0a2e3ff487c3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "new haven", "new haven" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1cbe1ba0-510c-874e-9862-93d3687f51ab"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stassfurt", "stassfurt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1d031f0e-c206-fe4b-b0a3-f8c4a4966a2a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "altenburg", "altenburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1d08c0cc-4066-c84e-8f7a-2bca863903d1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "strasbourg", "strasbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1e1055f0-1729-8448-af86-1c2463004f53"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gotha", "gotha" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1ed1bb1a-59a1-3648-9235-b923963a26b9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "'s-hertogenbosch", "bois-le-duc" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1ed71985-c8be-5f4d-93fb-4c163545e072"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "laas", "laas" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1f082a1b-105f-1648-b19f-7df85a04e8e4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lisbon", "lisbonne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1f2a208b-733a-d34e-802c-1741c8b4f899"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "modena", "modene" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1f6ce775-fb2e-a147-8c93-094b304ba9b5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "venice", "venise" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1f7894ae-847f-d741-91e4-17dcb2c24a09"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "verona", "verone" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("1fe25935-45e8-7143-88b7-6a40de54be19"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "honiton", "honiton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2023c512-4fba-d049-af63-294cd61ba285"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sigmaringen", "sigmaringen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2073262b-df4d-374e-9290-0568cfc69c2e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "atlanta", "atlanta" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2107a901-2d41-8d48-8381-778f70a196d2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "riehen", "riehen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("21cd363a-46d7-be4d-9348-08d133d86d7b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "axe", "hache" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("21e26c9d-6017-e041-9dd7-00e58134ac37"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "abergavenny", "abergavenny" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2235a4bf-a8f2-894e-92bc-7f6112dd1485"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "overveen", "overveen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("22417e31-676f-7e46-a86a-4a263e3ae9ac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oar", "aviron" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2258045e-f94e-214f-a96c-6bd55aece876"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "finspang", "finspang" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2265eacf-843a-4d44-ab4f-ad0fab008b02"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "halberstadt", "halberstadt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("229f4c23-52b8-6543-8c6e-a787bad89366"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bourron-marlotte", "bourron-marlotte" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2310ee58-8d48-2a47-b826-fb35ef41973e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "building or part of a building", "batiment ou partie de batiment" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("232acc93-f0e4-2c45-aee7-62efc2ac59ca"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kazan", "kazan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("23e66b03-78d3-3040-85e7-8064c546a0d8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fresnay", "fresnay" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("24229654-0d1b-ab4e-8ffc-b8cb1af1dc22"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "maisons-laffitte", "maisons-laffitte" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("256bcbc3-1de0-a04c-8347-383d394e20c2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "urbino", "urbino" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("259803da-1ac0-0b4a-ab11-13e32e73501f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mammal", "mammifere" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("25a80ff9-9f30-7e4b-8fb5-60ea4b573de3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "jewelry", "bijou" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("26619270-295e-8a48-baf3-097405dd54e9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bergamo", "bergame" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2704642a-fdcf-e344-9214-6f6a7047a96b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "toledo", "toledo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2740ea67-d862-7e45-8c67-eb8e93600dd7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "crocetta", "crocetta" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("27c72068-06bb-b245-b82a-c9c72d66e361"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eutin", "eutin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2893b62d-ff69-7645-976b-a28853e218b5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "berg en dal", "berg en dal" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("28c0047c-e14b-7847-a94e-83ed933e883f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "beaumesnil", "beaumesnil" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2a7d90f4-3a0a-564d-bf3d-d7f2227ff4e7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dachau", "dachau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2a80c82e-6d98-9142-9fbe-d94ba09856fa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "heligoland", "helgoland" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2a9cbcfa-7926-0d4a-89f6-97fa40ba0076"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "angouleme", "angouleme" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2abf45d1-f3a5-5e47-be21-47735f4a243a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "reims", "reims" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2b428bf5-ebb1-344f-83bd-f0047b41fc31"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bolsward", "bolsward" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2ccae0fe-a90a-5047-aeab-15522989555b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "seville", "seville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2e09622a-5a27-e548-9618-9160a7c19df3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "viroflay", "viroflay" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2e1cb163-2941-c54f-8636-05984de32eae"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sacramento", "sacramento" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2e5b9ecd-6bbd-854a-a48a-210c151c13c7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kincardine-on-forth", "kincardine-on-forth" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2ea3854f-35b4-5240-8984-cc3cb7f6d690"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "anchor", "ancre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2ea7a60b-3142-994a-9485-fec70ba4cd60"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "athens", "athens" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2f323847-0311-634b-8fb1-927ce715d560"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brighton", "brighton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("2f953150-1437-674d-9dc8-cdeb3b881b29"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tunbridge wells", "tunbridge wells" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3036d838-23fb-3649-8353-1dcb6d800855"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "englewood", "englewood" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3079530a-6176-d847-979f-b749d3f1b3b0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aufsess", "aufsess" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3099096a-0f86-9241-a0c2-5a75ec4e49df"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "geneseo", "geneseo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("32c69cb5-7c54-8e49-8c32-86492c82cf1f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ammendrup", "ammendrup" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("32dfaa51-4aca-5545-82b6-788a70cf0a85"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dillingen", "dillingen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("33080aa4-5c3f-4f46-b89e-2903613e0093"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dresden", "dresde" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3336029c-ad39-5948-aed3-01f70ec91ed3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "radachow", "radachow" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("337056d8-4762-754c-bf85-b3ed6b220f95"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "winterthur", "winterthur" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("33817284-080c-de45-a514-9002ecaa1f98"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sword", "epee" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("34284e87-2d4f-8244-94ee-bc148d99ee55"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "maartensdijk", "maartensdijk" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("342e82c3-3380-3144-b506-4872d80a9c58"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bern", "berne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("343eedbd-b34f-fd46-add3-6ad56f9f77c0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fullero", "fullero" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3489bed1-0e19-be49-909e-76cd2a581e74"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "deventer", "deventer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("34925696-7433-4840-8b4f-4faa4814a3b9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "seattle", "seattle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("353fac66-c0eb-7d43-b906-247fbca39f0a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hawaii", "hawai" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("355e8cc8-edc3-8240-8979-77a58f626338"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "turnov", "turnau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("361b286e-27cc-6d41-b67c-16542886cab8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "head", "tete" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("36c06043-acbe-2449-baf7-097bf53b5d6c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "great packington", "great packington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("36f923e7-b5ea-f240-8a5e-a9523c9e8dc5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "koniggratz", "koniggratz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("378730ff-7997-7f48-8842-d5d04c087b2b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sierksdorf", "sierksdorf" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("378a7913-b463-1043-9f57-086d704194e7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lyon", "lyon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("37a97949-fadd-6949-967b-32c0ea4eeeed"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-amand-en-puisaye", "saint-amand-en-puisaye" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("37da1e19-5222-c34f-9519-a3dd1db3abda"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pavlovsk", "pavlovsk" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("37ed3c30-d723-6441-a58c-95c3455f4b7e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lozere sur yvette", "lozere sur yvette" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("37f06b55-3144-5b4c-973b-c45fde1e0c8c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "book", "livre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("383aedb9-4a17-1947-a609-359551e82b4f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "baltimore", "baltimore" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3851f9eb-6cec-0e45-9b7c-f0e7aea4da8b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "la rochelle", "la rochelle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("386bc669-3b15-2a49-a0a2-ad421045e3be"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ottawa", "ottawa" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("387f7eed-4929-2045-a15c-59561355924b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "milan", "milan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("38c6532e-6cac-0242-9b42-c1980448f990"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "norwich", "norwich" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("38df442d-19f2-9942-996a-80d190c21209"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "arnhem", "arnhem" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("392ad8e5-f8b8-9448-9184-9404ee53a959"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mythical animal", "animal fabuleux" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3960f978-b5c9-e84d-b51e-a2409b37a17e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bruges", "bruges" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("396e2f21-6802-4347-9204-6534953f2ddb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pen or brush", "plume ou pinceau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("398aa5d3-c9b7-3e4b-b42c-f5cb537012ef"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hammer", "marteau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("39979287-e681-ef46-a638-c8f0aee368a7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "toulouse", "toulouse" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("39a584e2-ca6e-704b-bde2-46b558be1bf8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kaliningrad", "kaliningrad (anc. konigsberg)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3a09a7a7-95fe-2c4b-9663-673094ec6cb7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "salles-curan", "salles-curan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3a297cf1-8557-e641-a0e7-3deedd40a1a4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chapel hill", "chapel hill" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3a581158-91bb-af4d-8692-11706b2797e2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "glauburg", "glauburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3a849356-6e96-f248-ac3c-15bb5619fdda"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cologne", "cologne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3acb5b1f-c50e-744d-942b-aef43c45d41f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aussig", "aussig" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3ae7120a-8371-104f-ac51-cff161e5f996"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dusseldorf", "dusseldorf" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3af0d924-f1a9-6a46-85f7-a1dcbfc7549d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "marseille", "marseille" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3b10d258-56d2-c34e-9544-fc4564164a2e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "douai", "douai" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3b935984-0638-3a48-bc02-554581fab603"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "szczecin", "szczecin (anc. stettin)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3bbfe104-f3a4-9b41-bd34-b636a7cdaa1e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pithiviers", "pithiviers" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3bccbe5e-3a14-f749-9612-261888f932d3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "keys", "clefs" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3c174878-389d-5445-ad58-a2772b9d7474"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bassano del grappa", "bassano del grappa" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3c501704-e84a-6e48-938d-1fb439f0361f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "date", "date" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3c76005b-5b4e-d14a-a3e1-45b77f797580"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "northgate", "northgate" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3cc5fbd6-5c9e-6f4a-9a6c-34c95997bafc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sundsvall", "sundsvall" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3d3ca710-21f3-f54c-827f-a717f161197a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "jena", "jena" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3d5aa4fa-6eb7-1a4e-a98e-6254e74bc5a5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "plant", "plante" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3e23ba74-c81c-1b43-8590-63125b391ea0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kilkenny", "kilkenny" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3e58d95f-8c65-1c47-b174-45293e45e0fd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "neuchatel", "neuchatel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3f2aaeee-eb4d-504b-afe1-051b8d653a63"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "high beech", "high beech" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3f34a53c-058b-d84b-8bca-20fc387f069f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cambridge", "cambridge" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3f4096f6-4800-4e45-a44a-93034a0ea433"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "middletown", "middletown" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3f8895f2-f29b-c146-bb82-bb5d33b7da5b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dortmund", "dortmund" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3fdf493b-e3be-124a-9d18-a117aca8763d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "swanage", "swanage" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3feea2b0-e57f-6f45-bedd-c8b5cec441aa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "boulogne-billancourt", "boulogne-billancourt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("3ff120de-0ade-584f-ae59-e5083b26c3c2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "antwerp", "anvers" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("40085d7d-d4f1-a443-bd36-745948fd84e8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sevres", "sevres" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4017080a-3036-b645-9e62-40f42fa34a33"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "le cannet", "le cannet" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("403c93c6-b4e0-b74a-9335-d75d4f1c404a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "grasse", "grasse" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("40458f37-1876-344c-83e6-253c62a96a1e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "purley park", "purley park" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("40474ffa-569e-ab41-9ec6-6c96833955d1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "belt", "ceinture" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("408896e8-6905-3e4a-9a11-cf5615759db9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "thirsk", "thirsk" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("40e14824-342e-9e47-bf79-cd5b398b04b8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fitchburg", "fitchburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4126436e-858d-5748-ad12-334acf2c2113"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "villard-sous-blonay", "villard-sous-blonay" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("41330a4e-3ca7-4d41-abf2-fa0e35e30c97"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "naugatuck", "naugatuck" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("41db7527-eb7f-c144-a2cc-b98dc7882098"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brno", "brno (anc. brunn)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("41ea6667-b4f1-e845-b5ba-bb2e7054bb67"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "polygon", "polygone" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("42b14ab9-2533-7943-80b1-bd501056f510"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "humbie", "humbie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("42dab4c7-797d-be4b-ae4a-1c0997fca2a6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "troyes", "troyes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("43288336-b26e-de4e-b0e7-20f86537eb06"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "denver", "denver" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("43a726e2-bc10-3c45-90af-84d72e09a98c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "grendon", "grendon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("43e89db9-913c-0548-afe2-c209cbdb4f43"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "faenza", "faenza" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("43ebf88a-9e97-bd42-8c41-45be83c4a3cd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "marienthal", "marienthal" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("43fb668f-38e7-cd4c-8a00-1253bf318914"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "voronezh", "voronej" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4457515b-66ac-804a-8aeb-9827182f33d6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "san donato", "san donato" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("445d9e40-268e-f44b-98c2-a55af13c99db"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-cyr-en-talmondais", "saint-cyr-en-talmondais" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("44df1036-3ad9-344b-a688-e283a9432315"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "frankfurt am main", "francfort s/le main" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4506f3e5-3f97-434a-b0a0-68d9c7091e85"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "celle", "celle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("457c805f-f913-4e47-8635-66b504fa4df0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bird", "oiseau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("457cdb12-0e60-3c40-b9ba-b4aef284265a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "word (latin alphabet)", "mot (alphabet latin)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("461bb399-4ac5-2445-8864-c0fbe197d9c7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fecamp", "fecamp" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4662dda9-12c5-944d-8408-54f0f240ec1f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "almelo", "almelo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("46e8c237-5f57-a341-8e22-a0ea1a51077f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "villejuif", "villejuif" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("477ca4bd-65f3-864d-8108-d9f8fbed4406"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "heidelberg", "heidelberg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("478d0160-636e-7740-be7f-505eca76830b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tatschen", "tatschen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("48348052-aa3f-264e-afcc-f4f8eb0d21c5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "courbevoie", "courbevoie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("486fd431-39d1-534b-b1ff-2209073fef29"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "morges", "morges" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("487acabf-86b9-c84b-a199-847b64e266fd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cleckheaton", "cleckheaton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("487f0425-ef52-3747-bfca-bd95d01af12c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "neuburg", "neuburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("489bedbe-e24b-0545-8251-b7651da5a333"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "breslau", "breslau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("48f51a20-f4ef-b649-a325-5942a5240313"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ballskelly", "ballskelly" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("49373f9f-8b5b-7c4b-a421-2a23c24f0ba0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "talloires", "talloires" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("49525b62-2e31-ef43-8ff0-91a9a7999483"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "detmold", "detmold" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("49ed264a-6488-2e44-8f5c-09a52ae23b35"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "teddington", "teddington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4a2ec7ba-4241-df4b-87ca-40a8c550c0d5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "barcelona", "barcelone" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4b60fcd4-752d-5647-9242-f378de0306a8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "neuilly-sur-seine", "neuilly-sur-seine" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4b715a50-8682-5643-a090-7eba1cd27f91"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "haarlem", "haarlem" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4bb053eb-478a-7842-9fe1-eb7ae7813c85"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oval", "ovale" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4bceecda-7454-4f45-82bd-1721169cfd82"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "azay-le-rideau", "azay-le-rideau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4c9d67c6-1ca2-eb4b-ad2a-f164c20714ae"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "los angeles", "los angeles" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4d126d4f-9046-274a-80fe-f619cd096b11"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "blerancourt", "blerancourt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4d721af6-f1ce-fa4b-8ce5-06b46f431272"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "blind stamp", "cachet sec" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4dff1977-f039-b04a-b595-ceb4bc33e526"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "herford", "herford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4f14ab6d-635c-ab44-bc03-983b915fc061"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "berlin", "berlin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("4f1ea79f-15b6-0043-8e16-1584cf42e0a0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "udine", "udine" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("504d1a0d-4e45-e14a-9abb-2992ead0598b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "jouy-en-josas", "jouy-en-josas" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("506536c9-2b81-294f-a76d-4584e450bebc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ins", "ins" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5073f543-2114-c540-bb5f-563ad88028dd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "san francisco", "san francisco" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("507b8f7e-051a-0a44-8c34-ff00e8ba0267"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "quedlinburg", "quedlinbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("51221edf-7e65-0e42-bb12-52080203ec46"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lenox", "lenox" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("51cfe50b-938e-8c48-8d63-5f68e18aece8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lisle-sur-tarn", "lisle-sur-tarn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("51fe4d9f-379d-6640-b644-3e3d58feb314"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "groningen", "groningue" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("523415eb-3788-7d41-b1ea-1879f0b21945"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sherborne", "sherborne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5342698a-6946-0049-a5f4-9bf5a46a0874"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "weimar", "weimar" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("553d8108-9344-0542-a2cf-28424311aae8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tablet", "tablette" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("55c49de5-0652-f942-8420-8124364969c8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "container", "recipient" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5603b8e1-ff8a-0941-b717-d46009b5279e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mariental", "mariental" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("560aa432-1333-3641-bb19-afac70f5737b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "the hague", "la haye" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("563656d6-43c8-c547-83bd-c2af68bd567f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aberdeen", "aberdeen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("567793d9-850b-8746-a47e-074559f445be"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "meudon", "meudon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("567eda7c-5ec1-214b-a610-9603824d45fa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "middelburg", "middelburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("56fa65c1-9dd6-354d-b31a-5a4b704b99a0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "worpswede", "worpswede" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("57c808e5-5b16-9448-9058-753af64355a9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "naunhof", "naunhof" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("591b4233-b4f1-1545-9e6f-7d0806b78a15"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "raitzhain", "raitzhain" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5937d9d9-1e14-1d4e-b758-dd642841365a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "washington", "washington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("59e202ab-7f7b-1b4b-9925-a21e2d5924d6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "forli", "forli" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5a027f8f-08f7-f847-beb3-1e7679b34753"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bignor park", "bignor park" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5a59f99e-f041-2a4a-9aa2-a2ff4b59ad5a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "goslar", "goslar" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5aa9f4f1-d93e-f645-a997-5dd00602c2ec"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "southampton", "southampton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5adb43f5-995f-3a4c-a8ae-8ee64118e991"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pont-de-l'arche", "pont-de-l'arche" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5affa48a-541b-b04f-a8d6-9802427ee17e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "trouville", "trouville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5b122c62-ed7d-aa4e-bcd3-ad8e87dd2f19"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nimes", "nimes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5b47f729-88c6-aa4d-9db3-83f23ce242df"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hale", "hale" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5bbc44ff-05cf-244e-8bb4-4663e7e3ecb6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "jerusalem", "jerusalem" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5c111e91-9729-3747-bf74-d6a8dbac0d0d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "beaulieu", "beaulieu" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5c908adc-e155-cb44-8a4c-8b5bf07c9850"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kansas city", "kansas city" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5d0e83e4-2c8a-6945-b66c-79ef088130e4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "winona", "winona" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5d50209a-83ce-a24a-9231-1a2e9e226368"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "schwerin", "schwerin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5d898319-5cbb-fd4e-9079-d182bf71771a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wurzburg", "wurzburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5e19ff1c-7f6f-414d-a516-1e794e99f988"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chars", "chars" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5e253354-5d33-1149-a70b-6f20d8de69e1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wuppertal", "wuppertal" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5e25aecd-633f-6342-9aa7-f02b63eb3aa8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint petersburg", "saint-petersbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5e4d3e84-fa92-6040-9902-1bbf76d72bd7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stand", "presentoir" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5ef731f3-2d06-7541-9c38-3d6a6c90acec"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oettingen", "oettingen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("5f2c40cf-7a2e-6342-a5eb-91dc7795ab63"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "new london", "new london" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("602e4839-053f-7846-8763-918703fa37e7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "detroit", "detroit" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("60c310ff-eb03-934f-88b1-7694f344a178"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "granville", "granville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6195fc15-4a28-8c45-8d0a-83feab5d0263"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "norfolk", "norfolk" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("61a5dfbe-f0e6-3649-b61e-af4394b96e3e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "carlish", "carlish" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("61dcc07a-bd71-7b4d-803c-9bf42f2ad5af"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "frapesle", "frapesle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6221937d-29b0-d940-bd13-c8ef5d40be50"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "caduceus", "caducee" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("625e28d1-d99d-9c46-a0ec-620262c3a3bb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "naples", "naples" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("62dd1faa-691f-644b-becc-22834599e536"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cheltenham", "cheltenham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6320ad9f-5ff1-9240-85ea-79dcf5fee387"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "birmingham", "birmingham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6325280a-fa4d-c143-8d95-ba93a9c5beff"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hampstead", "hampstead" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("63652d33-1c99-7a44-95e2-431988ddd1c7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "burford", "burford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6383cd3a-9ad6-5d4a-9632-665951d306e3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pont-aven", "pont-aven" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("63b66bbe-6167-594b-a96d-36b53fb66d1f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "zurich", "zurich" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("64579277-6db6-6842-8126-95b07c37f54d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "leeds", "leeds" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6499a4c1-e03e-b144-977e-7b37f67e4c92"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "poltalloch", "poltalloch" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("64daf971-8c0e-9749-b4cc-787343d28dc3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "biarritz", "biarritz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6508b51d-75d7-dd45-9a86-fd0619831400"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rifle", "fusil" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6509ef31-c46f-a94c-982d-43a153599a52"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "donaueschingen", "donaueschingen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("65539e92-6c9c-3245-a514-0efa09871e54"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cleveland", "cleveland" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("65b1f923-d544-8847-b7ea-b0edce0a8ae2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "adress", "adresse" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("65d9b98e-4048-df4b-a32f-aeb31e2e9084"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "price", "prix" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("65f61ada-c21c-f441-a359-892ef0daa216"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mainz", "mayence" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6608f0a1-f591-9942-8484-b3ff4ae10828"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gorinchem", "gorinchem" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("664f0ba4-c416-d14b-a8eb-7427bbc981d5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gusborn", "gusborn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("66583681-7ce9-7545-8d79-1a832afadf76"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "philadelphia", "philadelphie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("669496e1-e799-aa48-973b-224ff1042971"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "twickenham", "twickenham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("672159f5-434d-6c4c-9e40-3db7c7803c1e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kassel", "cassel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6728c4e1-a8af-734d-baef-ee814cd062c5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vevey", "vevey" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("68193629-ec86-b14b-b502-d725b4595a32"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "arostjobing", "arostjobing" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("68406a81-2bd2-424a-bc48-866109b86e99"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-denis", "saint-denis" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6958be5c-98b5-0140-b084-5d3d1d31c650"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "florence", "florence" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("697bfb6a-1ce1-834f-9464-0e8a425d21c8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aix-la-chapelle", "aix-la-chapelle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("69cb3946-9adc-9e40-986e-483230e91258"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "langelsheim", "langelsheim" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("69d562b1-70b2-de44-b356-a6cf3c3559bf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "birkenhead", "birkenhead" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("69e10407-4e19-5d4a-8ce2-710f5ba7b72d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fairfax county", "fairfax county" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6aabf284-e4b6-6d46-a880-282f9d18e5fa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bar-le-duc", "bar-le-duc" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6b1ff677-14f0-d84e-915f-3d2017a63e62"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mansfield", "mansfield" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6b843f59-c577-c74f-92d6-6538e1fab8b3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wolfegg", "wolfegg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6bbccf07-5bba-5f48-ba94-04e971a05624"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "leeuwarden", "leeuwarden" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6bda8afe-a6c6-514e-a4af-0b323bfd89f6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ghent", "gand" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6c1b2767-2ec4-a848-820e-879584934823"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "new england", "new england" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6cafba80-ceac-994e-a4b2-638da270ce08"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "beverly hills", "beverly hills" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6d15a4e2-d3b6-984c-a665-e216bc3818b6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pesaro", "pesaro" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6d17ba93-6687-a644-8e7e-70c90c7b5090"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "square", "carre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6d398e46-590c-c645-b6bf-ad02abc962a2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ink", "encre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6dcaea28-8d0d-494e-9daf-4ba2c507c390"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "uzes", "uzes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6ea7f3a1-8637-224b-a78a-fdc2b1c4024c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bedarieux", "bedarieux" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6ecfeb30-b9e0-774d-a2bc-e72776747001"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bushy", "bushy" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6fbbda55-b89e-ef42-b9f9-d94f3db57c6c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lille", "lille" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("6fe735e8-66ee-c44b-acb8-c6660732a14c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "heavitree", "heavitree" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7009c0c0-a43b-2642-8372-d862284e0710"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "soissons", "soissons" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7010f876-7237-0b40-96cd-a746c69a15e0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "banyuls-sur-mer", "banyuls-sur-mer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("70262c61-24e9-c14d-a731-bfcf55379646"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "padua", "padoue" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("709586f1-61a5-3946-bced-9cc21d912e14"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "london", "londres" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7097faff-d523-4b4b-9c3e-18329f153e8c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vienna", "vienne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("70a1fbe0-491b-de46-81ba-b693623e02fb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "barbizon", "barbizon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("70be61a8-ffc8-4b42-937a-987e5a3fffb6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oxford", "oxford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("70e50e3a-deb9-b548-9931-0423e711f20a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "catsfield", "catsfield" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("71390c0b-e51d-eb47-85ef-4295546ad5dc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nordkirchen", "nordkirchen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("71437e48-ab2e-1644-970f-ff926800c87c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "auch", "auch" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7174bfbd-d735-334f-a0e6-7d76fbdf7aa6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dornburg", "dornburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("71d61904-2032-c749-b2ea-6a7ea441f867"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "schweinfurt", "schweinfurt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("72696503-c37c-7d4a-995f-202d37b58eed"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "auteuil", "auteuil" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("72dbfe02-77ee-204a-9dbb-aa15acee3de4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "marburg", "marbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("72e17f61-7e90-3441-95fe-521fcedb1b71"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "paterson", "paterson" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("72e51ace-350d-b643-be0d-dbe7b028b7c9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wurzburg", "wurtzbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("72ffd073-3e52-e14e-853e-c46270e9797b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hat", "chapeau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("730e9a0a-dab6-c74b-890b-05da367eef1d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pencil", "crayon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("732ac822-5b81-b240-94d8-17b0eb0aa1d8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tournai", "tournai" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("74598bb9-3bde-b646-9d14-d22734c9e161"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "klampenborg", "klampenborg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("74902edc-83f5-7c4a-9eb4-facbe537c9a5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "karlsruhe", "karlsruhe" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7495c767-e956-4449-ace3-3cd6c5b4dc0e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bedburg", "bedburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("74fdb24d-07f2-274c-b2ea-0eb40ba40d79"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "heemstede", "heemstede" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("75a1e3fc-c996-2746-877e-ac206c69ed83"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pennyffordd", "pennyffordd" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("75f8f63c-752b-4947-aa85-c1837fef0ff1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ferrara", "ferrare" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("75f9f677-b78b-2343-bab5-9bb30d1c969c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dabrowa gornicza", "dabrowa gornicza" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("76fe0936-a157-694e-a1c7-4060ae1abeff"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "prague", "prague" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("773dbc83-23db-704a-b400-1427e71e8018"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "leicester", "leicester" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("774149c4-09e0-7b44-ba4d-fcfb075e18f6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "putten", "putten" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7790c5a6-83ae-dc41-b7eb-3ebd43d3664b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wokingham", "wokingham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("78341cfd-5f1c-8642-b680-a3ff1a32cebf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "parma", "parme" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("78a9c25a-ad60-f140-96e0-16ba5c868d57"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "word (non latin alphabet)", "mot (alphabet non latin)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("78aa4fc1-9c27-4b4d-a123-baf7f6e21321"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "doelan", "doelan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("78e1c756-7365-384f-a50f-80cf30e79206"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "jerxheim", "jerxheim" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("78ee9aaa-9941-0e43-966c-f77cf7e48da6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "great barton", "great barton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("792ad773-1ebe-3c4b-884d-bcba1207504c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "richmond", "richmond" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("798d74f2-99b0-e54f-b448-27405b2e5982"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dordrecht", "dordrecht" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("79f3aba0-1f59-3040-93b8-73b5afdab2d5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gdansk", "dantzig" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("79f6f081-3c63-704d-8ad6-5d95378fd472"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "penza", "penza" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7a2cd747-cab8-7740-95eb-d75d88fb1587"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "freiburg im breisgau", "fribourg-en-brisgau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7ad63fa8-2bd0-1a47-adaa-9a03a10eb9da"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bad tolz", "bad tolz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7add4516-cc8d-ef46-8a97-d68b157b5667"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bonn", "bonn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7ae06d73-9f75-8841-9d72-236b56ea8f75"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hanover", "hanovre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7b847c9f-08d8-2847-94c6-e6b0de45f793"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "karlovy vary", "karlovy vary (anc. karlsbad)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7bdae586-52bd-d742-9c2f-8072c30606d8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "louviers", "louviers" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7c419110-5ae3-f54c-a17a-bab78e76b5e8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rheinhausen-oestrum", "rheinhausen-oestrum" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7ce74e4e-f190-0942-928d-eb792515788b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "morlanwelz", "morlanweltz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7d63411e-a431-a541-83c5-3b7796e2b157"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aerdenhout", "aerdenhout" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7d96ec62-77e1-d04b-9752-b1cb1b78506f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eye", "oeil" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7da73fc7-4e1d-0548-bee9-7b667f7fd7f3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bordeaux", "bordeaux" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7dabd7c5-45d8-9d4d-a210-8493a912f0f3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "warnford park", "warnford park" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7e83abc2-ab9b-8d47-b1b2-3ff971f737f3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nice", "nice" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7eca01f2-952a-7f47-9a8f-364c5cf3acfe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lurley", "lurley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7ef15b80-67e9-0145-b125-2cfdfdc04fff"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bievres", "bievres" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7f41acf7-4426-904b-8120-4e93dc75d35e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mantua", "mantoue" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7fb7f297-401d-1b41-a066-5fdef62fcc59"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fontainebleau", "fontainebleau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7fe5269a-47c4-2c49-acb7-c4fff7f2273c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hand", "main" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("7fe9e6d3-3ddd-ca4d-ada1-9113298ee3e4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "meopham", "meopham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("807901fa-4aaa-ca4e-9a05-78964a2251db"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rostov", "rostov" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8194ec19-9cc4-7747-992d-6b732364184d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "trieste", "trieste" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("81b2a3c2-2f7f-3549-93ac-134e0f16472a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "melun", "melun" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("81c97740-9dd2-4142-92a1-c236f1033046"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stuttgart", "stuttgart" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("81cd429e-94d0-1b41-a8a3-84e059d8955c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nuremberg", "nuremberg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8239c8b9-3a49-f74d-8d53-dd14ce825ba3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kulla-gunnarstorp", "kulla-gunnarstorp" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("82e058c4-ba5a-2b4c-b307-d3ab607ec131"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fruit", "fruit" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("82e8826d-aa7c-3b40-ae2b-a881235b73f6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-maximin-la-sainte-baume", "saint-maximin-la-sainte-baume" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("83d082d5-d49b-9f48-b1ba-ed2b0756a264"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "insect", "insecte" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("855e00cd-d66d-5d4d-aba8-825f32087378"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "liege", "liege" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("86cf0533-a7aa-934a-8367-df417184f42d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "honfleur", "honfleur" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8739acc0-e27f-fd43-b1e3-efbad36cf704"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "erfurt", "erfurt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("879eaa9b-f7e6-124d-b58d-0c633c758d23"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ayr", "ayr" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("87dfb5bd-551c-e440-8d99-d7657dda666f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "woodbury", "woodbury" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("88705c10-b8a5-c34d-a9da-79d6b4a24e3b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "picton castle", "picton castle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("890f6e1c-c4aa-5f4c-a8db-9ae92f018528"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "montauban", "montauban" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("896f82a3-e221-6549-9943-84adf16dfc21"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ortona", "ortona" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("89e660fb-419d-454e-8f15-b93b7fac7c7d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chislehurst", "chislehurst" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8a1961ba-b6ab-3948-8f74-a325abf0f9f1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "shell", "coquille" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8b313226-caba-424e-9176-99431f2b035d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cobham", "cobham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8b71fe33-dc66-c941-a71c-28e8d9600edf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bergues", "bergues" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8b7797bf-cee5-b749-9831-62fc33df48f8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "banbury", "banbury" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8bb52514-42f1-3640-94d7-5dfe0eb37bb0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sanssouci", "sanssouci" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8c024657-7877-d242-89e2-22ce48478fc1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "poncins", "poncins" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8c0d3621-858b-7246-b7d1-e13b918bf2fa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "amsterdam", "amsterdam" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8c1c85a0-d126-6c4b-abf6-ee73586b9833"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "springfield", "springfield" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8c7c0de7-d284-314c-8b6b-f97b73c18d81"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cincinnati", "cincinnati" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8cc8b63a-d865-4a4a-99aa-4e2b6dd9cb5c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "de meern", "de meern" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8d2f50ff-ee2b-794e-babe-7f9d4a451b01"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "compton hall", "compton hall" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8deb1cc6-3fe3-fd45-b5fd-8ae8dfe5cd7b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ear", "oreille" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8e11ad17-dba1-8a4e-abc8-cdc6009cb40a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "davos", "davos" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8e7d22d4-2ffa-e947-91c7-67e93a5a41b8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ealing grove", "ealing grove" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8f2ddc8c-fd20-8849-a58c-cce4b799f8b2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fish", "poisson" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8f4076bc-b920-6542-850d-147c542755cd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "erlangen", "erlangen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("8f64cef0-3a12-d247-9d5b-1b413342880e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "delft", "delft" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("903f17c9-c775-a741-8e18-d4034522b645"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ozarow", "ozarow" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("90a03300-e6dd-4041-9960-3a15bd3b7767"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bratislava", "bratislava (anc. presbourg)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("90aa347d-dff1-ed4d-b476-a97322b7854d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "clermont-l'herault", "clermont-l'herault" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("910c82f1-038c-6841-800c-86d7effe9a67"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bryn y gwin", "bryn y gwin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("91789378-1d89-4e4d-8241-2f0b7cc76e0d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "alresford", "alresford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("91a7105b-19cd-6641-9e5b-e6410c2d5fdd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "giverny", "giverny" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("91b3e62f-8dbf-b340-b7c4-ece885c552ff"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "borodino", "borodino" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("91d66f2f-e057-f342-af02-00128e75950e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dieppe", "dieppe" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("91f01004-7c16-f74f-b896-d978e76e84ba"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "compass", "compas" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9244d52f-fc57-8940-8309-ff78715147dd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vreeland", "vreeland" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("92bba411-1634-a143-a557-4f7631559c40"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "flower", "fleur" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("93009e89-ff9c-4445-bbc2-874b319db191"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "newark", "newark" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9322810e-3953-6c48-853f-8eaa031b1b1b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "goluchow", "goluchow" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("934fc362-bbc4-b449-91c9-f7e4d7571d20"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "boldre", "boldre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("942cbd7f-b283-ce48-8dcf-44aa1be4d2a4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cartouche", "cartouche" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("943c8167-42c8-a048-8f63-b8af349be4d6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "volary", "volary" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("948e486c-2daa-6849-b889-5cb0bdf20000"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "guildford", "guildford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9497b519-0fe2-db42-92fc-20ca489ba5b8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brunswick", "brunswick" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("949c4e19-c1ac-b942-af8e-71d20d4671f4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ethie castle", "ethie castle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("95349a5d-6dbc-e548-9809-eb061a85acb5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "map", "carte" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9548d53a-c053-3a42-80e7-71201c95c5a6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-omer", "saint-omer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("95d1d2f9-d203-354b-8c7c-af62ec3a9900"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bilthoven", "bilthoven" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("96158fb0-a547-4945-bfaa-a32fd219f6cf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lorient", "lorient" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("964f9cf7-6446-b941-8bd8-6be2af043025"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "knowbury", "knowbury" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9655e122-828d-484a-8891-fce67c51e49d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vaduz", "vaduz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("967ae8a6-b737-b74b-8a44-73a2f92516be"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lugano", "lugano" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("96a895cf-fc9b-2a49-9fa6-980860784665"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "settrington", "settrington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("971d3f0c-d972-7042-a8f8-6d3b8c3bfd41"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-tropez", "saint-tropez" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("97395848-1128-d245-86ed-4254414ad4c9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chamerolles", "chamerolles" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("97d8eed8-73f8-7a47-8f93-08b6d2a48420"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "menton", "menton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("986b2409-b68c-5a44-bc03-f22bb30eb1ae"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "greiz", "greiz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9881aa6f-2128-1249-89a4-a0001114ea56"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "altena", "altena" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("98bf14b5-e3aa-2e4a-abbe-38a57e66c1dd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint louis", "saint louis" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9956ec7a-d560-fa4d-9293-36166a14efaf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cureglia", "cureglia" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9995727d-916c-1242-a3a3-b64620fce6c3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "triangle", "triangle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("99d9b9cd-195c-7545-938d-afa36a69d29c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "miami", "miami" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9a195598-2cae-0a46-ad03-22e34cf97d4a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fonthill", "fonthill" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9a43190a-80eb-1e43-904f-3ea928df833f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "st. gallen", "saint-gall" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9a7d930e-d869-ad47-8bd7-aa94d9e14e98"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "angers", "angers" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9ade9609-3573-714d-a833-589e9f1212d5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "melbourne", "melbourne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9bb7de6c-fd9e-7b4b-9351-8e5d04240499"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "san marino", "san marino" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9bb863a7-ee2b-df46-ab54-3356c5788a56"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "moulins", "moulins" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9bd5f757-59ce-9247-81be-be063c195499"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "paris", "paris" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9c2cb6ee-3f3e-a84c-a1fe-32a580cea1cd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bristol", "bristol" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9c6a6e7d-2a27-0f4c-a525-584e0393718c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "casalpusterlengo", "casalpusterlengo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9d2c6b93-106b-1045-ae67-03a68c60ea3f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "arras", "arras" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9d31f722-bfda-3f42-a096-5e7de46daa9a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "new orleans", "nouvelle-orleans" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9d74c225-68de-1344-b55f-16d5fb81caea"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "le blanc", "le blanc" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9d88e49d-5501-fc48-b718-ce651ef666e6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brussels", "bruxelles" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9ea5993e-8033-244b-9c5b-9f9a15ce656c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dayton", "dayton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9ea6b158-eb4e-9641-9383-aba25d1a367f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rennes", "rennes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9eb2689e-ec16-844f-bf6c-41f1b8bbb24c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "andria", "andria" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9f05387a-358d-d441-b738-49ae9b9dc4a0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "budapest", "budapest" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9f05da18-834e-6946-b837-dca8ef69cb4e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pustyn", "pustyn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9f5196b3-154a-bf40-a1e3-6b8be1864d70"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "westonbirt", "westonbirt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9f7ff40e-8790-a14d-9d6d-763db0b8e41b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "charleville", "charleville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("9fbca522-253a-5b4b-8dd6-91077b76a705"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "princeton", "princeton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a06d7bbe-95f6-bf43-97d0-3abe4e07b1aa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "totnes", "totnes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a0bebd95-cf6c-f74c-8d2a-fe962c3258fd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-marcel", "saint-marcel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a0da24f2-e880-b748-ac70-231604932efe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sledmere", "sledmere" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a13a63e8-509d-e14b-9f88-24c4df7375b5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "honolulu", "honolulu" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a1413948-e7a4-364f-9438-8c405c965d14"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "norrkoping", "norrkoping" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a15e4e71-3f28-af43-ac6d-67b9ca2cd41c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "senlis", "senlis" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a1648d79-bcec-434f-99c8-e042dfb8216c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gloucester", "gloucester" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a178bc55-839f-c748-b22d-8ec88c90a609"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bressuire", "bressuire" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a1aae9a3-ad9f-a04e-8fef-8dacad815f80"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lerici", "lerici" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a1f33be4-af5e-b640-87d5-8546b847cbcc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "salford", "salford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a2566a64-33ec-4b4d-9acd-a095cf509ca8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "clamecy", "clamecy" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a26ba3bf-d96d-4e4d-ba55-bbcc1d53d755"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aussig", "aussig" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a2c00ff9-47c4-d444-bca8-97112e5e2502"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wilton", "wilton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a2de9a47-d16d-bc4f-9721-8d77f06d94d4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "champaissant", "champaissant" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a2f6ae0f-5333-a44f-9f43-f36ecf941b81"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mendel", "mendel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a3a84465-bd75-9348-9670-fc48fcadb063"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bologna", "bologne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a3c90ef6-7bc5-254f-9dd0-d083e5165492"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ville d'avray", "ville d'avray" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a461f51c-d3c2-d747-8413-0131bd310954"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dessau", "dessau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a478cee8-7bef-d240-992a-9e1ad6afa7f8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nantes", "nantes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a480829e-6ebb-8641-81de-152c3e30e75f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bamberg", "bamberg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a4fc7c15-adb2-8b48-96b2-7bccdf53b56a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gothenburg", "goteborg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a5381b17-ade1-2947-9fc7-767e385226c0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "prepych", "prepych" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a53d7d8d-284b-4344-9a09-ac4ec09110f9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "utrecht", "utrecht" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a608bdfa-d4c2-8642-a92e-f11c7267c02e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ennis", "ennis" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a6ae67a1-06f0-e648-8668-867fb82528bf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "graz", "graz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a6c39977-ac7b-2541-b256-5c9259ee97a4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wimbledon", "wimbledon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a7927ced-6983-db45-bfca-4e2bc2ffc6f9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brookline", "brookline" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a79822ff-5f07-ae4e-95ef-dba609660692"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "frankfurt an der oder", "francfort s/l'oder" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a815fb21-861a-2340-b890-3f8acec32a14"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "goscieszyn", "goscieszyn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a8694cf9-28a2-0347-9d95-f631296c0e93"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "alencon", "alencon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a8c4a4bf-59bb-f24a-84b4-df131e022199"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "stockholm", "stockholm" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a939153d-1867-ff43-a7c3-9e0a5b42e614"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "worthing", "worthing" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a948ab74-b803-c84d-a966-8add2836f498"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rhomb", "losange" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a948e0a0-0b00-1f43-a35f-4ce7400e4ee7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tornow", "tornow" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a9d539a7-3f2d-8b43-8216-708f6643881d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vaassen", "vaassen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a9ea8f01-b2b2-214a-97e7-54ae7d4b9f98"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "krefeld", "crefeld" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a9f2023c-d4b4-e944-8f19-5c716bbc9997"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lucay-le-male", "lucay-le-male" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a9f7e2e9-bbfd-664e-bbbb-7eba9362b16b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "amersham", "amersham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("a9f9c217-3b44-3d40-8e5b-3b0212333af3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "moon", "lune" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aa53462b-b084-734c-ba51-04d7d4629598"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "grenoble", "grenoble" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aa5578d0-2401-bb42-8cf2-fb823459cb48"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "klingenmunster", "klingenmunster" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aa59f14f-01e0-4146-8993-791d147b1214"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tokyo", "tokyo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aab26cd6-85e3-cc4e-902f-4c0ae4fac20e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "waterbury", "waterbury" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aacaca27-88bd-9b48-8379-c60129ec8275"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "warrington", "warrington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aad7c6d9-3477-6948-9ade-fac294fa1fac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brixlegg", "brixlegg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aaf7a792-8f50-6741-bd78-05bf42e44386"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chicago", "chicago" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("abad0a18-5724-2e4f-a0fd-1071989e6e9d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "foxley", "foxley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("abda5e2e-f7c2-8641-ba75-0bca0a573dce"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oldenburg", "oldenbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ac23be9c-05a2-9941-81c1-15d541e572fe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "racket", "raquette" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ac2bd1c5-db65-2d4c-8044-2770dae18448"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "plombieres-les-bains", "plombieres-les-bains" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ac502523-c90f-ed42-bda0-3c7810a6aaab"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "metz", "metz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ac622e5f-fe56-5a4a-88cc-ef2375742e3c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "le havre", "le havre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ad1012f6-786f-4046-ab73-5b3bf3c8f1f2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "falmouth", "falmouth" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ade7c7b9-9d80-6b40-891f-6ccd6e192384"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "new york", "new york" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ae124d63-6a90-624a-8ff2-6bcd768fed82"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kassel", "kassel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ae1c3bd6-463e-0f47-9561-a763195aa134"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brzeg", "brzeg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aeb27361-2b26-7f44-a059-77371a593275"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-briac", "saint-briac" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("aed19bed-f7af-6341-95f7-de5c360928c3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "luneville", "luneville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("af5de8bf-3a16-774e-80f3-762ac3bfc5d3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "raigern", "raigern" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("af9057cc-333c-5045-8858-3f20e4174bc8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "turin", "turin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("af9f6339-4d0e-bf4a-8db7-8680d1540054"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dohna", "dohna" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("afb581e1-f703-494d-9277-489054fdcac0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "palm beach", "palm beach" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("afc94125-b379-094e-81d1-8c8ddbe8257d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ennis", "ennis" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b020ea59-6a59-ec4d-bd35-8ca93925ca7e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "palmer's green", "palmer's green" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b036bf57-c7c2-8a44-ab1a-9b068fb3f0a7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "portinscale", "portinscale" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b05d1cfa-a59b-b743-b906-e17f46ebfd6a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "la frette-sur-seine", "la frette-sur-seine" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b0aca196-57a6-954c-8931-01bb3920a8d9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "newcastle upon tyne", "newcastle upon tyne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b0c9c1d9-ce7b-b94e-8285-426ed368ab9a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "baranowicz", "baranowicz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b0fdd12a-d9f1-864f-8a0d-49ad5dfe157f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "clinton", "clinton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b13422f1-b758-1147-98e7-6468b39e892d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sevenoaks", "sevenoaks" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b1867ca7-0261-3444-bcc0-38784e8459bf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eastbourne", "eastbourne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b1bd42eb-c119-3945-afb6-314cb27eb753"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "constance", "constance" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b1fc4a52-d1d6-f245-a419-ac49992de1ab"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "genoa", "genes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b202196e-bf5b-a842-922e-ba1eab7d4120"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "compiegne", "compiegne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b2322cb2-11f7-604d-91d5-ac60aecd3ac0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nunnington", "nunnington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b324f470-7d0f-cb4f-bf36-2c61bcd1f90f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nogent-sur-marne", "nogent-sur-marne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b33106c2-0f86-414a-96b0-4fc314cbe202"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "borkel & schaft", "borkel & schaft" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b351c432-6dff-4441-825e-5263b9e496a3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chesham", "chesham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b5a5be88-991e-a744-94e8-65403c96d77d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "albi", "albi" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b5f239dd-3344-de4a-a843-79028a748d52"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wilmington", "wilmington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b6556807-cd78-6247-a5e3-0766e8bf8cc8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bellesme", "bellesme" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b67018e7-012e-5e4b-8705-8106a14506e6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "odessa", "odessa" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b6a8e064-53f5-0849-a2b8-a266cb6e9b40"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cambridge", "cambridge" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b6d64f69-7929-6145-a2e3-e0b57fbbc0c2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mannheim", "mannheim" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b707ce78-3580-bf45-bdd2-7355037e0ffe"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "commercy", "commercy" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b791fd55-4514-924c-958c-cc0edb71efca"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cross", "croix" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b7f42a65-8c1e-094d-84d6-f3c0682f816d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "number", "numero" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b8a648d7-6e3c-1444-81e9-7e6fc2ed376d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "charenton", "charenton" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b8b96323-cbd3-ad41-8c21-26ffcb2264fb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "toronto", "toronto" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b939a52f-b043-024f-baa3-37d5ccb60734"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "baden-baden", "baden-baden" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("b9f665d4-b5c8-8a48-bb6b-8eedf4f65862"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "caen", "caen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ba6f1329-7b10-8647-b1b3-be344e895df1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "san diego", "san diego" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("badfa5a7-226b-324d-a8ac-c0d078a5ec53"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "warwick", "warwick" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("baf4049a-2184-6e47-ab14-ae3c80a919e4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "milicz", "militsch" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bb0e68aa-2e35-7541-8eb5-2a47a4feb767"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "warsaw", "varsovie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bb9b9aa0-93c4-6b49-9127-a86414ace62e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tours", "tours" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bc1bac4b-c522-e24f-973b-45e6f9a2e4ae"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "watertown", "watertown" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bc506565-3ec1-2a43-998f-55a0898249c0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "louvain-la-neuve", "louvain-la-neuve" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bccbcf0c-8434-c540-beff-eac2afdf22f9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "shiplake", "shiplake" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bcef6d89-3492-ed4f-b1ea-8edc2421b401"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cuckfield", "cuckfield" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bcff4e80-a63d-8540-ad34-548a4c026ac8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tree", "arbre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bd9fe2a8-6e78-084b-a063-3a4bef45b79a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ravenna", "ravenne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bdad28c6-a028-cd4c-a8d1-ed0d87d767fb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bradford", "bradford" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("be620b53-3cc4-be47-8b40-0de34fd550e4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gelsenkirchen", "gelsenkirchen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("be673e28-0dd6-844a-a159-acd1d59f31d0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mainz", "mainz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("be7afbec-168f-5448-b705-9aba87d89abd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "recklinghausen", "recklinghausen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bedafad9-6205-f94a-ad0a-2f9e2a16a23d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "potterne manor", "potterne manor" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bf7f9f15-7850-e645-8bc6-1bdfd5c30fe2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "regensburg", "ratisbonne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("bff9ed8e-276b-f045-bd08-eae324b847f2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wiesbaden", "wiesbaden" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c0545c27-f6d8-7048-a511-f22439d9f5e2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pavia", "pavie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c0d49fe7-5a07-3049-8609-966a55c17fc2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "basel", "bale" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c0e914d9-19f2-d447-a6b8-7b30afed5ecf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "windsor", "windsor" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c103cc80-33f8-9646-a605-27ab4acff9b7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mee-sur-seine", "mee-sur-seine" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c16a3e60-e67a-6544-a306-c50424dbbbbd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "salisbury", "salisbury" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c190f1d8-43d1-0446-99cf-9ee11ed1c755"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brescia", "brescia" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c19b14be-ff8f-f944-9528-d2af4f6349e7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "badger", "badger" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c1f8b52e-b74b-794f-ad5f-1bacd03762a0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "poncey-sur-l'ignon", "poncey-sur-l'ignon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c2150eb5-c015-e048-a55b-01f88440c9b9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gera", "gera" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c2223fe7-3723-9d48-856b-1e85edc41097"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bridgwater", "bridgwater" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c23a9963-19e2-9f49-85a0-86e450429542"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "namur", "namur" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c25faf0d-2c01-834f-8c9c-406498ad532a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "escutcheon", "ecu" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c2f673a1-de80-ad43-a4e3-c8d94d5f7510"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "etretat", "etretat" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c317e97b-9a56-9e41-8847-406757bb53a1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "carbonne", "carbonne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c32eb23a-e517-184c-a33c-956dceadf474"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aix-en-provence", "aix-en-provence" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c3837834-5047-a04c-b35b-fbbcec878796"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "moscow", "moscou" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c3ac4016-b8e8-3d49-822a-6154511d9c0a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "short hills", "short hills" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c3b49164-6017-ec4e-a778-6915f730beb6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rockport", "rockport" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c3d266fe-1ba8-584f-aa1b-c9805ed46864"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "marly-le-roi", "marly-le-roi" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c426f11b-47bb-0d48-ad3d-4980d2108a1f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vincennes", "vincennes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c4413348-0e35-ee46-8b0d-9eb0eae04a67"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wykeham abbey", "wykeham abbey" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c44a073a-933f-874b-933d-938f54cde1bf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ellwood city", "ellwood city" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c47b1ea4-5058-d944-86cd-e598081e23cb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "heart", "coeur" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c6228884-c902-2c4a-b1ee-fed3541b9125"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "morestel", "morestel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c69566e2-c2fe-0342-b115-d0cf5b2935bf"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "versailles", "versailles" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c72f2cdf-1a62-8549-a4d3-898befcd3637"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "armour", "armure" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c75e1350-3331-f945-9466-a6b18a7d813c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "linz", "linz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c794cf5a-6251-8446-b410-9e8201ad2b10"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "glynde place", "glynde place" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c7ec7c5e-a6c5-8e46-9506-6dae0e94e2e5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vorges", "vorges" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c83e3a32-7134-6f43-bbde-a02ea3705084"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cannes", "cannes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c8996a42-8c8b-1541-b6f6-1fe87cd81381"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rome", "rome" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c8d78226-4fe5-ea45-8098-9b7e9a3e97fa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lindau", "lindau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c8eef786-9a96-914f-ad15-854c1844d8ce"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mulhouse", "mulhouse" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c9347309-c0cc-fa44-b6cf-738bb240bf04"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "valleraugue", "valleraugue" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c95de49b-39b6-a747-ad1d-c0e1d5ff8eda"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tongeren", "tongres" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c9bca039-2be9-c74b-9781-91d337ca4340"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "uppsala", "uppsala" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("c9ea0dc2-8140-5848-a74d-f659c21c1d82"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "l'isle-adam", "l'isle-adam" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ca22f2ea-74b3-0340-88ee-2bb03e6fd03c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ditchling", "ditchling" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ca5fc4c0-a0bb-5446-a87a-63543f6fa478"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hinxworth", "hinxworth" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ca6bd088-83e2-8945-94eb-eeb4714abf7a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "inverness", "inverness" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ca900245-5f0d-cd4f-8f34-1068683616ae"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "zolkiewka", "zolkiewka" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("caa3741d-de0d-c642-92a7-004a2e6dd12c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chene-bougeries", "chene-bougeries" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cabc48cb-a25d-a848-8060-cf62d4cf0887"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "boot", "botte" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cba47efe-0f00-f94a-bab6-6e6d34306e64"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "beziers", "beziers" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cc027648-4c47-2d42-890c-752edc3ac5bc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "katwijk", "katwijk" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cc82f357-4320-7e4e-9a6a-3273628d612b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "santa maria maggiore", "santa maria maggiore" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cc898eed-d671-d74c-b176-61490a21ef41"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "albstadt", "albstadt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cd4d3610-bd6b-ab42-8c44-13433dc78e14"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "darmstadt", "darmstadt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cd6d4eb5-80fc-ed4b-8bf1-665a5516a78e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ship", "bateau" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cd8cf761-bb42-2040-866e-09b16f223f6e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bourg-en-bresse", "bourg-en-bresse" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cdb16383-dd32-e347-ac06-1962b104e24e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hilversum", "hilversum" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ce1c09af-851d-e74a-acf8-c026eb42be8a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ornans", "ornans" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ce243569-76ed-f244-af69-68becd457eee"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "finchley", "finchley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ce430648-8101-a147-9689-b9a350826c64"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "sutton courtenay", "sutton courtenay" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ce483cd4-c97d-f048-a672-09a51700f02d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chantilly", "chantilly" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ce4ac310-625b-3848-858c-51b9340f0c0b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "unna", "unna" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ce99bd5f-1a72-eb47-8510-3685f4338424"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "truro", "truro" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cebd433f-0c9f-3a4d-9d4d-647fd008ea92"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ascona", "ascona" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cef3827b-b164-7049-b41d-41c8147615b7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "maubeuge", "maubeuge" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cf1a3763-1e60-4d4e-9f7f-7ebcb9117e0c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "warfield", "warfield" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cf1dc293-20d2-5144-9937-2a37e558f706"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "southampton (n.y.)", "southampton (n.y.)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("cf980d00-b0ca-444d-99a0-d805fbf0e4c6"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "valenciennes", "valenciennes" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d001de88-a411-0b4b-98c2-af971a6793a3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "varengeville-sur-mer", "varengeville-sur-mer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d0508800-f2c4-c24d-9512-a5361acc6279"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "schleiz", "schleiz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d055dd47-ed53-e749-9b99-c8971fcfe986"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "crailo", "crailo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d0bdd7ed-53e3-4a48-94d1-5dd4bacfa281"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "winchester", "winchester" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d0ee7e7b-4b4a-1248-9d08-54966d1efc56"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "initial (non latin alphabet)", "initiale (alphabet non latin)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d16c0217-222e-f645-86f2-f2b58eccdec7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hagen", "hagen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d1e7d789-ee83-2c4d-b9f4-8c46b099eb63"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bremen", "breme" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d25be29f-f692-1e43-aea8-299184d3842e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bushey", "bushey" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d266e7c9-3754-eb46-b0c5-1a7c339b0c07"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kalisz", "kalisz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d2b892b1-98df-2f45-a3f1-9f6be5282f4b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "brooklyn", "brooklyn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d369f4cd-90da-c246-a4c7-157a716589d9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "northwick park", "northwick park" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d3c9445e-7fef-f04e-9fda-d1342102fb23"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "crans-sur-sierre", "crans-sur-sierre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d3d2780d-3cd2-2640-a2f8-c037aeff23f3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "clapham rise", "clapham rise" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d4415ef0-c0d9-4341-90bc-85683987507a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "cherbourg", "cherbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d4682de2-a40c-1043-a6ac-d0202a0aa9c5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wigan", "wigan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d4810029-bba1-9943-948d-60f9b60c641c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "warmond", "warmond" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d49a666d-759a-c249-b579-3ade6268ada5"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "urbania", "urbania" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d4aa5608-2cd0-e243-8655-7250b713d72f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "roosendaal", "roosendaal" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d4e3e1c4-072f-c646-9594-e8df33080034"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "reptile", "reptile" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d4fb526c-70c3-7f4e-b351-f3f0646c7568"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "veyras", "veyras" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d514e3aa-80a7-6a4b-9ba9-41c6ac0750c0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wassenaar", "wassenaar" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d53f8fc3-436e-7449-9253-7f5176a55a11"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hove", "hove" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d5984c32-bf73-6d40-9084-f2d64024dd6a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "goldbach-kussnacht", "goldbach-kussnacht" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d59e878c-0f28-1f4c-9531-2c121e906726"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "schleissheim", "schleissheim" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d5e0ca85-6617-254f-a35b-421d1d662af1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "usman", "usman" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d60b5104-3f42-eb4a-9fe1-fa8dadc9eba1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ellenville", "ellenville" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d60faaed-e032-a849-8500-8e51bf4d3c40"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eskilstuna", "eskilstuna" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d6b0e5ce-7eb6-454a-9716-70dd8630d156"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "reggio emilia", "reggio d'emilie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d6b2db58-6e53-4b44-811a-1fd57715a7ac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "amiens", "amiens" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d7937ce5-4a0e-4f49-b609-3a186e3e2f56"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "swansea", "swansea" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d7ae399f-8c1c-1a4c-82c8-36b3e21a4cce"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wax stamp", "cachet de cire" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d7f7ab47-81a3-b741-b05f-73b6a6180e06"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nottingham", "nottingham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d842992a-1052-bf4f-b3b2-0f4a535ec038"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "providence", "providence" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d888344d-dc62-e847-92b6-0614f8066e76"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aschaffenburg", "aschaffenburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d8aaef46-d37e-db47-96d8-3b1dc0612dbd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "boston", "boston" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d90bf99e-1619-cc4e-8cdb-c97f90acbf1c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "palet", "palette" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d91e8d63-c24f-c647-b5d3-18a197822973"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-etienne", "saint-etienne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d96d16a1-d61f-9c49-ba04-b2ca55eaa06e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nijmegen", "nimegue" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d988729c-59ca-1948-bdb1-aa33d6cecfec"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "romorantin", "romorantin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d9963420-ba80-f24f-8da3-c40a96cbfbe1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rouen", "rouen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("d9d210c7-980e-224f-a60a-8008a6e8ed70"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "maihingen", "maihingen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("da746c90-475e-8544-babc-26b5f59e056a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bodegraven", "bodegraven" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("da84af1f-b504-a648-90a2-c5b47bb85b3c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rowfant", "rowfant" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dac0c43c-ddb6-b545-be93-722adc06a2e4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "unidentified object or sign", "objet ou signe indetermine" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dad5cfef-55f6-7a43-be8d-2bca98c74d7a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lodz", "lodz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("db808fcc-8742-4e4d-8877-351b4c14775d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "montpellier", "montpellier" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dba02a1c-b120-4e4a-8de0-d3368eda69ac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "aalen-fachsenfeld", "aalen-fachsenfeld" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dc06e0fc-b3d1-804c-8480-f901f0e9bb0c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eltham", "eltham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dd0b7a5d-7d85-6e4c-bd30-35f32835ff31"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "san sebastian", "saint-sebastien" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dd588ba4-7eff-4942-bb9a-a68499c70dfa"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vilnius", "vilnius" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("dd8f0fc9-18dd-9c42-96ff-49e544b80e43"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "newport", "newport" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("de0093f2-01fb-ba41-8dff-e835b7f53920"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "carcassonne", "carcassonne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("de1efb73-c39b-5e40-85c9-a10f26491861"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "limoges", "limoges" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("df1906de-cbd2-da4a-9c35-dc41234f6356"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "zamosc", "zamosc" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("df703c55-7746-104d-8e08-01c9998ce611"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mount clare", "mount clare" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e01bc4ef-9d80-7042-8f1f-7a893b2ab2ea"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hampton hill", "hampton hill" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e0859853-b316-e84a-84cd-259bc93b8594"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lubeck", "lubeck" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e0f15e6f-0882-064b-b902-be5571ea915c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "auvers-sur-oise", "auvers-sur-oise" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e168649b-4c2d-ff43-ac72-fc8ef7054685"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bayreuth", "bayreuth" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e181d954-a31b-554a-9be2-282967db5611"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "star or sun", "etoile ou soleil" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e19d448f-f9a7-c549-9f3a-15c7ab1734a4"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bromley", "bromley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e250a82c-6421-5842-991f-b268643318a9"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "augsburg", "augsbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e271f26c-80be-f843-838b-56a8c4c2ff3b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hill top", "hill top" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e28bab8a-992e-f348-886b-6bcce382d66a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dalkeith", "dalkeith" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e30da585-19d1-094c-a3ce-4ee8000ef38c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tubingen", "tubingen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e33f0658-598e-6e44-8682-b3f0a6b27adb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rochefort-sur-mer", "rochefort-sur-mer" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e39baf79-674d-8b47-bd9d-25d0cc26e86b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mystic", "mystic" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e3f9ef9d-1a94-7046-ac36-95c979407143"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rapperswil", "rapperswil" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e43d6779-2d41-4c41-8130-3836ef616e6c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "colmar", "colmar" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e44765ad-b056-2043-9176-b1f18af8e52b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ongar", "ongar" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e5537b95-0239-344f-b54f-85647f1dd9cb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "alkrington", "alkrington" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e5ad5b9c-4ffa-564b-8844-b7b3f911972b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "delgany", "delgany" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e618a8d1-a933-3c45-83c0-2b06fd4e76e2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "new hope", "new hope" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6321616-e374-304b-8821-a55d2e4c5874"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "merchantville (new jersey)", "merchantville (new jersey)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6afad17-d7ef-154d-8970-ca9d9b4cc470"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "vanves", "vanves" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6c9b6af-c673-d94d-9533-0f7dbc7c0fd8"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "initial (latin alphabet)", "initiale (alphabet latin)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6e543d5-1e47-9446-83a5-0f9a034bf88c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mount", "montage" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6ee111e-43cf-db4f-8fe4-5e1526c6ffd2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "blaricum", "blaricum" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6ee3f34-fe6a-a34e-9d6d-45c4854d6928"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "lutzschena", "lutzschena" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e6fa02c8-a574-6b4f-8ae6-8dc5141e7159"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "clery-saint-andre", "clery-saint-andre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e73b80aa-fbf8-d440-a1b1-cac1e5ba4337"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "great waltham", "great waltham" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e74b1677-7669-6347-832b-fc0eefc0aedd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chemnitz", "chemnitz" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e74cda5f-8392-5c41-9f83-805395bf81fd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "buenos aires", "buenos-aires" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e7636df4-f328-f34e-965f-1ff0f7692cee"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "crown", "couronne" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e7866c03-02b8-3e49-8664-3587d7778825"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "perchtoldsdorf", "perchtoldsdorf" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e7ec195b-034a-324f-9d3e-32dfb6092b33"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "epernay", "epernay" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("e86caf41-4d67-3c43-8c7e-ea9d373bc434"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "whalley", "whalley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ea1321ae-b355-9e45-8616-7e5cb2bff4fb"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saratoga springs", "saratoga springs" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ea5af7f5-430d-3547-8d68-6b4304f6c776"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hitchin", "hitchin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ea608d86-97a6-c149-abcf-50db5236040e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "houston", "houston" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ea6ae6be-ed83-a542-9cc7-9a247abe9232"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "verviers", "verviers" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ea93d741-0c9f-6443-ae5a-734763f0edee"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oswego", "oswego" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("eab65eef-c236-6748-a303-12ea9a829ade"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chauvigny", "chauvigny" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("eb013247-d866-fd47-baa1-5135a0c4b979"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ripley", "ripley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("eb7db324-99a4-0c42-b18f-06034968114b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chur", "coire" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("eb94ed8d-3c4a-f648-b0e5-544bd585b50e"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "althorp", "althorp" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ebcf3a86-ceca-2e4c-9f51-71fbc9fe1d85"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "charlottenburg", "charlottenburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ec6871aa-6e54-5c44-bbdb-5fc34897b6db"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "krakow", "cracovie" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("edb58eb0-558c-3747-aa37-3fd0260661fc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rectangle", "rectangle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ede08e29-94f3-2b44-a121-69d09190f4be"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "enghien", "enghien" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("edffaf50-10f8-944a-8f82-40d1901c60cd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eisenstadt", "eisenstadt" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ee10e897-5be7-1c4e-a016-e676454583be"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hive", "ruche" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ee26541d-95d6-9d42-a023-b557128b058c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "oslo", "oslo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ee26e916-4eee-6a47-9496-fcdc9cc93c06"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "leeds", "leeds" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ee2a0856-ebeb-334b-ac4d-943c0f695cfd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-paul-de-vence", "saint-paul-de-vence" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("eecc72ea-817a-4544-885a-2072eb9a0c83"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "essen", "essen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("eed3cfdd-ea30-5247-9bcf-084fd8e465cc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hillegom", "hillegom" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ef1d6022-fe2d-f145-82de-f007628e4706"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ink", "encre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ef8d3ccf-6de1-ba41-9f4c-31fa235d90c0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hannoversch munden", "hannoversch munden" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ef934880-22b1-f241-a6bd-ded5017c7add"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kiel", "kiel" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("efbc717c-1360-2c46-a978-deda4abea6a1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "butterwick", "butterwick" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f0203ffd-fc20-a04b-b1e5-fe5b64475704"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "eberswalde", "eberswalde" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f07080fa-2497-eb4f-8b10-7c2162ccdaef"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "tartu (formerly dorpat)", "tartu (anc. dorpat)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f076ef66-5f6a-c349-a2e4-b1a9e045c1c3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "meiningen", "meiningen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f13dd628-4b62-db4e-aca6-98a4d13fccfc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "morpeth", "morpeth" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f285b519-379d-284d-9a19-441a30f2c23a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "breda", "breda" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f2ac93b7-c90b-c941-9211-4e0124733e19"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "perpignan", "perpignan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f2d583bf-a037-b44e-b1a9-56107a45f0a1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "becon-les-bruyeres", "becon-les-bruyeres" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f34529fb-a9b1-074b-b1ba-77e845350731"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "allesley", "allesley" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f3729962-6122-7243-aaaf-d5f75b7b34ff"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "poznan", "poznan" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f3e784d0-e1c1-0e4a-856b-d534f89c31bd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "rotterdam", "rotterdam" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f40b13c7-e943-6347-b27b-87ea625f3d1a"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "scorpion", "scorpion" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f4954913-2b3d-324d-84b0-5876cf9d8b24"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "gravelines", "gravelines" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f4bce987-6f07-7a40-9a18-de94db6cae3b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "besancon", "besancon" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f51c1640-f518-dd40-81e6-8cdcfa798e0c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ajaccio", "ajaccio" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f5827cb0-0c82-5d4d-b161-70cc991dcc9f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chateau rattelsdorf", "chateau rattelsdorf" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f59fee22-1e88-3642-a0ff-5d5922f9276c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "edinburgh", "edimbourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f5a41991-1f9c-7d4f-9a54-3fcffa0e7527"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "hamburg", "hambourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f5d4b168-d678-6d4d-adbf-cde9ae6ee951"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dumbarton oaks", "dumbarton oaks" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f61f1f7b-0973-9941-8bd5-5cced71544f0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dublin", "dublin" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f629ad70-c853-ed44-8d2e-1c4ff2aad5e2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "meissen", "meissen" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f6a85b37-c785-3c47-99e7-c1fbbe335397"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "spoleto", "spolete" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f6de36ec-b0e8-7045-b0ad-f2b9f77910ec"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "ink", "encre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f6dfe7c3-1aea-084d-8624-e351992ae1f0"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "usti nad labem", "usti nad labem" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f70bf61f-f0fc-b04f-899e-ca895a57ff29"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "milton (hampshire)", "milton (hampshire)" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f82d410d-c898-c94c-b505-63ad3d53cbcc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "nanterre", "nanterre" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f84f0d44-c887-e449-b9d4-6fc3c1326dc1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "coburg", "cobourg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f8900ed3-4ac6-d346-abad-79e2d07ccfc3"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mormant", "mormant" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f89f8fd7-a12b-6444-a979-c64eb7c11e07"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "davos-frauenkirch", "davos-frauenkirch" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f8c6007a-3135-ca4e-9a31-d01365f560d1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dronrijp", "dronrijp" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f8cb53c2-fb10-b042-bd30-bb560a2de28b"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chatsworth", "chatsworth" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f8f1dff9-080a-5f49-86a2-837eaa964ee7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "mold", "mold" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f909d85a-25eb-7644-9975-bbe71051d663"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "braunschweig", "braunschweig" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f9114a6a-79f6-dd45-a62b-f0d82833d989"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "petersham castle", "petersham castle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f91b9e23-507b-bc4c-808e-24ffc3804fcc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "laren", "laren" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f995b3c8-c353-0b4c-81df-5c34702fda51"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "arezzo", "arezzo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("f9c301ae-42ca-7943-9bfd-b12af948b4f1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "marcinelle", "marcinelle" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fa724b0c-c5ec-234e-a3fc-4354484aa1a2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "saint-amour", "saint-amour" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fab0eeca-6ed5-f84a-b0bb-6e3174db06c7"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "zloty stok", "zloty stok" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fad6b0db-1857-0644-bfd9-bdb1bde0e8dc"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "heilbronn", "heilbronn" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fb520b35-1319-2e4b-a5c1-c09997eec1c2"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "pittsburgh", "pittsburg" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fbab7c84-3b24-b249-aaeb-151f79d7b05d"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "kondratovko", "kondratovko" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fc4f97ad-dbc4-2047-8e2e-4c8d7359f882"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "polylobed form", "polylobe" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fca4e992-b0e9-174f-801c-ed9b06df9539"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "otterlo", "otterlo" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fcf554b0-aaf1-b74e-babc-8bf083bad9ac"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "neuses", "neuses" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fcf78861-f31a-9d44-97a3-870ce9f7e5cd"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "weybridge", "weybridge" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fd1bf783-8e06-7145-ba7d-613c152d439f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chartres", "chartres" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fdfe60a6-a459-ac4c-a8ba-d7876902bc55"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "music and intruments", "musique et instruments" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fe08a2f7-334b-4143-bd93-ee9dbe2e1b7c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "madrid", "madrid" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fe172c60-c8a5-714f-a5c8-e025c033ccb1"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "toul", "toul" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fe5a17c9-287b-2140-bd4e-537476efed54"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "besse-sur-issole", "besse-sur-issole" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fe9a7e9a-b92d-9e41-ae35-6c6d28dc9d61"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "bezolles", "bezolles" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("feaafbe3-545f-b743-b584-db9c17419c99"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "wrest park", "wrest park" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("fecb6dea-a733-dc48-839a-e2508131c2de"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "fontenay-aux-roses", "fontenay-aux-roses" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ff21d27d-ac72-3b4e-bd7b-2f74f027c35f"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "dreieich", "dreieich" });

            migrationBuilder.UpdateData(
                table: "SousReferences",
                keyColumn: "Id",
                keyValue: new Guid("ff5765ed-41e1-ff4c-8ef6-9f629073d84c"),
                columns: new[] { "LibelleTransLitLower2", "LibelleTransLitLowerFr" },
                values: new object[] { "chateau de terre-neuve", "chateau de terre-neuve" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LibelleTransLitLower2",
                table: "SousReferences");

            migrationBuilder.DropColumn(
                name: "LibelleTransLitLowerFr",
                table: "SousReferences");

            migrationBuilder.DropColumn(
                name: "LibelleTransLitLower2",
                table: "References");

            migrationBuilder.DropColumn(
                name: "LibelleTransLitLowerFr",
                table: "References");

            migrationBuilder.DropColumn(
                name: "InitialesTransLitLowerFr",
                table: "Marques");

            migrationBuilder.DropColumn(
                name: "TexteTransLitLowerFr",
                table: "MarqueReferenceLibres");
        }
    }
}
