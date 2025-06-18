using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graduationProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUserProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId1",
                table: "nExercises");

            migrationBuilder.DropIndex(
                name: "IX_nExercises_MuscleGroupId1",
                table: "nExercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroupId1",
                table: "nExercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MuscleGroupId1",
                table: "nExercises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 8,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 9,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 10,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 11,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 12,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 13,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 14,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 15,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 16,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 17,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 18,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 19,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 20,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 21,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 22,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 23,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 24,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 25,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 26,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 27,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 28,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 29,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 30,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 31,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 32,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 33,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 34,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 35,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 36,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "nExercises",
                keyColumn: "Id",
                keyValue: 37,
                column: "MuscleGroupId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_nExercises_MuscleGroupId1",
                table: "nExercises",
                column: "MuscleGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId1",
                table: "nExercises",
                column: "MuscleGroupId1",
                principalTable: "MuscleGroups",
                principalColumn: "Id");
        }
    }
}
