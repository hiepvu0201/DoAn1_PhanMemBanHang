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
    [Route("api/posts")]
    [ApiController]
    public class PostController: Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly IImageHelper _imageHelper;

        public PostController(IPostRepository postRepo, IImageHelper imageHelper)
        {
            _postRepo = postRepo;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<List<Post>> GetAll()
        {
            return await _postRepo.GetPosts();
        }

        [HttpGet("options")]
        public async Task<List<Post>> GetAllOptions([FromHeader] QueryOptions options)
        {
            return await _postRepo.GetPostOptions(options);
        }

        [HttpGet("{id}")]
        public async Task<Post> GetOneById(long id)
        {
            return await _postRepo.GetPost(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PostData postData)
        {
            if (ModelState.IsValid)
            {
                Post post = postData.Post;
                post.CreatedAt = DateTime.Now;
                post.UpdateAt = DateTime.Now;

                // Upload Image
                post.Image = await _imageHelper.UploadImage(postData.Image);

                _postRepo.AddPost(post);
                await _postRepo.SaveAll();
                return Ok(post);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [FromForm] PostData postData)
        {
            if (ModelState.IsValid)
            {
                Post post = await _postRepo.GetPost(id);

                post.Name = postData.Name;
                post.ShortDescription = postData.ShortDescription;
                post.Content = postData.Content;
                post.CategoryId = postData.CategoryId;
                post.UpdateAt = DateTime.Now;

                // Check change image
                if (postData.Image != null)
                {
                    post.Image = await _imageHelper.UploadImage(postData.Image);
                }

                _postRepo.EditPost(post);
                await _postRepo.SaveAll();
                return Ok(post);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            _postRepo.DeletePost(id);
            await _postRepo.SaveAll();
        }
    }
}
