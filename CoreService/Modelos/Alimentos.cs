using System;
using System.Collections.Generic;

namespace CoreService.Models
{
    public partial class Alimentos
    {
        public Alimentos()
        {
            FoodImageMapping = new HashSet<FoodImageMapping>();
            MenuBebida = new HashSet<Menu>();
            MenuBocadillo = new HashSet<Menu>();
            MenuComplemento = new HashSet<Menu>();
            MenuPlatoFuerte = new HashSet<Menu>();
            MenuPostre = new HashSet<Menu>();
            MenuSopa = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int TipoId { get; set; }

        public virtual ICollection<FoodImageMapping> FoodImageMapping { get; set; }
        public virtual ICollection<Menu> MenuBebida { get; set; }
        public virtual ICollection<Menu> MenuBocadillo { get; set; }
        public virtual ICollection<Menu> MenuComplemento { get; set; }
        public virtual ICollection<Menu> MenuPlatoFuerte { get; set; }
        public virtual ICollection<Menu> MenuPostre { get; set; }
        public virtual ICollection<Menu> MenuSopa { get; set; }
        public virtual Categorias Categoria { get; set; }
        public virtual Tipos Tipo { get; set; }
    }
}
