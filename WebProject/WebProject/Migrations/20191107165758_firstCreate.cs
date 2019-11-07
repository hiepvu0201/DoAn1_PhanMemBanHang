using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class firstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    maDM = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenDM = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tongSoLuongSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.maDM);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistories",
                columns: table => new
                {
                    maPurchaseHistory = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    maHD = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistories", x => x.maPurchaseHistory);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    maNSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    tenNSP = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    soLuongSpMoiNhom = table.Column<int>(type: "int", nullable: false),
                    maDM = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.maNSP);
                    table.ForeignKey(
                        name: "FK_ProductGroups_Categories_maDM",
                        column: x => x.maDM,
                        principalTable: "Categories",
                        principalColumn: "maDM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
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
                    table.PrimaryKey("PK_Customers", x => x.maKH);
                    table.ForeignKey(
                        name: "FK_Customers_PurchaseHistories_PurchaseHistorymaPurchaseHistory",
                        column: x => x.PurchaseHistorymaPurchaseHistory,
                        principalTable: "PurchaseHistories",
                        principalColumn: "maPurchaseHistory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
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
                    tenKH = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.maHD);
                    table.ForeignKey(
                        name: "FK_Receipts_PurchaseHistories_maHD",
                        column: x => x.maHD,
                        principalTable: "PurchaseHistories",
                        principalColumn: "maPurchaseHistory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipts_Customers_maKH",
                        column: x => x.maKH,
                        principalTable: "Customers",
                        principalColumn: "maKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                    maNSP = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.maSP);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_maNSP",
                        column: x => x.maNSP,
                        principalTable: "ProductGroups",
                        principalColumn: "maNSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Receipts_maSP",
                        column: x => x.maSP,
                        principalTable: "Receipts",
                        principalColumn: "maHD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PurchaseHistorymaPurchaseHistory",
                table: "Customers",
                column: "PurchaseHistorymaPurchaseHistory");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_maDM",
                table: "ProductGroups",
                column: "maDM");

            migrationBuilder.CreateIndex(
                name: "IX_Products_maNSP",
                table: "Products",
                column: "maNSP");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_maKH",
                table: "Receipts",
                column: "maKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PurchaseHistories");
        }
    }
}
