using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataModels.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "password123" },
                    { 2, "jane.smith@example.com", "Jane Smith", "password456" }
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "Email", "Name", "Password", "TrainerId" },
                values: new object[,]
                {
                    { 1, "mike.johnson@example.com", "Mike Johnson", "password789", 1 },
                    { 2, "emily.davis@example.com", "Emily Davis", "password101", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
