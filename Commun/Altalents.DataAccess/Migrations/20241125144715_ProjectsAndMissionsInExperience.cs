using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProjectsAndMissionsInExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_References_DomaineId",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropColumn(
                name: "ClientFinal",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "Lieu",
                table: "Experiences",
                newName: "LieuEntreprise");

            migrationBuilder.RenameColumn(
                name: "Entreprise",
                table: "Experiences",
                newName: "NomEntreprise");

            migrationBuilder.RenameColumn(
                name: "DomaineId",
                table: "Experiences",
                newName: "DomaineMetierId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_DomaineId",
                table: "Experiences",
                newName: "IX_Experiences_DomaineMetierId");

            migrationBuilder.AddColumn<bool>(
                name: "IsEntrepriseEsnOrInterim",
                table: "Experiences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProjetOrMissionClient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomClientOrProjet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionProjetOrMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DomaineMetierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtiMaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetOrMissionClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetOrMissionClient_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetOrMissionClient_References_DomaineMetierId",
                        column: x => x.DomaineMetierId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4052f410-0ded-4078-b065-46139c5f7f42"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5338));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("89810245-c71d-4772-b648-3fa7b626ea69"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a1cba742-7102-432e-b7a0-55eacf200761"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("babdff53-7380-48df-81ca-30e6da210010"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 15, 47, 14, 863, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.CreateIndex(
                name: "IX_ProjetOrMissionClient_DomaineMetierId",
                table: "ProjetOrMissionClient",
                column: "DomaineMetierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetOrMissionClient_ExperienceId",
                table: "ProjetOrMissionClient",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_References_DomaineMetierId",
                table: "Experiences",
                column: "DomaineMetierId",
                principalTable: "References",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_References_DomaineMetierId",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "ProjetOrMissionClient");

            migrationBuilder.DropColumn(
                name: "IsEntrepriseEsnOrInterim",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "NomEntreprise",
                table: "Experiences",
                newName: "Entreprise");

            migrationBuilder.RenameColumn(
                name: "LieuEntreprise",
                table: "Experiences",
                newName: "Lieu");

            migrationBuilder.RenameColumn(
                name: "DomaineMetierId",
                table: "Experiences",
                newName: "DomaineId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_DomaineMetierId",
                table: "Experiences",
                newName: "IX_Experiences_DomaineId");

            migrationBuilder.AddColumn<string>(
                name: "ClientFinal",
                table: "Experiences",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtiCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtiMaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projet_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4052f410-0ded-4078-b065-46139c5f7f42"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("89810245-c71d-4772-b648-3fa7b626ea69"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a1cba742-7102-432e-b7a0-55eacf200761"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("babdff53-7380-48df-81ca-30e6da210010"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.CreateIndex(
                name: "IX_Projet_ExperienceId",
                table: "Projet",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_References_DomaineId",
                table: "Experiences",
                column: "DomaineId",
                principalTable: "References",
                principalColumn: "Id");
        }
    }
}
