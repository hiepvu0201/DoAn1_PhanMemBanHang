using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.IRepository
{
    public interface ICatalogRepository
    {
        void AddCatalog(Catalog catalog);
        void EditCatalog(Catalog catalog);
        void DeleteCatalog(long id);
        Task<bool> SaveAll();

        Task<List<Catalog>> GetCatalogs();
        Task<List<Catalog>> GetCatalogOptions(QueryOptions options);
        Task<Catalog> GetCatalog(long id);
    }
}
