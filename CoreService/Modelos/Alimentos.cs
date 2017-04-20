using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreService.Models
{
    public partial class Alimentos
    {
        public Alimentos()
        {
            FoodImageMapping = new HashSet<FoodImageMapping>();
            Menu = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int TipoId { get; set; }

        public bool estatus { get; set; }

        public virtual ICollection<FoodImageMapping> FoodImageMapping { get; set; }

        [JsonIgnore]
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual Categorias Categoria { get; set; }
        public virtual Tipos Tipo { get; set; }
    }
}
