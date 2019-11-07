using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class EESStoreContext:DbContext
    {
        private Func<DbContextOptions<EESStoreContext>> getRequiredService;
        public EESStoreContext(DbContextOptions<EESStoreContext> options) : base(options)
        {

        }

        public EESStoreContext(Func<DbContextOptions<EESStoreContext>> getRequiredService)
        {
            this.getRequiredService = getRequiredService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>()
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.ProductGroups)
                .HasForeignKey(s => s.maDM);
            modelBuilder.Entity<Product>()
                .HasOne<ProductGroup>(s => s.ProductGroup)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.maNSP);
            modelBuilder.Entity<Product>()
                .HasOne<Receipt>(s => s.Receipt)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.maSP);
            modelBuilder.Entity<Receipt>()
                .HasOne<Customer>(s => s.Customer)
                .WithMany(g => g.Receipts)
                .HasForeignKey(g => g.maKH);
            modelBuilder.Entity<Receipt>()
                .HasOne<purchaseHistory>(s => s.PurchaseHistory)
                .WithMany(g => g.Receipts)
                .HasForeignKey(g => g.maHD);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<purchaseHistory> PurchaseHistories { get; set; }
    }
}
