using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreService.Migrations
{
    public partial class AddColumnMenuBundleCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuCategory",
                table: "MenuBundle",
                maxLength: 50,
                nullable: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuCategory",
                table: "MenuBundle");
        }
    }
}
