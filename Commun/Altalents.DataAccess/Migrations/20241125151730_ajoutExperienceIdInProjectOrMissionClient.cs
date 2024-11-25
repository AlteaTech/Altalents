using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ajoutExperienceIdInProjectOrMissionClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjetOrMissionClient_Experiences_ExperienceId",
                table: "ProjetOrMissionClient");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExperienceId",
                table: "ProjetOrMissionClient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4052f410-0ded-4078-b065-46139c5f7f42"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("89810245-c71d-4772-b648-3fa7b626ea69"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a1cba742-7102-432e-b7a0-55eacf200761"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("babdff53-7380-48df-81ca-30e6da210010"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 17, 30, 377, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetOrMissionClient_Experiences_ExperienceId",
                table: "ProjetOrMissionClient",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjetOrMissionClient_Experiences_ExperienceId",
                table: "ProjetOrMissionClient");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExperienceId",
                table: "ProjetOrMissionClient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("21d2b28e-9d36-4d4d-8f01-f62d0ea149ef"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("3b2315eb-7b6d-40dd-b53c-bbd5eb85d3d4"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4052f410-0ded-4078-b065-46139c5f7f42"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(63));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("4055b77d-03a0-44f8-84dd-926fdb07f568"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("413c2810-d35c-4164-9021-73f5e50bad2b"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("41a511c4-eac4-4411-9fcc-2dad63333206"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("53f64464-3ac1-4440-9cbe-c629c0244ec7"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("5557465c-07ad-4ffe-85e3-bf8c2c34a07f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("650e788b-86b9-4884-a4eb-3582eb4f1d0d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("68940f3a-8d1a-43fe-afe9-a088fbf840f2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("74536288-8a56-4ab1-9410-e9203bbaa60d"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7b41cb52-4dbe-451e-bf7c-51d01a04e7e9"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("7c1c4f41-e0e6-4b32-897c-db2799ea8b29"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("804109be-d3de-4745-a8aa-e6535e1c3151"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("85e06dc8-abe0-4eb7-85df-c8f67d2f2cca"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("89810245-c71d-4772-b648-3fa7b626ea69"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("8c479024-2491-4d30-99bf-c2d0948d36e6"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("93123d1d-aa63-4e9a-b89c-72db6e616f76"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("939d7426-2069-4100-a8db-5ec86082fd49"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("95b23bbb-a76b-4ed5-ba30-0ff4c1eb8870"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a1cba742-7102-432e-b7a0-55eacf200761"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("babdff53-7380-48df-81ca-30e6da210010"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("bc9e9fa2-b46a-4974-9961-8814be2aa9f5"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c24eefc2-f4ba-463b-88fa-dca5f83e9d6f"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("e37ab257-7c00-4a8a-b71f-681ad18d1de2"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 367, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f05c980c-fd2d-454c-81d9-9afaa2f4b822"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f0d37651-b240-46d7-a6a1-e01aeb2b6b08"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f57fc24d-d771-4de2-8c56-180728b027ce"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f5f43903-c3f7-47fd-a207-98887dd59e87"),
                column: "DateCrea",
                value: new DateTime(2024, 11, 25, 16, 11, 37, 368, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetOrMissionClient_Experiences_ExperienceId",
                table: "ProjetOrMissionClient",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id");
        }
    }
}
