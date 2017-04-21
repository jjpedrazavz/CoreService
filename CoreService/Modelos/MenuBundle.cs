using CoreService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Modelos
{
    public partial class MenuBundle
    {
        public MenuBundle()
        {
            Menu = new HashSet<Menu>();
        }

        public int MenuBundleId { get; set; }

        [StringLength(120)]
        public string MenuBundleName { get; set; }

        [StringLength(50)]
        public string MenuCategory { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}
