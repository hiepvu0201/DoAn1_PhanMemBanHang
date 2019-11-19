using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Mã khách hàng")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maKH { get; set; }

        [DisplayName("Tên khách hàng")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string tenKH { get; set; }

        [DisplayName("Mã thành viên")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maThanhVien { get; set; }

        [DisplayName("Mã giao dịch")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public int maGiaoDich { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
        public PurchaseHistory PurchaseHistory { get; set; }
    }
}
