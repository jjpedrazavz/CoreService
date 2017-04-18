using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels
{
    public class SlimOrderViewModel
    {

        public int OrdenID { get; set; }

        public int ComensalID { get; set; }

        public DateTime OrdenFecha { get; set; }

        public string EstadoDescripcion { get; set; }
    }
}
