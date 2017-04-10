﻿using System;
using System.Collections.Generic;

namespace CoreService.ModelsPreview
{
    public partial class Categorias
    {
        public Categorias()
        {
            Alimentos = new HashSet<Alimentos>();
        }

        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alimentos> Alimentos { get; set; }
    }
}
