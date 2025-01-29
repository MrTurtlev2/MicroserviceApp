using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroserviceRestApi.Migrations
{
    /// <inheritdoc />
    public partial class Exiecises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Comment",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Label",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PupilsId",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_PupilsId",
                table: "Exercises",
                column: "PupilsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Pupils_PupilsId",
                table: "Exercises",
                column: "PupilsId",
                principalTable: "Pupils",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Pupils_PupilsId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_PupilsId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PupilsId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Exercises");
        }
    }
}
