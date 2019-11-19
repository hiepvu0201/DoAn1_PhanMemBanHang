using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicEquipmentStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    maNSP = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    maDM = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ReceiptmaHD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.maSP);
                    table.ForeignKey(
                        name: "FK_Product_Receipt_ReceiptmaHD",
                        column: x => x.ReceiptmaHD,
                        principalTable: "Receipt",
                        principalColumn: "maHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Category_maDM",
                        column: x => x.maDM,
                        principalTable: "Category",
                        principalColumn: "maDM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_maNSP",
                        column: x => x.maNSP,
                        principalTable: "ProductGroup",
                        principalColumn: "maNSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PurchaseHistorymaPurchaseHistory",
                table: "Customer",
                column: "PurchaseHistorymaPurchaseHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ReceiptmaHD",
                table: "Product",
                column: "ReceiptmaHD");

            migrationBuilder.CreateIndex(
                name: "IX_Product_maDM",
                table: "Product",
                column: "maDM");

            migrationBuilder.CreateIndex(
                name: "IX_Product_maNSP",
                table: "Product",
                column: "maNSP");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "PurchaseHistory");
        }
    }
}
