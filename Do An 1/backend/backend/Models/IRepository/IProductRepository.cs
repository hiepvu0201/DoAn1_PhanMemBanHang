using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetProducts(QueryOptionsModel queryOptions);
        Task<Product> GetProduct(int id);
        Task<Product> Add(Product product);
        Task<Product> Edit(Product product);
        Task<int> Delete(int id);
    }
}
