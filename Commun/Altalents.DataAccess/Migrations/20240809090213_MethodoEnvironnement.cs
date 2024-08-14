using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MethodoEnvironnement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "Code", "CommentaireFun", "DateCrea", "DateMaj", "IsValide", "Libelle", "OrdreTri", "SousType", "Type", "UtiCrea", "UtiMaj" },
                values: new object[,]
                {
                    { new Guid("051cbeb3-a9fe-4fad-bc3c-1cc3577d3c5d"), "PERT", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "PERT", 1, null, "Methodologies", "ALTEA", null },
                    { new Guid("36ec7894-609d-4238-bdcd-5a5962a56eb8"), "Java", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Java", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("6a575078-66ed-4151-b089-5dad1cdacc53"), "SCRUM", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "SCRUM", 1, null, "Methodologies", "ALTEA", null },
                    { new Guid("88308351-55b8-4ae6-8a9a-827863f380ff"), "Lean", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Lean", 1, null, "Methodologies", "ALTEA", null },
                    { new Guid("9bd90bab-2825-4f36-a49f-9227be2c1f72"), "Csharp", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "C#", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("a12fecbe-e5ec-40f8-86e5-9fc7ffcf1236"), "Jee", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "JEE", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("a3853f2d-bb30-4f82-950d-77dda048c99d"), "Linux", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Linux", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("a6b3992a-dd4c-4f21-b74a-5e528d47ea71"), "Windows", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Windows", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("ba160a68-8e50-4f8f-92d9-09663dc6684b"), "Notion", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Notion.so", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("c5e29778-d6ce-4d83-a663-83fa37bf861d"), "InVision", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "inVision", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("d13fd336-150e-4cc0-bfc2-0bb974561de3"), "MicrosoftOffice365", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Microsoft Office 365", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("f9ed505f-8a9e-41fd-90e3-dc92bb0508c9"), "CycleV", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Cycle en V", 1, null, "Methodologies", "ALTEA", null },
                    { new Guid("fc88220d-c3b5-45ac-9de8-fcd406f96b11"), "MicrosoftOffice", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Microsoft Office", 1, null, "OutilEtEnvironnement", "ALTEA", null },
                    { new Guid("fcda6459-bf8b-468c-b8fc-999eaa3d1500"), "KANBAN", null, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "KANBAN", 1, null, "Methodologies", "ALTEA", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("051cbeb3-a9fe-4fad-bc3c-1cc3577d3c5d"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("36ec7894-609d-4238-bdcd-5a5962a56eb8"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("6a575078-66ed-4151-b089-5dad1cdacc53"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("88308351-55b8-4ae6-8a9a-827863f380ff"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("9bd90bab-2825-4f36-a49f-9227be2c1f72"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a12fecbe-e5ec-40f8-86e5-9fc7ffcf1236"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a3853f2d-bb30-4f82-950d-77dda048c99d"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("a6b3992a-dd4c-4f21-b74a-5e528d47ea71"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("ba160a68-8e50-4f8f-92d9-09663dc6684b"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("c5e29778-d6ce-4d83-a663-83fa37bf861d"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("d13fd336-150e-4cc0-bfc2-0bb974561de3"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("f9ed505f-8a9e-41fd-90e3-dc92bb0508c9"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fc88220d-c3b5-45ac-9de8-fcd406f96b11"));

            migrationBuilder.DeleteData(
                table: "References",
                keyColumn: "Id",
                keyValue: new Guid("fcda6459-bf8b-468c-b8fc-999eaa3d1500"));
        }
    }
}
