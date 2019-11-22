using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Posts: AbstractModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
        public string Image { get; set; }
        public Categories Categories { get; set; }
    }
}
