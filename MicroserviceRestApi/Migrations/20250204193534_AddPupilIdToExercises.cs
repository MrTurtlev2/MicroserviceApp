using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroserviceRestApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPupilIdToExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PupilId",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "PupilId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "PupilId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "Exercises");
        }
    }
}
