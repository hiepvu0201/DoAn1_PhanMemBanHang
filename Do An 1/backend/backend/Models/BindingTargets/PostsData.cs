using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.BindingTargets
{
    public class PostsData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        public int Categories { get; set; }

        public Posts Posts => new Posts
        {
            Name = Name,
            ShortDescription = ShortDescription,
            Content = Content,
            Categories = Categories == 0 ? null : new Categories { Id = Categories }
        };
    }
}
