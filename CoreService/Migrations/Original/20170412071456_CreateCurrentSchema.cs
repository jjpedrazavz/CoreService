using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreService.Migrations.Original
{
    public partial class CreateCurrentSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__F353C1C5F0982BDB", x => x.CategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Comensales",
                columns: table => new
                {
                    ComensalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Nombre = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comensal__5D3B2D0FE544D8AE", x => x.ComensalID);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "FoodImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameFile = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodImages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tipos__97099E978BAE0E4A", x => x.TipoID);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComensalID = table.Column<int>(nullable: false),
                    EstadoID = table.Column<int>(nullable: false),
                    OrdFecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ordenes__C088A4E45D6E2461", x => x.OrdenID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Comensal",
                        column: x => x.ComensalID,
                        principalTable: "Comensales",
                        principalColumn: "ComensalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Estado",
                        column: x => x.EstadoID,
                        principalTable: "Estado",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 80, nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    tipoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alimentos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alimentos_Tipos_tipoID",
                        column: x => x.tipoID,
                        principalTable: "Tipos",
                        principalColumn: "TipoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodImageMapping",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlimentosID = table.Column<int>(nullable: true),
                    AlimentosImageID = table.Column<int>(nullable: true),
                    ImageNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodImageMapping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodImageMapping_Alimentos",
                        column: x => x.AlimentosID,
                        principalTable: "Alimentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FOODImageMapping_FoodImage",
                        column: x => x.AlimentosImageID,
                        principalTable: "FoodImages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlimentoID = table.Column<int>(nullable: true),
                    OrdenID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_menu_alimento",
                        column: x => x.AlimentoID,
                        principalTable: "Alimentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Ordenes_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_CategoriaID",
                table: "Alimentos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_tipoID",
                table: "Alimentos",
                column: "tipoID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodImageMapping_AlimentosID",
                table: "FoodImageMapping",
                column: "AlimentosID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodImageMapping_AlimentosImageID",
                table: "FoodImageMapping",
                column: "AlimentosImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_AlimentoID",
                table: "Menu",
                column: "AlimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_OrdenID",
                table: "Menu",
                column: "OrdenID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ComensalID",
                table: "Ordenes",
                column: "ComensalID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EstadoID",
                table: "Ordenes",
                column: "EstadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodImageMapping");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "FoodImages");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Comensales");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
