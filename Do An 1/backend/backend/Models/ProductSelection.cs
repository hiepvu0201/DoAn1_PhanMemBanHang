using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ProductSelection
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int idCustomer { get; set; }
    }
}
