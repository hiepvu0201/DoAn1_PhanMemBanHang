using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts): base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetails>().HasKey(table => new
            {
                table.OrdersID,
                table.ProductID
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Catalogs> Catalogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }
    }
}
