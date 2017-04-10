using System;
using System.Collections.Generic;

namespace CoreService.ModelsPreview
{
    public partial class Estado
    {
        public Estado()
        {
            Ordenes = new HashSet<Ordenes>();
        }

        public int EstadoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
