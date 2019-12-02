using Microsoft.EntityFrameworkCore;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCatagory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCatagory(long id)
        {
            _context.Categories.Remove(new Category { Id = id });
        }

        public void EditCatagory(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task<Category> GetCatagory(long id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetCategoryOptions(QueryOptions queryOptions)
        {
            return await QueryOptionsRepository<Category>.CreateAsync(_context.Categories, queryOptions);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
