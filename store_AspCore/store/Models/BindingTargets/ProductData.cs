using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.BindingTargets
{
    public class ProductData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }

        public long CatalogId { get; set; }

        public Product Product => new Product
        {
            Name = Name,
            ShortDescription = ShortDescription,
            Description = Description,
            Price = Price,
            Catalog = CatalogId == 0 ? null : new Catalog { Id = CatalogId }
        };
    }
}
