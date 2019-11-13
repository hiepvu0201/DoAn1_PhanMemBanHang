using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcEESStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    maDM = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenDM = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tongSoLuongSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.maDM);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistory",
                columns: table => new
                {
                    maPurchaseHistory = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maHD = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistory", x => x.maPurchaseHistory);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    maNSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenNSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    soLuongSpMoiNhom = table.Column<int>(type: "int", nullable: false),
                    maDM = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CategorymaDM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.maNSP);
                    table.ForeignKey(
                        name: "FK_ProductGroup_Category_CategorymaDM",
                        column: x => x.CategorymaDM,
                        principalTable: "Category",
                        principalColumn: "maDM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    maKH = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenKH = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maThanhVien = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maGiaoDich = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PurchaseHistorymaPurchaseHistory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.maKH);
                    table.ForeignKey(
                        name: "FK_Customer_PurchaseHistory_PurchaseHistorymaPurchaseHistory",
                        column: x => x.PurchaseHistorymaPurchaseHistory,
                        principalTable: "PurchaseHistory",
                        principalColumn: "maPurchaseHistory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    maHD = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ngayGiaoDich = table.Column<DateTime>(type: "datetime", nullable: false),
                    soLuongSP = table.Column<int>(type: "int", nullable: false),
                    donGia = table.Column<int>(type: "int", nullable: false),
                    thanhTieh = table.Column<int>(type: "int", nullable: false),
                    tongTien = table.Column<int>(type: "int", nullable: false),
                    maKH = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenKH = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CustomermaKH = table.Column<string>(nullable: true),
                    PurchaseHistorymaPurchaseHistory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.maHD);
                    table.ForeignKey(
                        name: "FK_Receipt_Customer_CustomermaKH",
                        column: x => x.CustomermaKH,
                        principalTable: "Customer",
                        principalColumn: "maKH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_PurchaseHistory_PurchaseHistorymaPurchaseHistory",
                        column: x => x.PurchaseHistorymaPurchaseHistory,
                        principalTable: "PurchaseHistory",
                        principalColumn: "maPurchaseHistory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    maSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    hinhAnh = table.Column<byte[]>(type: "image", nullable: false),
                    soLuongSP = table.Column<int>(type: "int", nullable: false),
                    giaKhuyenMai = table.Column<int>(type: "int", nullable: false),
                    giaGoc = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maNSX = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maNSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ProductGroupmaNSP = table.Column<string>(nullable: true),
                    ReceiptmaHD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.maSP);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupmaNSP",
                        column: x => x.ProductGroupmaNSP,
                        principalTable: "ProductGroup",
                        principalColumn: "maNSP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Receipt_ReceiptmaHD",
                        column: x => x.ReceiptmaHD,
                        principalTable: "Receipt",
                        principalColumn: "maHD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PurchaseHistorymaPurchaseHistory",
                table: "Customer",
                column: "PurchaseHistorymaPurchaseHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupmaNSP",
                table: "Product",
                column: "ProductGroupmaNSP");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ReceiptmaHD",
                table: "Product",
                column: "ReceiptmaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_CategorymaDM",
                table: "ProductGroup",
                column: "CategorymaDM");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CustomermaKH",
                table: "Receipt",
                column: "CustomermaKH");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PurchaseHistorymaPurchaseHistory",
                table: "Receipt",
                column: "PurchaseHistorymaPurchaseHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PurchaseHistory");
        }
    }
}
