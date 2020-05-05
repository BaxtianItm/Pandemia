using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandemic.Web.Migrations
{
    public partial class addUserInDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StatusReport",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ReportDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_UserId",
                table: "ReportDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDetails_AspNetUsers_UserId",
                table: "ReportDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportDetails_AspNetUsers_UserId",
                table: "ReportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReportDetails_UserId",
                table: "ReportDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReportDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "StatusReport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
