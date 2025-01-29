using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MicroserviceRestApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    TrainersId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pupils_Trainers_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "Email", "Name", "Password", "TrainerId", "TrainersId" },
                values: new object[,]
                {
                    { 1, "mike.johnson@example.com", "Mike Johnson", "password789", 1, null },
                    { 2, "emily.davis@example.com", "Emily Davis", "password101", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "password123" },
                    { 2, "jane.smith@example.com", "Jane Smith", "password456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_TrainersId",
                table: "Pupils",
                column: "TrainersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
