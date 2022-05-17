using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialPlatformsAPI.Migrations
{
    public partial class RemoveName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "socialPlatforms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "socialPlatforms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
