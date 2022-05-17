using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialPlatformsAPI.Migrations
{
    public partial class CreateOneToOneRelationship_TranslationWithLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SocialPlatformTranslations_LanguageId",
                table: "SocialPlatformTranslations",
                column: "LanguageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialPlatformTranslations_languages_LanguageId",
                table: "SocialPlatformTranslations",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialPlatformTranslations_languages_LanguageId",
                table: "SocialPlatformTranslations");

            migrationBuilder.DropIndex(
                name: "IX_SocialPlatformTranslations_LanguageId",
                table: "SocialPlatformTranslations");
        }
    }
}
