﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillAppDDD.Modules.Bills.Infrastructure.Migrations
{
    public partial class Bill_Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bills");
        }
    }
}
