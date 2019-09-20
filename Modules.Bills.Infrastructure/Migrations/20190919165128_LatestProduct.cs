using Microsoft.EntityFrameworkCore.Migrations;

namespace BillAppDDD.Modules.Bills.Infrastructure.Migrations
{
    public partial class LatestProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LatestVersion",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatestVersion",
                table: "Products");
        }
    }
}
