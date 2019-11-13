using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcEESStore.Models;

namespace MvcEESStore.Data
{
    public class MvcEESStoreContext : DbContext
    {
        public MvcEESStoreContext (DbContextOptions<MvcEESStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEESStore.Models.Category> Category { get; set; }

        public DbSet<MvcEESStore.Models.ProductGroup> ProductGroup { get; set; }

        public DbSet<MvcEESStore.Models.Product> Product { get; set; }

        public DbSet<MvcEESStore.Models.Customer> Customer { get; set; }

        public DbSet<MvcEESStore.Models.Receipt> Receipt { get; set; }

        public DbSet<MvcEESStore.Models.PurchaseHistory> PurchaseHistory { get; set; }
    }
}
