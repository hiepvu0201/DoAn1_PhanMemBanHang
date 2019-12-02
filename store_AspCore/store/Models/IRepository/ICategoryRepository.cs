using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.IRepository
{
    public interface ICategoryRepository
    {
        void AddCatagory(Category category);
        void EditCatagory(Category category);
        void DeleteCatagory(long id);
        Task<bool> SaveAll();

        Task<List<Category>> GetCategories();
        Task<Category> GetCatagory(long id);
        Task<List<Category>> GetCategoryOptions(QueryOptions queryOptions);
    }
}
