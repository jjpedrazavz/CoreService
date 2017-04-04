using System;
using System.Collections.Generic;

namespace CoreService.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public int? OrdenId { get; set; }
        public int? SopaId { get; set; }
        public int? PlatoFuerteId { get; set; }
        public int? BebidaId { get; set; }
        public int? PostreId { get; set; }
        public int? ComplementoId { get; set; }
        public int? BocadilloId { get; set; }

        public virtual Alimentos Bebida { get; set; }
        public virtual Alimentos Bocadillo { get; set; }
        public virtual Alimentos Complemento { get; set; }
        public virtual Ordenes Orden { get; set; }
        public virtual Alimentos PlatoFuerte { get; set; }
        public virtual Alimentos Postre { get; set; }
        public virtual Alimentos Sopa { get; set; }
    }
}
