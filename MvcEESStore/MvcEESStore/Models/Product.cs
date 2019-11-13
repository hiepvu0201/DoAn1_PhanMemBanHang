using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEESStore.Models
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

        [DisplayName("Mã nhóm sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maNSP { get; set; }

        public ProductGroup ProductGroup { get; set; }
        public Receipt Receipt { get; set; }
    }
}
