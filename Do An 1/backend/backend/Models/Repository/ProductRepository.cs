using backend.Helpers;
using backend.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly DataContext _context;

        public ProductRepository(DataContext context, IImageHelper imageHelper)
        {
            _context = context;
        }

        // GET LIST PRODUCT
        public List<Product> GetProducts(QueryOptionsModel queryOptions)
        {
            return new QueryOptionsRepository<Product>(_context.Products, queryOptions);
        }

        // GET PRODUCT BY ID
        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Catalogs).FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        // ADD PRODUCT
        public async Task<Product> Add(Product product)
        {
            if (product.Catalogs != null && product.Catalogs.Id != 0)
            {
                _context.Attach(product.Catalogs);
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        // EDIT PRODUCT
        public async Task<Product> Edit(Product product)
        {
            if (product.Catalogs != null && product.Catalogs.Id != 0)
            {
                _context.Attach(product.Catalogs);
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        // DELETE PRODUCT
        public async Task<int> Delete(int id)
        {
            _context.Products.Remove(new Product { Id = id });
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
