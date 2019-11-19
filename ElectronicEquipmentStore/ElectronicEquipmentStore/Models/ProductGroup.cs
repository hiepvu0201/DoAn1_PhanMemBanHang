using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class ProductGroup
    {
        [Key]
        [DisplayName("Mã nhóm sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maNSP { get; set; }

        [DisplayName("Tên nhóm sản phẩm")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string tenNSP { get; set; }

        [DisplayName("Số lượng sản phẩm của một nhóm")]
        [Column(TypeName = "int")]
        [Required]
        public int soLuongSpMoiNhom { get; set; }

        [DisplayName("Mã danh mục")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maDM { get; set; }

        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
