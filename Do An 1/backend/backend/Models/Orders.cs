using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
