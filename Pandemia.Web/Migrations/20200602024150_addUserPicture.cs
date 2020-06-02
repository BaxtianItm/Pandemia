using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandemic.Web.Migrations
{
    public partial class addUserPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUserPath",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUserPath",
                table: "AspNetUsers");
        }
    }
}
