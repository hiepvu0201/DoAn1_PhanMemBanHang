using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.BindingTargets
{
    public class ProductsData
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public int Catalogs { get; set; }

        public Product Products => new Product
        {
            name = name,
            ShortDescription = ShortDescription,
            Description = Description,
            Price = Price,
            CreatedAt = DateTime.Now,
            UpdateAt = DateTime.Now,
            Catalogs = Catalogs == 0 ? null : new Catalogs { Id = Catalogs }
        };
    }
}
