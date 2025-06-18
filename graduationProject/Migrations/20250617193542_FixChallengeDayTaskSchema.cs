using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace graduationProject.Migrations
{
    /// <inheritdoc />
    public partial class FixChallengeDayTaskSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeDayTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeDayTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeDayTasks_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChallengeProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CurrentDay = table.Column<int>(type: "int", nullable: false),
                    CurrentLevel = table.Column<int>(type: "int", nullable: false),
                    CompletedDaysJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChallengeProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChallengeProgress_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserChallengeProgress_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "ChallengeTitle", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { 1, "Healthy Habits Challenge", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A 4-level challenge to build better daily habits.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ChallengeDayTasks",
                columns: new[] { "Id", "ChallengeId", "CreatedAt", "DayNumber", "Description", "Level", "Tip", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3894), 1, "Drink at least 8 cups of water today.", 1, "Keep a water bottle with you at all times.", "Drink More Water" },
                    { 2, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3896), 2, "Take a brisk 20-minute walk.", 1, "Walking after meals improves digestion.", "Walk 20 Minutes" },
                    { 3, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3897), 3, "Ensure you get at least 8 hours of sleep.", 1, "Avoid screens 1 hour before bed.", "Sleep 8 Hours" },
                    { 4, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3898), 4, "Add at least 2 servings of vegetables to your meals.", 1, "Try a new vegetable today.", "Eat Vegetables" },
                    { 5, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3900), 5, "Meditate for 10 minutes to reduce stress.", 1, "Use a guided meditation app if needed.", "Meditate" },
                    { 6, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3901), 6, "Avoid added sugar for the whole day.", 1, "Check food labels carefully.", "No Sugar Day" },
                    { 7, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3902), 7, "Do 10 minutes of full-body stretching.", 1, "Focus on breathing while stretching.", "Stretch" },
                    { 8, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3911), 8, "Drink at least 10 cups of water today.", 2, "Add lemon for flavor variety.", "Increase Water Intake" },
                    { 9, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3912), 9, "Take a brisk 30-minute walk or light jog.", 2, "Try walking in a new location.", "Walk 30 Minutes" },
                    { 10, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3913), 10, "Sleep 8+ hours with good sleep hygiene.", 2, "Keep your room cool and dark.", "Quality Sleep" },
                    { 11, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3915), 11, "Add 3 servings of vegetables to your meals.", 2, "Include vegetables in every meal.", "More Vegetables" },
                    { 12, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3916), 12, "Meditate for 15 minutes.", 2, "Try different meditation techniques.", "Extended Meditation" },
                    { 13, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3917), 13, "Choose only healthy snacks today.", 2, "Prepare snacks in advance.", "Healthy Snacks" },
                    { 14, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3918), 14, "Do 15 minutes of yoga or stretching.", 2, "Focus on flexibility and relaxation.", "Yoga Flow" },
                    { 15, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3921), 15, "Drink water before every meal.", 3, "This helps with digestion and portion control.", "Hydration Challenge" },
                    { 16, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3923), 16, "Do 40 minutes of moderate cardio.", 3, "Mix different activities to stay engaged.", "Cardio Boost" },
                    { 17, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3924), 17, "Create the perfect sleep environment.", 3, "Remove all electronic devices from bedroom.", "Sleep Optimization" },
                    { 18, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3925), 18, "Eat only plant-based foods today.", 3, "Explore new plant-based recipes.", "Plant-Based Day" },
                    { 19, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3926), 19, "Practice mindfulness for 20 minutes.", 3, "Try walking meditation outdoors.", "Mindfulness Practice" },
                    { 20, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3928), 20, "Avoid processed foods completely.", 3, "Focus on whole, natural foods.", "Detox Day" },
                    { 21, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3929), 21, "Combine strength training with yoga.", 3, "Balance is key to overall fitness.", "Strength & Flexibility" },
                    { 22, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3932), 22, "Perfect your daily hydration routine.", 4, "Track your intake and adjust as needed.", "Ultimate Hydration" },
                    { 23, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3933), 23, "Do your most challenging workout yet.", 4, "Push your limits safely.", "Peak Performance" },
                    { 24, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3934), 24, "Prioritize rest and recovery.", 4, "Listen to your body's needs.", "Recovery Focus" },
                    { 25, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3936), 25, "Create the perfect nutrition day.", 4, "Plan every meal mindfully.", "Nutritional Excellence" },
                    { 26, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3937), 26, "Focus on the connection between mind and body.", 4, "Combine meditation with movement.", "Mind-Body Connection" },
                    { 27, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3938), 27, "Integrate all healthy habits seamlessly.", 4, "Make healthy choices feel natural.", "Lifestyle Integration" },
                    { 28, 1, new DateTime(2025, 6, 17, 19, 35, 41, 815, DateTimeKind.Utc).AddTicks(3939), 28, "Celebrate your achievement and plan ahead.", 4, "Reflect on your journey and set new goals.", "Challenge Complete" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeDayTasks_ChallengeId",
                table: "ChallengeDayTasks",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeProgress_ChallengeId",
                table: "UserChallengeProgress",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeProgress_UserProfileId",
                table: "UserChallengeProgress",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeDayTasks");

            migrationBuilder.DropTable(
                name: "UserChallengeProgress");

            migrationBuilder.DropTable(
                name: "Challenges");
        }
    }
}
