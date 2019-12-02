using Microsoft.EntityFrameworkCore;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            if(product.Catalog != null && product.Catalog.Id != 0)
            {
                _context.Attach(product.Catalog);
            }

            _context.Products.Add(product);
        }

        public void DeleteProduct(long id)
        {
            _context.Products.Remove(new Product { Id = id });
        }

        public void EditProduct(Product product)
        {
            if (product.Catalog != null && product.Catalog.Id != 0)
            {
                _context.Attach(product.Catalog);
            }

            _context.Products.Update(product);
        }

        public async Task<Product> GetProduct(long id)
        {
            return await _context.Products.Include(p => p.Catalog).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProductOptions(QueryOptions options)
        {
            return await QueryOptionsRepository<Product>.CreateAsync(_context.Products.Include(p => p.Catalog), options);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.Include(p => p.Catalog).ToListAsync();
        }

        public async Task<List<Product>> GetProductsLimit(int limit)
        {
            return await _context.Products.Include(p=>p.Catalog).Take(limit).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
