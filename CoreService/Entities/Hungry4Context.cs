using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CoreService.Models;

namespace CoreService.Entities
{
    public partial class Hungry4Context : DbContext
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

        public Hungry4Context(DbContextOptions<Hungry4Context> options):
            base(options)
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
                    .HasName("PK__Categori__F353C1C5F0982BDB");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Comensales>(entity =>
            {
                entity.HasKey(e => e.ComensalId)
                    .HasName("PK__Comensal__5D3B2D0FE544D8AE");

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
                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

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

                entity.Property(e => e.AlimentoId).HasColumnName("AlimentoID");

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.HasOne(d => d.Alimento)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.AlimentoId)
                    .HasConstraintName("FK_menu_alimento");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_menu_ordenes");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.OrdenId)
                    .HasName("PK__Ordenes__C088A4E45D6E2461");

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.ComensalId).HasColumnName("ComensalID");

                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

                entity.Property(e => e.OrdFecha).HasColumnType("datetime");

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
                    .HasName("PK__Tipos__97099E978BAE0E4A");

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);
            });
        }
    }
}