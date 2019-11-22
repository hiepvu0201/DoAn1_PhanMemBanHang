using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Cart
    {
        public Customer Customer { get; set; }
        public ProductSelection ProductSelections { get; set; }
    }
}
