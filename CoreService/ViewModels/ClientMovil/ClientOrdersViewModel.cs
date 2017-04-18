using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels.ClientMovil
{
    public class ClientOrdersViewModel
    {
        public int ComensalID { get; set; }

        public int EstadoID { get; set; }

        public IList<MenuViewModel> menuSeleccionado { get; set; }

        public IEnumerable<Alimentos> AlimentosList { get; set; }

    }
}
