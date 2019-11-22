using backend.Helpers;
using backend.Models;
using backend.Models.BindingTargets;
using backend.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController: Controller
    {
        private readonly DataContext context;
        private readonly IImageHelper _imageHelper;
        public PostsController(DataContext ctx, IImageHelper imageHelper)
        {
            context = ctx;
            _imageHelper = imageHelper;
        }
        [HttpGet("{id}")]
        public Posts GetPosts(int id)
        {
            return context.Posts.Include(p => p.Categories).FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        public List<Posts> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        [HttpGet("options")]
        public List<Posts> GetAllPosts(int currentPage, int pageSize, string sortOrderName, string sortOrder, string searchPropertyName, string searchValue)
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

            return new QueryOptionsRepository<Posts>(context.Posts, queryOptions);
        }

        [HttpGet("count")]
        public int GetCountPosts()
        {
            return context.Posts.Count();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosts([FromForm] PostsData pdata)
        {
            if (ModelState.IsValid)
            {
                Posts p = pdata.Posts;
                p.CreatedAt = DateTime.Now;
                p.UpdateAt = DateTime.Now;

                if (p.Categories != null && p.Categories.Id != 0)
                {
                    context.Attach(p.Categories);
                }

                // Upload Image AND get url image
                p.Image = await _imageHelper.UploadImage(pdata.Image);

                context.Add(p);
                context.SaveChanges();
                return Ok(p.Id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplacePosts(int id, [FromBody] PostsData pdata)
        {
            if (ModelState.IsValid)
            {
                Posts p = pdata.Posts;
                p.Id = id;
                p.UpdateAt = DateTime.Now;
                if (p.Categories != null && p.Categories.Id != 0)
                {
                    context.Attach(p.Categories);
                }
                context.Update<Posts>(p);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeletePosts(int id)
        {
            context.Posts.Remove(new Posts { Id = id });
            context.SaveChanges();
        }
    }
}
