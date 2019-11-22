using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Product: AbstractModel
    {
        public string name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Catalogs Catalogs { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
