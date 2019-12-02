using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.Models.BindingTargets;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers.Admin
{
    [Route("api/catalogs")]
    [ApiController]
    public class CatalogController: Controller
    {
        private readonly ICatalogRepository _catalogRepo;

        public CatalogController(ICatalogRepository catalogRepo)
        {
            _catalogRepo = catalogRepo;
        }

        [HttpGet]
        public async Task<List<Catalog>> GetAll()
        {
            return await _catalogRepo.GetCatalogs();
        }

        [HttpGet("options")]
        public async Task<List<Catalog>> GetAllOptions([FromHeader] QueryOptions queryOptions)
        {
            return await _catalogRepo.GetCatalogOptions(queryOptions);
        }

        [HttpGet("{id}")]
        public async Task<Catalog> GetOneById(long id)
        {
            return await _catalogRepo.GetCatalog(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CatalogData catalogData)
        {
            if (ModelState.IsValid)
            {
                Catalog catalog = catalogData.Catalog;
                catalog.CreatedAt = DateTime.Now;
                catalog.UpdateAt = DateTime.Now;

                _catalogRepo.AddCatalog(catalog);
                await _catalogRepo.SaveAll();
                return Ok(catalog);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [FromBody] CatalogData catalogData)
        {
            if (ModelState.IsValid)
            {
                Catalog catalog = await _catalogRepo.GetCatalog(id);

                // MAPPER
                catalog.Name = catalogData.Name;
                catalog.ShortDescription = catalogData.ShortDescription;
                catalog.Description = catalogData.Description;
                catalog.Visibility = catalogData.Visibility;
                catalog.UpdateAt = DateTime.Now;

                _catalogRepo.EditCatalog(catalog);
                await _catalogRepo.SaveAll();
                return Ok(catalog);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            _catalogRepo.DeleteCatalog(id);
            await _catalogRepo.SaveAll();
        }
    }
}
