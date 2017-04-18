using CoreService.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels
{
    public class OrderViewModel
    {
        public int OrdenID { get; set; }

        public int ComensalID { get; set; }

        public int EstadoID { get; set; }

        public IList<MenuViewModel> menuSeleccionado { get; set; }

        [JsonIgnore]
        public SelectList Estados { get; set; }

        [JsonIgnore]
        public List<SelectList> MenusSeleccionar { get; set; }

        public IEnumerable<Alimentos> AlimentosList { get; set; }

        public IEnumerable<Estado> EstadosList { get; set; }

    }
}
