using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels.ClientMovil
{
    public class DetailedBuiltInMenuViewModel
    {
        public int BundleId { get; set; }

        public string NameMenu { get; set; }

        public string MenuCategory { get; set; }

        public double precio { get; set; }

        public string SopaNombre { get; set; }

        public string PlatoFuerteNombre { get; set; }

        public string BebidaNombre { get; set; }

        public string PostreNombre { get; set; }

        public string ComplementoNombre { get; set; }

        public string BocadilloNombre { get; set; }
    }
}
