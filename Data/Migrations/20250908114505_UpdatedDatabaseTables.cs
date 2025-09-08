using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "activities",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "activities",
                keyColumn: "Id",
                keyValue: new Guid("c1a1f1ee-6c54-4b01-90e6-d701748f0851"),
                columns: new[] { "CreatedAt", "DueDate", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 9, 8, 11, 45, 2, 251, DateTimeKind.Utc).AddTicks(8567), new DateTime(2025, 9, 15, 11, 45, 2, 251, DateTimeKind.Utc).AddTicks(6995), new DateTime(2025, 9, 8, 11, 45, 2, 251, DateTimeKind.Utc).AddTicks(8979) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "activities",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "activities",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "activities",
                keyColumn: "Id",
                keyValue: new Guid("c1a1f1ee-6c54-4b01-90e6-d701748f0851"),
                columns: new[] { "CreatedAt", "DueDate", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 9, 6, 16, 19, 30, 910, DateTimeKind.Utc).AddTicks(7109), new DateTime(2025, 9, 13, 16, 19, 30, 910, DateTimeKind.Utc).AddTicks(1616), new DateTime(2025, 9, 6, 16, 19, 30, 910, DateTimeKind.Utc).AddTicks(7565) });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "CreatedAt", "IsActive", "LastModifiedAt", "Name" },
                values: new object[] { new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851"), new DateTime(2025, 9, 6, 16, 19, 30, 908, DateTimeKind.Utc).AddTicks(899), true, new DateTime(2025, 9, 6, 16, 19, 30, 908, DateTimeKind.Utc).AddTicks(1417), "Sample Tag" });
        }
    }
}
