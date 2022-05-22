using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddColumn_NameAr_SocialPlatformPostTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SocialPlatformPostTypes",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "SocialPlatformPostTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "SocialPlatformPostTypes");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "SocialPlatformPostTypes",
                newName: "Name");
        }
    }
}
