using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Mã danh mục")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string maDM { get; set; }

        [DisplayName("Tên danh mục")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string tenDM { get; set; }

        [DisplayName("Tổng số lượng sản phẩm")]
        [Column(TypeName = "int")]
        [Required]
        public int tongSoLuongSP { get; set; }

        public ICollection<ProductGroup> ProductGroups { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
