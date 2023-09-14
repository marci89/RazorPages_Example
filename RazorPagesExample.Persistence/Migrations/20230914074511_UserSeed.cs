using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesExample.Persistence.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[] { 1L, new DateTime(2023, 9, 14, 9, 45, 10, 918, DateTimeKind.Local).AddTicks(1875), new DateTime(1989, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", "user", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
