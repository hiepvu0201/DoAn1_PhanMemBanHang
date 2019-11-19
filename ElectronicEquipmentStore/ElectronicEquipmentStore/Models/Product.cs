using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maSP { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string tenSP { get; set; }

        [DisplayName("Hình ảnh")]
        [Column(TypeName = "image")]
        [Required]
        public string hinhAnh { get; set; }

        [DisplayName("Số lượng sản phẩm")]
        [Column(TypeName = "int")]
        [Required]
        public int soLuongSP { get; set; }

        [DisplayName("Giá khuyến mãi")]
        [Column(TypeName = "int")]
        [Required]
        public int giaKhuyenMai { get; set; }

        [DisplayName("Giá gốc")]
        [Column(TypeName = "int")]
        [Required]
        public int giaGoc { get; set; }

        [DisplayName("Trạng thái")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string trangThai { get; set; }

        [DisplayName("Mã nhà sản xuất")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maNSX { get; set; }

        [DisplayName("Nhóm sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        public string maNSP { get; set; }

        [ForeignKey("maNSP")]
        public virtual ProductGroup ProductGroup { get; set; }

        [DisplayName("Danh mục")]
        [Column(TypeName = "nvarchar(250)")]
        public string maDM { get; set; }

        [ForeignKey("maDM")]
        public virtual Category Category { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
