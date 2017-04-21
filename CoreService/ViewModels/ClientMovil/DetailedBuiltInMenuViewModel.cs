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

        public double Precio { get; set; }

        public IList<string> Seleccionados { get; set; }
    }
}
