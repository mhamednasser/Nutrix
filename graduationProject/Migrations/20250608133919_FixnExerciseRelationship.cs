using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graduationProject.Migrations
{
    /// <inheritdoc />
    public partial class FixnExerciseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedDietPlans_Users_UserId",
                table: "GeneratedDietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedWorkoutPlans_Users_UserId",
                table: "GeneratedWorkoutPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId",
                table: "nExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_StructuredDietPlans_Users_UserId",
                table: "StructuredDietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_StructuredWorkoutPlans_Users_UserId",
                table: "StructuredWorkoutPlans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StructuredWorkoutPlans",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_StructuredWorkoutPlans_UserId",
                table: "StructuredWorkoutPlans",
                newName: "IX_StructuredWorkoutPlans_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StructuredDietPlans",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_StructuredDietPlans_UserId",
                table: "StructuredDietPlans",
                newName: "IX_StructuredDietPlans_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GeneratedWorkoutPlans",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedWorkoutPlans_UserId",
                table: "GeneratedWorkoutPlans",
                newName: "IX_GeneratedWorkoutPlans_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GeneratedDietPlans",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedDietPlans_UserId",
                table: "GeneratedDietPlans",
                newName: "IX_GeneratedDietPlans_UserProfileId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StructuredWorkoutPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StructuredWorkoutPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StructuredWorkoutPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StructuredDietPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StructuredDietPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StructuredDietPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MuscleGroupId1",
                table: "nExercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    FitnessLevel = table.Column<int>(type: "int", nullable: false),
                    WeeklyWorkoutDays = table.Column<int>(type: "int", nullable: false),
                    WorkoutDuration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    DietaryRestrictions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PreferredDiet = table.Column<int>(type: "int", nullable: false),
                    MedicalConditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AppUserId",
                table: "UserProfiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedDietPlans_UserProfiles_UserProfileId",
                table: "GeneratedDietPlans",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedWorkoutPlans_UserProfiles_UserProfileId",
                table: "GeneratedWorkoutPlans",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId",
                table: "nExercises",
                column: "MuscleGroupId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId1",
                table: "nExercises",
                column: "MuscleGroupId1",
                principalTable: "MuscleGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StructuredDietPlans_UserProfiles_UserProfileId",
                table: "StructuredDietPlans",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StructuredWorkoutPlans_UserProfiles_UserProfileId",
                table: "StructuredWorkoutPlans",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedDietPlans_UserProfiles_UserProfileId",
                table: "GeneratedDietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedWorkoutPlans_UserProfiles_UserProfileId",
                table: "GeneratedWorkoutPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId",
                table: "nExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId1",
                table: "nExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_StructuredDietPlans_UserProfiles_UserProfileId",
                table: "StructuredDietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_StructuredWorkoutPlans_UserProfiles_UserProfileId",
                table: "StructuredWorkoutPlans");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_nExercises_MuscleGroupId1",
                table: "nExercises");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StructuredWorkoutPlans");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StructuredWorkoutPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StructuredWorkoutPlans");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StructuredDietPlans");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StructuredDietPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StructuredDietPlans");

            migrationBuilder.DropColumn(
                name: "MuscleGroupId1",
                table: "nExercises");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginAt",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "StructuredWorkoutPlans",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StructuredWorkoutPlans_UserProfileId",
                table: "StructuredWorkoutPlans",
                newName: "IX_StructuredWorkoutPlans_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "StructuredDietPlans",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StructuredDietPlans_UserProfileId",
                table: "StructuredDietPlans",
                newName: "IX_StructuredDietPlans_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "GeneratedWorkoutPlans",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedWorkoutPlans_UserProfileId",
                table: "GeneratedWorkoutPlans",
                newName: "IX_GeneratedWorkoutPlans_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "GeneratedDietPlans",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedDietPlans_UserProfileId",
                table: "GeneratedDietPlans",
                newName: "IX_GeneratedDietPlans_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DietaryRestrictions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FitnessLevel = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    MedicalConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredDiet = table.Column<int>(type: "int", nullable: false),
                    WeeklyWorkoutDays = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    WorkoutDuration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedDietPlans_Users_UserId",
                table: "GeneratedDietPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedWorkoutPlans_Users_UserId",
                table: "GeneratedWorkoutPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nExercises_MuscleGroups_MuscleGroupId",
                table: "nExercises",
                column: "MuscleGroupId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StructuredDietPlans_Users_UserId",
                table: "StructuredDietPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StructuredWorkoutPlans_Users_UserId",
                table: "StructuredWorkoutPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
