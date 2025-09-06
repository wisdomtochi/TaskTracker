using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Migrations
{
    /// <inheritdoc />
    public partial class SampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "activities",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "IsActive", "IsCompleted", "LastModifiedAt", "Title" },
                values: new object[] { new Guid("c1a1f1ee-6c54-4b01-90e6-d701748f0851"), new DateTime(2025, 9, 6, 16, 19, 30, 910, DateTimeKind.Utc).AddTicks(7109), "This is a sample activity description.", new DateTime(2025, 9, 13, 16, 19, 30, 910, DateTimeKind.Utc).AddTicks(1616), true, false, new DateTime(2025, 9, 6, 16, 19, 30, 910, DateTimeKind.Utc).AddTicks(7565), "Sample Activity" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "CreatedAt", "IsActive", "LastModifiedAt", "Name" },
                values: new object[] { new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851"), new DateTime(2025, 9, 6, 16, 19, 30, 908, DateTimeKind.Utc).AddTicks(899), true, new DateTime(2025, 9, 6, 16, 19, 30, 908, DateTimeKind.Utc).AddTicks(1417), "Sample Tag" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "activities",
                keyColumn: "Id",
                keyValue: new Guid("c1a1f1ee-6c54-4b01-90e6-d701748f0851"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851"));
        }
    }
}
