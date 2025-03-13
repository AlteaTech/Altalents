using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakeDomainAsReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[] { new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"), "Tourismne", null, new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8224), null, true, "Autre", 1, null, "Domaine", "ALTEA", null });

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_References_TypeContratId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "DomaineMetier",
                table: "Experiences");

            migrationBuilder.AddColumn<Guid>(
                name: "DomaineId",
                table: "Experiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 13, 54, 18, 309, DateTimeKind.Local).AddTicks(8074));

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
                name: "IX_Experiences_DomaineId",
                table: "Experiences",
                column: "DomaineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_References_DomaineId",
                table: "Experiences",
                column: "DomaineId",
                principalTable: "References",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_References_TypeContratId",
                table: "Experiences",
                column: "TypeContratId",
                principalTable: "References",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_References_DomaineId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_References_TypeContratId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_DomaineId",
                table: "Experiences");

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"));

            migrationBuilder.DropColumn(
                name: "DomaineId",
                table: "Experiences");

            migrationBuilder.AddColumn<string>(
                name: "DomaineMetier",
                table: "Experiences",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4052f410-0ded-4078-b065-46139c5f7f42"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("89810245-c71d-4772-b648-3fa7b626ea69"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a1cba742-7102-432e-b7a0-55eacf200761"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("babdff53-7380-48df-81ca-30e6da210010"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 22, 15, 9, 15, 849, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_References_TypeContratId",
                table: "Experiences",
                column: "TypeContratId",
                principalTable: "References",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
