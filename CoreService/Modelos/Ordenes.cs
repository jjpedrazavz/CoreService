﻿using System;
using System.Collections.Generic;

namespace CoreService.Models
{
    public partial class Ordenes
    {
        public Ordenes()
        {
            Menu = new HashSet<Menu>();
        }

        public int OrdenId { get; set; }
        public int ComensalId { get; set; }
        public int EstadoId { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
        public virtual Comensales Comensal { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
