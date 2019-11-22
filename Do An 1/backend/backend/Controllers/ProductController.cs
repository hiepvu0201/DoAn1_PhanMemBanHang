using backend.Helpers;
using backend.Models;
using backend.Models.BindingTargets;
using backend.Models.IRepository;
using backend.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController: Controller
    {
        private readonly IProductRepository _repo;
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;

        public ProductController(IProductRepository repo, IImageHelper imageHelper, DataContext context)
        {
            _repo = repo;
            _imageHelper = imageHelper;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _repo.GetProduct(id);
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("count")]
        public int GetCountProducts()
        {
            return _context.Products.Count<Product>();
        }

        [HttpGet("options")]
        public List<Product> GetProducts(int currentPage, int pageSize, string sortOrderName, string sortOrder, string searchPropertyName, string searchValue)
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

            return _repo.GetProducts(queryOptions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductsData pdata)
        {
            if (ModelState.IsValid)
            {
                Product p = pdata.Products;
                
                // Upload Image AND get url image
                p.Image = await _imageHelper.UploadImage(pdata.Image);
                await _repo.Add(p);
                return Ok(p);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReplaceProduct(int id, [FromForm] ProductsData pdata)
        {
            if (ModelState.IsValid)
            {
                Product p = pdata.Products;
                p.Id = id;
                //if (p.Catalogs != null && p.Catalogs.Id != 0)
                //{
                //    context.Attach(p.Catalogs);
                //}
                //context.Update<Product>(p);
                //context.SaveChanges();
                return Ok(await _repo.Edit(p));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //context.Products.Remove(new Product { Id = id });
            //context.SaveChanges();
            await _repo.Delete(id);
            return Ok(id);
        }
    }
}
