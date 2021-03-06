﻿using CoreService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels
{
    public class DetailedOrderViewModel
    {
       
        public int OrdenID { get; set; }

        public int ComensalID { get; set; }

        public int EstadoID { get; set; }

        public Estado estado { get; set; }

        public Comensales comensal { get; set; }

        public IEnumerable<Menu> menu { get; set; }

        public IEnumerable<Estado> estadosList { get; set; }

        public double totalMenu { get; set; }
    }
}
