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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _catgoryRepo;

        public CategoryController(ICategoryRepository catgoryRepo)
        {
            _catgoryRepo = catgoryRepo;
        }

        [HttpGet]
        public async Task<List<Category>> GetAll()
        {
            return await _catgoryRepo.GetCategories();
        }

        [HttpGet("options")]
        public async Task<List<Category>> GetAllOptions([FromHeader] QueryOptions queryOptions)
        {
            return await _catgoryRepo.GetCategoryOptions(queryOptions);
        }


        [HttpGet("{id}")]
        public async Task<Category> GetOneById(long id)
        {
            return await _catgoryRepo.GetCatagory(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryData categoryData)
        {
            if (ModelState.IsValid)
            {
                Category category = categoryData.Category;
                category.CreatedAt = DateTime.Now;
                category.UpdateAt = DateTime.Now;

                _catgoryRepo.AddCatagory(category);
                await _catgoryRepo.SaveAll();
                return Ok(category);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [FromBody] CategoryData categoryData)
        {
            if (ModelState.IsValid)
            {
                Category category = await _catgoryRepo.GetCatagory(id);

                // MAPPER
                category.Name = categoryData.Name;
                category.ShortDescription = categoryData.ShortDescription;
                category.Description = categoryData.Description;
                category.Visibility = categoryData.Visibility;
                category.UpdateAt = DateTime.Now;

                _catgoryRepo.EditCatagory(category);
                await _catgoryRepo.SaveAll();
                return Ok(category);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            _catgoryRepo.DeleteCatagory(id);
            await _catgoryRepo.SaveAll();
        }
    }
}
