using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreService.Entities;

namespace CoreService.Migrations
{
    [DbContext(typeof(Hungry4Context))]
    [Migration("20170412091044_AddTableMenuBundle")]
    partial class AddTableMenuBundle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreService.Modelos.MenuBundle", b =>
                {
                    b.Property<int>("MenuBundleId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.HasKey("MenuBundleId");

                    b.ToTable("MenuBundle");
                });

            modelBuilder.Entity("CoreService.Models.Alimentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CategoriaId")
                        .HasColumnName("CategoriaID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric");

                    b.Property<int>("TipoId")
                        .HasColumnName("tipoID");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TipoId");

                    b.ToTable("Alimentos");
                });

            modelBuilder.Entity("CoreService.Models.Categorias", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoriaID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("CategoriaId")
                        .HasName("PK__Categori__F353C1C5F0982BDB");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CoreService.Models.Comensales", b =>
                {
                    b.Property<int>("ComensalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ComensalID");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("ComensalId")
                        .HasName("PK__Comensal__5D3B2D0FE544D8AE");

                    b.ToTable("Comensales");
                });

            modelBuilder.Entity("CoreService.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EstadoID");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("EstadoId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("CoreService.Models.FoodImageMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("AlimentosId")
                        .HasColumnName("AlimentosID");

                    b.Property<int?>("AlimentosImageId")
                        .HasColumnName("AlimentosImageID");

                    b.Property<int?>("ImageNumber");

                    b.HasKey("Id");

                    b.HasIndex("AlimentosId");

                    b.HasIndex("AlimentosImageId");

                    b.ToTable("FoodImageMapping");
                });

            modelBuilder.Entity("CoreService.Models.FoodImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("NameFile")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("FoodImages");
                });

            modelBuilder.Entity("CoreService.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MenuID");

                    b.Property<int?>("AlimentoId")
                        .HasColumnName("AlimentoID");

                    b.Property<int?>("BundleId");

                    b.Property<int?>("OrdenId")
                        .HasColumnName("OrdenID");

                    b.Property<int?>("Quantity");

                    b.HasKey("MenuId");

                    b.HasIndex("AlimentoId");

                    b.HasIndex("BundleId");

                    b.HasIndex("OrdenId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("CoreService.Models.Ordenes", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrdenID");

                    b.Property<int>("ComensalId")
                        .HasColumnName("ComensalID");

                    b.Property<int>("EstadoId")
                        .HasColumnName("EstadoID");

                    b.Property<DateTime>("OrdFecha")
                        .HasColumnType("datetime");

                    b.HasKey("OrdenId")
                        .HasName("PK__Ordenes__C088A4E45D6E2461");

                    b.HasIndex("ComensalId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("CoreService.Models.Tipos", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TipoID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("TipoId")
                        .HasName("PK__Tipos__97099E978BAE0E4A");

                    b.ToTable("Tipos");
                });

            modelBuilder.Entity("CoreService.Models.Alimentos", b =>
                {
                    b.HasOne("CoreService.Models.Categorias", "Categoria")
                        .WithMany("Alimentos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("CoreService.Models.Tipos", "Tipo")
                        .WithMany("Alimentos")
                        .HasForeignKey("TipoId");
                });

            modelBuilder.Entity("CoreService.Models.FoodImageMapping", b =>
                {
                    b.HasOne("CoreService.Models.Alimentos", "Alimentos")
                        .WithMany("FoodImageMapping")
                        .HasForeignKey("AlimentosId")
                        .HasConstraintName("FK_FoodImageMapping_Alimentos")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreService.Models.FoodImages", "AlimentosImage")
                        .WithMany("FoodImageMapping")
                        .HasForeignKey("AlimentosImageId")
                        .HasConstraintName("FK_FOODImageMapping_FoodImage");
                });

            modelBuilder.Entity("CoreService.Models.Menu", b =>
                {
                    b.HasOne("CoreService.Models.Alimentos", "Alimento")
                        .WithMany("Menu")
                        .HasForeignKey("AlimentoId")
                        .HasConstraintName("FK_menu_alimento");

                    b.HasOne("CoreService.Modelos.MenuBundle", "Bundle")
                        .WithMany("Menu")
                        .HasForeignKey("BundleId");

                    b.HasOne("CoreService.Models.Ordenes", "Orden")
                        .WithMany("Menu")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreService.Models.Ordenes", b =>
                {
                    b.HasOne("CoreService.Models.Comensales", "Comensal")
                        .WithMany("Ordenes")
                        .HasForeignKey("ComensalId")
                        .HasConstraintName("FK_Ordenes_Comensal");

                    b.HasOne("CoreService.Models.Estado", "Estado")
                        .WithMany("Ordenes")
                        .HasForeignKey("EstadoId")
                        .HasConstraintName("FK_Ordenes_Estado");
                });
        }
    }
}
