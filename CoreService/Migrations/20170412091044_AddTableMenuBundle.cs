using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreService.Migrations
{
    public partial class AddTableMenuBundle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuBundle",
                columns: table => new
                {
                    MenuBundleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuBundle", x => x.MenuBundleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_BundleId",
                table: "Menu",
                column: "BundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_MenuBundle_BundleId",
                table: "Menu",
                column: "BundleId",
                principalTable: "MenuBundle",
                principalColumn: "MenuBundleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_MenuBundle_BundleId",
                table: "Menu");

            migrationBuilder.DropTable(
                name: "MenuBundle");

            migrationBuilder.DropIndex(
                name: "IX_Menu_BundleId",
                table: "Menu");
        }
    }
}
