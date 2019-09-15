using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillAppDDD.Modules.Bills.Infrastructure.Migrations
{
    public partial class BillsModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Bills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Bills",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LogoImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Barcode_Value = table.Column<string>(nullable: true),
                    Price_Value = table.Column<float>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    LastVersionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_LastVersionId",
                        column: x => x.LastVersionId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    BillId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Cost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => new { x.BillId, x.ProductId });
                    table.UniqueConstraint("AK_Purchase_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_StoreId",
                table: "Bills",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryId",
                table: "ProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastVersionId",
                table: "Products",
                column: "LastVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProductId",
                table: "Purchase",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Stores_StoreId",
                table: "Bills",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Stores_StoreId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Bills_StoreId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Bills");
        }
    }
}
