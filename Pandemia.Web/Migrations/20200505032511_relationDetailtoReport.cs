using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandemic.Web.Migrations
{
    public partial class relationDetailtoReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "ReportDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDetails_Report_ReportId",
                table: "ReportDetails",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportDetails_Report_ReportId",
                table: "ReportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ReportDetails");
        }
    }
}
