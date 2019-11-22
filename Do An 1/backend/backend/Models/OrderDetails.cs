using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrdersID { get; set; }
        [Key]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
       
    }
}
