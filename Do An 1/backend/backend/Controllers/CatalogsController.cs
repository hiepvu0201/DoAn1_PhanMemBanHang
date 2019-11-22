using backend.Models;
using backend.Models.BindingTargets;
using backend.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backend.Controllers
{
    [Route("api/catalogs")]
    [ApiController]
    public class CatalogsController: Controller
    {
        private DataContext context;
        public CatalogsController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Catalogs GetCatalogs(int id)
        {
            return context.Catalogs.Find(id);
        }

        [HttpGet]
        public List<Catalogs> GetAllCatalogs()
        {
            return context.Catalogs.Where(c => c.Visibility == true).ToList();
        }

        [HttpGet("options")]
        public List<Catalogs> GetAllCatalogs(int currentPage, int pageSize, string sortOrderName, string sortOrder, string searchPropertyName, string searchValue)
        {
            QueryOptionsModel queryOptions = new QueryOptionsModel
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                SortOrderName = sortOrderName,
                SortOrder = sortOrder,
                SearchPropertyName = searchPropertyName,
                SearchValue = searchValue
            };

            return new QueryOptionsRepository<Catalogs>(context.Catalogs, queryOptions);
        }

        [HttpPost]
        public IActionResult CreateCatalogs([FromBody] CatalogsData cdata)
        {
            if (ModelState.IsValid)
            {
                Catalogs c = cdata.Catalogs;
                context.Add(c);
                context.SaveChanges();
                return Ok(c.Id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceCatalogs(int id, [FromBody] CatalogsData cdata)
        {
            if (ModelState.IsValid)
            {
                Catalogs c = cdata.Catalogs;
                c.Id = id;
                context.Update(c);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteCatalogs(int id)
        {
            context.Catalogs.Remove(new Catalogs { Id = id });
            context.SaveChanges();
        }
    }
}
