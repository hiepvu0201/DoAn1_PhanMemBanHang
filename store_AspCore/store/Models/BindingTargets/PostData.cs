using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.BindingTargets
{
    public class PostData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Post Post => new Post
        {
            Name = Name,
            ShortDescription = ShortDescription,
            Content = Content,
            CategoryId = CategoryId
        };
    }
}
