using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialPlatformsAPI.Migrations
{
    public partial class ChangeDateToCreateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "socialPlatforms",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "socialPlatforms",
                newName: "Date");
        }
    }
}
