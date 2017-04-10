using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CoreService.Models;

namespace CoreService.Entities
{
    public partial class HungryDbContext : DbContext
    {
        public virtual DbSet<Alimentos> Alimentos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Comensales> Comensales { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<FoodImageMapping> FoodImageMapping { get; set; }
        public virtual DbSet<FoodImages> FoodImages { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }


        public HungryDbContext(DbContextOptions<HungryDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alimentos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Precio).HasColumnType("numeric");

                entity.Property(e => e.TipoId).HasColumnName("tipoID");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Alimentos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Categories_Alimentos");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Alimentos)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tipos_Alimentos");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1C5C5CB05D8");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Comensales>(entity =>
            {
                entity.HasKey(e => e.ComensalId)
                    .HasName("PK__Comensal__5D3B2D0FB0D71639");

                entity.Property(e => e.ComensalId).HasColumnName("ComensalID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoID).HasColumnName("EstadoID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<FoodImageMapping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlimentosId).HasColumnName("AlimentosID");

                entity.Property(e => e.AlimentosImageId).HasColumnName("AlimentosImageID");

                entity.HasOne(d => d.Alimentos)
                    .WithMany(p => p.FoodImageMapping)
                    .HasForeignKey(d => d.AlimentosId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FoodImageMapping_Alimentos");

                entity.HasOne(d => d.AlimentosImage)
                    .WithMany(p => p.FoodImageMapping)
                    .HasForeignKey(d => d.AlimentosImageId)
                    .HasConstraintName("FK_FOODImageMapping_FoodImage");
            });

            modelBuilder.Entity<FoodImages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameFile).HasMaxLength(120);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.BebidaId).HasColumnName("bebidaID");

                entity.Property(e => e.BocadilloId).HasColumnName("bocadilloID");

                entity.Property(e => e.ComplementoId).HasColumnName("complementoID");

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.PlatoFuerteId).HasColumnName("platoFuerteID");

                entity.Property(e => e.PostreId).HasColumnName("postreID");

                entity.Property(e => e.SopaId).HasColumnName("sopaID");

                entity.HasOne(d => d.Bebida)
                    .WithMany(p => p.MenuBebida)
                    .HasForeignKey(d => d.BebidaId)
                    .HasConstraintName("FK_menu_bebida");

                entity.HasOne(d => d.Bocadillo)
                    .WithMany(p => p.MenuBocadillo)
                    .HasForeignKey(d => d.BocadilloId)
                    .HasConstraintName("FK_menu_bocadillo");

                entity.HasOne(d => d.Complemento)
                    .WithMany(p => p.MenuComplemento)
                    .HasForeignKey(d => d.ComplementoId)
                    .HasConstraintName("FK_menu_complemento");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_menu_ordenes");

                entity.HasOne(d => d.PlatoFuerte)
                    .WithMany(p => p.MenuPlatoFuerte)
                    .HasForeignKey(d => d.PlatoFuerteId)
                    .HasConstraintName("FK_menu_platoFuerte");

                entity.HasOne(d => d.Postre)
                    .WithMany(p => p.MenuPostre)
                    .HasForeignKey(d => d.PostreId)
                    .HasConstraintName("FK_menu_postre");

                entity.HasOne(d => d.Sopa)
                    .WithMany(p => p.MenuSopa)
                    .HasForeignKey(d => d.SopaId)
                    .HasConstraintName("FK_menu_sopa");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.OrdenId)
                    .HasName("PK__Ordenes__C088A4E4861029B7");

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.ComensalId).HasColumnName("ComensalID");

                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

                entity.HasOne(d => d.Comensal)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.ComensalId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ordenes_Comensal");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ordenes_Estado");
            });

            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK__Tipos__97099E97C26DCB8A");

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);
            });
        }
    }
}