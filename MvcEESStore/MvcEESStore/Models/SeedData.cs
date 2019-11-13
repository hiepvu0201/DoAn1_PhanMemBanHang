using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEESStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEESStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcEESStoreContext(serviceProvider.GetRequiredService<DbContextOptions<MvcEESStoreContext>>()))
            {
                // Look for any Category.    
                if (context.Category.Any())
                {
                    return;
                    // DB has been seeded   
                }
                context.Category.AddRange(
                    new Category
                    {
                        maDM = "1",
                        tenDM = "Điện thoại di động",
                        tongSoLuongSP = 5000
                    },
                    new Category
                    {
                        maDM = "2",
                        tenDM = "Laptop",
                        tongSoLuongSP = 3000
                    },
                    new Category
                    {
                        maDM = "3",
                        tenDM = "Máy tính bảng",
                        tongSoLuongSP = 1000
                    },
                    new Category
                    {
                        maDM = "4",
                        tenDM = "Loa",
                        tongSoLuongSP = 5000
                    }
                );

                // Look for any Product Group.    
                if (context.ProductGroup.Any())
                {
                    return;
                    // DB has been seeded   
                }
                context.ProductGroup.AddRange(
                    
                    //Điện thoại di động
                    new ProductGroup
                    {
                        maNSP = "1",
                        tenNSP = "Iphone",
                        soLuongSpMoiNhom = 1000,
                        maDM="1"
                    },
                    new ProductGroup
                    {
                        maNSP = "2",
                        tenNSP = "Samsung",
                        soLuongSpMoiNhom = 1000,
                        maDM = "1"
                    },
                    new ProductGroup
                    {
                        maNSP = "3",
                        tenNSP = "Oppo",
                        soLuongSpMoiNhom = 1000,
                        maDM = "1"
                    },
                    new ProductGroup
                    {
                        maNSP = "4",
                        tenNSP = "Sony",
                        soLuongSpMoiNhom = 1000,
                        maDM = "1"
                    },
                    new ProductGroup
                    {
                        maNSP = "5",
                        tenNSP = "LG",
                        soLuongSpMoiNhom = 1000,
                        maDM = "1"
                    },

                    //Laptop
                    new ProductGroup
                    {
                        maNSP = "6",
                        tenNSP = "Dell",
                        soLuongSpMoiNhom = 1000,
                        maDM = "2"
                    },
                    new ProductGroup
                    {
                        maNSP = "7",
                        tenNSP = "Asus",
                        soLuongSpMoiNhom = 1000,
                        maDM = "2"
                    },
                    new ProductGroup
                    {
                        maNSP = "8",
                        tenNSP = "Lenovo",
                        soLuongSpMoiNhom = 1000,
                        maDM = "2"
                    },

                    //Máy tính bảng
                    new ProductGroup
                    {
                        maNSP = "9",
                        tenNSP = "Ipad",
                        soLuongSpMoiNhom = 500,
                        maDM = "3"
                    },
                    new ProductGroup
                    {
                        maNSP = "10",
                        tenNSP = "Samsung",
                        soLuongSpMoiNhom = 250,
                        maDM = "3"
                    },
                    new ProductGroup
                    {
                        maNSP = "11",
                        tenNSP = "Lenovo",
                        soLuongSpMoiNhom = 250,
                        maDM = "3"
                    },

                    //Loa
                    new ProductGroup
                    {
                        maNSP = "12",
                        tenNSP = "Mozard",
                        soLuongSpMoiNhom = 1500,
                        maDM = "2"
                    },
                    new ProductGroup
                    {
                        maNSP = "13",
                        tenNSP = "Sony",
                        soLuongSpMoiNhom = 2000,
                        maDM = "2"
                    },
                    new ProductGroup
                    {
                        maNSP = "14",
                        tenNSP = "JBL",
                        soLuongSpMoiNhom = 1500,
                        maDM = "2"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
