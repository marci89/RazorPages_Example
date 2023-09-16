using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesExample.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[] { 1L, new DateTime(2023, 9, 16, 13, 19, 46, 369, DateTimeKind.Local).AddTicks(6834), new DateTime(1989, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "marci@example.com", "marci", "marci" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[] { 2L, new DateTime(2023, 9, 16, 13, 19, 46, 369, DateTimeKind.Local).AddTicks(6871), new DateTime(1967, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", "John", "john" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[] { 3L, new DateTime(2023, 9, 16, 13, 19, 46, 369, DateTimeKind.Local).AddTicks(6874), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Alice", "alice" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[] { 4L, new DateTime(2023, 9, 16, 13, 19, 46, 369, DateTimeKind.Local).AddTicks(6877), new DateTime(1985, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "eve@example.com", "Eve", "eve" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[] { 5L, new DateTime(2023, 9, 16, 13, 19, 46, 369, DateTimeKind.Local).AddTicks(6880), new DateTime(1992, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "grace@example.com", "Grace", "grace" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Type", "UserId" },
                values: new object[] { 1L, 4, "Fluffy", 1, 1L });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Type", "UserId" },
                values: new object[] { 2L, 3, "Rover", 2, 1L });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Type", "UserId" },
                values: new object[] { 3L, 1, "Whiskers", 1, 1L });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Type", "UserId" },
                values: new object[] { 4L, 6, "Fido", 2, 1L });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Type", "UserId" },
                values: new object[] { 5L, 3, "Mittens", 1, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
