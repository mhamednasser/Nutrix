using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graduationProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNutritionalInfoToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "NutritionalInfos",
                newName: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalInfos_UserProfileId",
                table: "NutritionalInfos",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionalInfos_UserProfiles_UserProfileId",
                table: "NutritionalInfos",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionalInfos_UserProfiles_UserProfileId",
                table: "NutritionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_NutritionalInfos_UserProfileId",
                table: "NutritionalInfos");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "NutritionalInfos",
                newName: "UserId");
        }
    }
}
