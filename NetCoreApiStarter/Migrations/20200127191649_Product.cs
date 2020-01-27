using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreApiStarter.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 1, new DateTime(2020, 1, 27, 11, 16, 49, 662, DateTimeKind.Local).AddTicks(7194), "Prod-01", false, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 2, new DateTime(2020, 1, 27, 11, 16, 49, 662, DateTimeKind.Local).AddTicks(7202), "Prod-02", false, 3 });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 27, 11, 16, 49, 661, DateTimeKind.Local).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 27, 11, 16, 49, 662, DateTimeKind.Local).AddTicks(5804));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 26, 22, 39, 6, 675, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 26, 22, 39, 6, 677, DateTimeKind.Local).AddTicks(5236));
        }
    }
}
