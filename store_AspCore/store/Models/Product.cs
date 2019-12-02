using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class Product: AbstractModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        [Column(TypeName = "Text")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }

        public long CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
