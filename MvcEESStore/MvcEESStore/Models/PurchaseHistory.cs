using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEESStore.Models
{
    public class PurchaseHistory
    {
        [Key]
        [DisplayName("Mã lịch sử mua hàng")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maPurchaseHistory { get; set; }

        [DisplayName("Mã hóa đơn")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public int maHD { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
