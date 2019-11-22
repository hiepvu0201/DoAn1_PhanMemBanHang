using backend.Models;
using backend.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController: Controller
    {
        private DataContext _context;
        public CustomerController(DataContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        [HttpGet]
        public List<Customer> GetAllCustomers(int currentPage, int pageSize, string sortOrderName, string sortOrder, string searchPropertyName, string searchValue)
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

            return new QueryOptionsRepository<Customer>(_context.Customers, queryOptions);
        }

        //[HttpPost]
        //public IActionResult CreateCatalogs([FromBody] CatalogsData cdata)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Catalogs c = cdata.Catalogs;
        //        context.Add(c);
        //        context.SaveChanges();
        //        return Ok(c.Id);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult ReplaceCatalogs(int id, [FromBody] CatalogsData cdata)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Catalogs c = cdata.Catalogs;
        //        c.Id = id;
        //        context.Update(c);
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public void DeleteCatalogs(int id)
        //{
        //    context.Catalogs.Remove(new Catalogs { Id = id });
        //    context.SaveChanges();
        //}
    }
}
