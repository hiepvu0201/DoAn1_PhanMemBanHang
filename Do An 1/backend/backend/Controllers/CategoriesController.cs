using backend.Models;
using backend.Models.BindingTargets;
using backend.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private DataContext context;

        public CategoriesController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Categories GetCategories(int id)
        {
            return context.Categories.Find(id);
        }

        [HttpGet]
        public List<Categories> GetAllCategories(int currentPage, int pageSize, string sortOrderName, string sortOrder, string searchPropertyName, string searchValue)
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
            return new QueryOptionsRepository<Categories>(context.Categories, queryOptions);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CategoriesData cdata)
        {
            if (ModelState.IsValid)
            {
                Categories c = cdata.Categories;
                c.CreatedAt = DateTime.Now;
                c.UpdateAt = DateTime.Now;
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
        public IActionResult ReplaceProduct(int id, [FromBody] CategoriesData cdata)
        {
            if (ModelState.IsValid)
            {
                Categories c = cdata.Categories;
                c.UpdateAt = DateTime.Now;
                c.Id = id;
                context.Update<Categories>(c);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            context.Categories.Remove(new Categories { Id = id });
            context.SaveChanges();
        }
    }
}
