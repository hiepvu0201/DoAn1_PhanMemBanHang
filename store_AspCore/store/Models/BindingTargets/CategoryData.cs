using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.BindingTargets
{
    public class CategoryData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Visibility { get; set; }

        public Category Category => new Category
        {
            Name = Name,
            ShortDescription = ShortDescription,
            Description = Description,
            Visibility = Visibility
        };
    }
}
