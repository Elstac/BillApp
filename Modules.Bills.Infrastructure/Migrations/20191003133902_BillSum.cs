using Microsoft.EntityFrameworkCore.Migrations;

namespace BillAppDDD.Modules.Bills.Infrastructure.Migrations
{
    public partial class BillSum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price_Value",
                table: "Products",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<float>(
                name: "Sum_Value",
                table: "Bills",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum_Value",
                table: "Bills");

            migrationBuilder.AlterColumn<float>(
                name: "Price_Value",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
