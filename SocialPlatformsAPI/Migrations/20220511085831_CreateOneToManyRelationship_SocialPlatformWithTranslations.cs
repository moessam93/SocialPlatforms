using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialPlatformsAPI.Migrations
{
    public partial class CreateOneToManyRelationship_SocialPlatformWithTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_SocialPlatformTranslations_socialPlatforms_SocialPlatformId",
                table: "SocialPlatformTranslations",
                column: "SocialPlatformId",
                principalTable: "socialPlatforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialPlatformTranslations_socialPlatforms_SocialPlatformId",
                table: "SocialPlatformTranslations");
        }
    }
}
