﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Numero Orden")]
        public int OrdenID { get; set; }

        [Required]
        [Display(Name = "Comensal")]
        public string ComensalID { get; set; }

        [Required]
        public string EstadoID { get; set; }

        public string sopaID { get; set; }
        public string platoFuerteID { get; set; }
        public string bebidaID { get; set; }
        public string postreID { get; set; }
        public string complementoID { get; set; }

        public string bocadilloID { get; set; }


        public SelectList Estados { get; set; }

        public List<SelectList> MenusSeleccionar { get; set; }
    }
}