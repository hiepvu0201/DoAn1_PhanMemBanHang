using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.IRepository
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(long id);
        Task<bool> SaveAll();

        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductOptions(QueryOptions options);
        Task<Product> GetProduct(long id);

        Task<List<Product>> GetProductsLimit(int limit);
    }
}
