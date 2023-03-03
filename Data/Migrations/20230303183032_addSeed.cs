using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniTodo.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsCompleted", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1ea00fca-1594-4d10-a66d-07ee71934e2c"), new DateTime(2023, 3, 3, 15, 30, 32, 325, DateTimeKind.Local).AddTicks(6701), null, false, "Teste 4", null },
                    { new Guid("3f5420b8-6a12-445f-b1c1-be8d281698ad"), new DateTime(2023, 3, 3, 15, 30, 32, 325, DateTimeKind.Local).AddTicks(6658), null, false, "Teste 1", null },
                    { new Guid("b3c5dfb8-c27c-415e-be31-57c66cb0f65a"), new DateTime(2023, 3, 3, 15, 30, 32, 325, DateTimeKind.Local).AddTicks(6703), null, false, "Teste 5", null },
                    { new Guid("f1dcd9a2-6826-4247-95b9-2448dba1b551"), new DateTime(2023, 3, 3, 15, 30, 32, 325, DateTimeKind.Local).AddTicks(6697), null, false, "Teste 3", null },
                    { new Guid("f785d98b-bfdd-4b30-93b1-e2d91add94f9"), new DateTime(2023, 3, 3, 15, 30, 32, 325, DateTimeKind.Local).AddTicks(6696), null, false, "Teste 2", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
