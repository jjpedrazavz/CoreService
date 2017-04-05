using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreService.Models
{
    public partial class FoodImages
    {
        public FoodImages()
        {
            FoodImageMapping = new HashSet<FoodImageMapping>();
        }

        public int Id { get; set; }
        
        public string NameFile { get; set; }

        [JsonIgnore]
        public virtual ICollection<FoodImageMapping> FoodImageMapping { get; set; }
    }
}
