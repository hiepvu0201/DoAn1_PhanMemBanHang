using Microsoft.AspNetCore.Mvc;
using store.Helpers;
using store.Models;
using store.Models.BindingTargets;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers.Admin
{
    [Route("api/products")]
    public class ProductController: Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IImageHelper _imageHelper;

        public ProductController(IProductRepository productRepo, IImageHelper imageHelper)
        {
            _productRepo = productRepo;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productRepo.GetProducts();
        }

        [HttpGet("limit")]
        public async Task<List<Product>> GetProductLimit(int limit = 6)
        {
            return await _productRepo.GetProductsLimit(limit);
        }

        [HttpGet("options")]
        public async Task<List<Product>> GetAllOptions([FromHeader] QueryOptions options)
        {
            return await _productRepo.GetProductOptions(options);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetOneById(long id)
        {
            return await _productRepo.GetProduct(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductData productData)
        {
            if (ModelState.IsValid)
            {
                Product product = productData.Product;

                product.CreatedAt = DateTime.Now;
                product.UpdateAt = DateTime.Now;

                // Upload Image
                product.Image = await _imageHelper.UploadImage(productData.Image);

                _productRepo.AddProduct(product);
                await _productRepo.SaveAll();
                return Ok(product);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [FromForm] ProductData productData)
        {
            if (ModelState.IsValid)
            {
                Product product = await _productRepo.GetProduct(id);

                // MAPPER
                product.Name = productData.Name;
                product.ShortDescription = productData.ShortDescription;
                product.Description = productData.Description;
                product.Price = productData.Price;
                product.CatalogId = productData.CatalogId;
                product.UpdateAt = DateTime.Now;

                // Check change image
                if (productData.Image != null)
                {
                    product.Image = await _imageHelper.UploadImage(productData.Image);
                }

                _productRepo.EditProduct(product);
                await _productRepo.SaveAll();
                return Ok(product);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            _productRepo.DeleteProduct(id);
            await _productRepo.SaveAll();
        }
    }
}
