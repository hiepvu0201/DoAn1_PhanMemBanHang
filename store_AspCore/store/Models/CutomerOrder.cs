using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class CutomerOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Note { get; set; }
        public DateTime OrderDate { get; set; }
        public long OrderId { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
