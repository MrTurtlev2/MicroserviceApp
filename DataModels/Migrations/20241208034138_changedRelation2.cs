using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModels.Migrations
{
    /// <inheritdoc />
    public partial class changedRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Trainers_TrainerId",
                table: "Pupils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupils",
                table: "Pupils");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Trainers1");

            migrationBuilder.RenameTable(
                name: "Pupils",
                newName: "Pupils1");

            migrationBuilder.RenameIndex(
                name: "IX_Pupils_TrainerId",
                table: "Pupils1",
                newName: "IX_Pupils1_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers1",
                table: "Trainers1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupils1",
                table: "Pupils1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils1_Trainers1_TrainerId",
                table: "Pupils1",
                column: "TrainerId",
                principalTable: "Trainers1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils1_Trainers1_TrainerId",
                table: "Pupils1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers1",
                table: "Trainers1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupils1",
                table: "Pupils1");

            migrationBuilder.RenameTable(
                name: "Trainers1",
                newName: "Trainers");

            migrationBuilder.RenameTable(
                name: "Pupils1",
                newName: "Pupils");

            migrationBuilder.RenameIndex(
                name: "IX_Pupils1_TrainerId",
                table: "Pupils",
                newName: "IX_Pupils_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupils",
                table: "Pupils",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Trainers_TrainerId",
                table: "Pupils",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
