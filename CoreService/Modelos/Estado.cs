using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoreService.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Ordenes = new HashSet<Ordenes>();
        }

        public int EstadoID { get; set; }
        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
