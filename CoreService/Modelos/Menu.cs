using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoreService.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public int? OrdenId { get; set; }
        public int? AlimentoId { get; set; }
        public int? Quantity { get; set; }

        public virtual Alimentos Alimento { get; set; }

        [JsonIgnore]
        public virtual Ordenes Orden { get; set; }
    }
}
