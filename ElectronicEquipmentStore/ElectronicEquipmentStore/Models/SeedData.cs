using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ElectronicEquipmentStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new MvcEESStoreContext(serviceProvider.GetRequiredService<DbContextOptions<MvcEESStoreContext>>()))
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                // Look for any Category.    
                if (!context.Category.Any())
                {
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
                    // return;
                    // DB has been seeded   
                }
                context.SaveChanges();
                // Look for any Product Group.    
                if (!context.ProductGroup.Any())
                {
                    context.ProductGroup.AddRange
                     (
                        //Điện thoại di động
                        new ProductGroup
                        {
                            maNSP = "1",
                            tenNSP = "Iphone",
                            soLuongSpMoiNhom = 1000,
                            maDM = "1"
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
                    //return;
                    // DB has been seeded   
                }
                context.SaveChanges();
                if (!context.Customer.Any())
                {
                    context.Customer.AddRange
                        (
                            new Customer
                            {
                                maKH = "KH001",
                                tenKH = "Hiếu",
                                maThanhVien = "TV001",
                                maGiaoDich = 321
                            },
                             new Customer
                             {
                                 maKH = "KH002",
                                 tenKH = "Hiệp",
                                 maThanhVien = "TV003",
                                 maGiaoDich = 146
                             },
                              new Customer
                              {
                                  maKH = "KH003",
                                  tenKH = "Tiên",
                                  maThanhVien = "TV004",
                                  maGiaoDich = 829
                              },
                               new Customer
                               {
                                   maKH = "KH004",
                                   tenKH = "Bảo",
                                   maThanhVien = "TV004",
                                   maGiaoDich = 164
                               }
                        );
                }
                context.SaveChanges();
                if (!context.PurchaseHistory.Any())
                {
                    context.PurchaseHistory.AddRange
                        (
                            new PurchaseHistory
                            {
                                maPurchaseHistory = "PH001",
                                maHD = 1
                            },
                            new PurchaseHistory
                            {
                                maPurchaseHistory = "PH002",
                                maHD = 2
                            }, new PurchaseHistory
                            {
                                maPurchaseHistory = "PH003",
                                maHD = 3
                            }, new PurchaseHistory
                            {
                                maPurchaseHistory = "PH004",
                                maHD = 4
                            }, new PurchaseHistory
                            {
                                maPurchaseHistory = "PH005",
                                maHD = 5
                            },
                            new PurchaseHistory
                            {
                                maPurchaseHistory = "PH006",
                                maHD = 6
                            },
                            new PurchaseHistory
                            {
                                maPurchaseHistory = "PH007",
                                maHD = 7
                            },
                            new PurchaseHistory
                            {
                                maPurchaseHistory = "PH008",
                                maHD = 8
                            }

                        );
                }

                context.SaveChanges();
                if (!context.Product.Any())
                {
                    context.Product.AddRange(

                       //Điện thoại di động 
                       //Iphone
                       //IP5
                       new Product
                       {
                           maSP = "IP5",
                           tenSP = "Iphone 5",
                           hinhAnh = "aaaaa",
                           soLuongSP = 10,
                           giaKhuyenMai = 3000000,
                           giaGoc = 5000000,
                           trangThai = "Còn hàng",
                           maNSX = "CN",
                           maNSP = "1",
                           maDM = "1"
                       },
                        //IP6
                        new Product
                        {
                            maNSP = "1",
                            maSP = "IP6",
                            tenSP = "Iphone 6",
                            hinhAnh = " aaaa",
                            soLuongSP = 10,
                            giaKhuyenMai = 6000000,
                            giaGoc = 8000000,
                            trangThai = "Còn hàng",
                            maNSX = "CN",
                            maDM = "1"
                        },
                         new Product
                         {
                             maNSP = "1",
                             maSP = "IP7",
                             tenSP = "Iphone 7",
                             hinhAnh = " aaaa",
                             soLuongSP = 10,
                             giaKhuyenMai = 10000000,
                             giaGoc = 11000000,
                             trangThai = "Còn hàng",
                             maNSX = "CN",
                             maDM="1"
                         },

                        //Laptop Asus
                        new Product
                        {
                            maNSP = "7",
                            maSP = "A7",
                            tenSP = "ROG GL553",
                            hinhAnh = " aaaa",
                            soLuongSP = 10,
                            giaKhuyenMai = 25000000,
                            giaGoc = 27000000,
                            trangThai = "Còn hàng",
                            maNSX = "CN",
                            maDM = "1"
                        }
                       //ROG                    
                       );
                    //  return;
                    // DB has been seeded   
                }
                context.SaveChanges();
                if (!context.Receipt.Any())
                {
                    context.AddRange(
                    new Receipt
                    {
                        maHD = "1",
                        maSP = "SGN8",
                        ngayGiaoDich = new DateTime(2019, 11, 14),
                        soLuongSP = 1,
                        donGia = 8000000,
                        thanhTieh = 8000000,
                        tongTien = 8000000,
                        maKH = "KH001",
                        tenKH = "Hiếu"
                    },
                     new Receipt
                     {
                         maHD = "2",
                         maSP = "IP7",
                         ngayGiaoDich = new DateTime(2019, 11, 14),
                         soLuongSP = 1,
                         donGia = 7000000,
                         thanhTieh = 7000000,
                         tongTien = 7000000,
                         maKH = "KH002",
                         tenKH = "Hiệp"
                     }
                     );
                }
                context.SaveChanges();

            }
        }
    }
}
