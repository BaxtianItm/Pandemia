using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandemic.Web.Migrations
{
    public partial class addAddressInReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Report",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Report");
        }
    }
}
