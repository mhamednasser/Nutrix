using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graduationProject.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneralPlansFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralDietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DailyCalories = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Goals = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProteinPercentage = table.Column<int>(type: "int", nullable: false),
                    CarbPercentage = table.Column<int>(type: "int", nullable: false),
                    FatPercentage = table.Column<int>(type: "int", nullable: false),
                    KeyFeatures = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PlanDetailsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDietPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralWorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ExerciseCount = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Goals = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: false),
                    KeyFeatures = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TargetMuscles = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PlanDetailsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralWorkoutPlans", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 0, 32, 29, 163, DateTimeKind.Utc).AddTicks(466));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralDietPlans");

            migrationBuilder.DropTable(
                name: "GeneralWorkoutPlans");

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "ChallengeDayTasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3939));
        }
    }
}
