using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class Receipt
    {
        [Key]
        [DisplayName("Mã hóa đơn")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maHD { get; set; }

        [DisplayName("Mã sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maSP { get; set; }

        [DisplayName("Ngày giờ giao dịch")]
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ngayGiaoDich { get; set; }

        [DisplayName("Số lượng sản phẩm")]
        [Column(TypeName = "int")]
        [Required]
        public int soLuongSP { get; set; }

        [DisplayName("Đơn giá")]
        [Column(TypeName = "int")]
        [Required]
        public int donGia { get; set; }

        [DisplayName("Thành tiền")]
        [Column(TypeName = "int")]
        [Required]
        public int thanhTieh { get; set; }

        [DisplayName("Tổng tiền")]
        [Column(TypeName = "int")]
        [Required]
        public int tongTien { get; set; }

        [DisplayName("Mã khách hàng")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maKH { get; set; }

        [DisplayName("Tên khách hàng")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string tenKH { get; set; }

        public ICollection<Product> Products { get; set; }

        public Customer Customer { get; set; }
        public PurchaseHistory PurchaseHistory { get; set; }
    }
}
