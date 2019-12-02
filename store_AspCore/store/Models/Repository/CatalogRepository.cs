using Microsoft.EntityFrameworkCore;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly DataContext _context;
        public CatalogRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCatalog(Catalog catalog)
        {
            _context.Catalogs.Add(catalog);
        }

        public void DeleteCatalog(long id)
        {
            _context.Catalogs.Remove(new Catalog { Id = id });
        }

        public void EditCatalog(Catalog catalog)
        {
            _context.Catalogs.Update(catalog);
        }

        public async Task<Catalog> GetCatalog(long id)
        {
            return await _context.Catalogs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Catalog>> GetCatalogOptions(QueryOptions options)
        {
            return await QueryOptionsRepository<Catalog>.CreateAsync(_context.Catalogs, options);
        }

        public async Task<List<Catalog>> GetCatalogs()
        {
            return await _context.Catalogs.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
