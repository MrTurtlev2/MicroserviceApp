using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroserviceRestApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercisesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Pupils_PupilsId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_PupilsId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PupilsId",
                table: "Exercises");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "PupilId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "PupilId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_PupilId",
                table: "Exercises",
                column: "PupilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Pupils_PupilId",
                table: "Exercises",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Pupils_PupilId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_PupilId",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "PupilsId",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PupilId", "PupilsId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PupilId", "PupilsId" },
                values: new object[] { 0, null });

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
    }
}
