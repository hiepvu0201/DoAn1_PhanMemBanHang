using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class Post:AbstractModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        [Column(TypeName = "Text")]
        public string Content { get; set; }
        public string Image { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
