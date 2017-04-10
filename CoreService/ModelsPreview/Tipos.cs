﻿using System;
using System.Collections.Generic;

namespace CoreService.ModelsPreview
{
    public partial class Tipos
    {
        public Tipos()
        {
            Alimentos = new HashSet<Alimentos>();
        }

        public int TipoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alimentos> Alimentos { get; set; }
    }
}
