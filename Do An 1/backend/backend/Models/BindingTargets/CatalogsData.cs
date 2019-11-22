using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.BindingTargets
{
    public class CatalogsData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Visibility { get; set; }

        public Catalogs Catalogs => new Catalogs
        {
            Name = Name,
            ShortDescription = ShortDescription,
            Description = Description,
            Visibility = Visibility,
            CreatedAt = DateTime.Now,
            UpdateAt = DateTime.Now
        };
    }
}
