using Microsoft.EntityFrameworkCore;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void DeletePost(long id)
        {
            _context.Posts.Remove(new Post { Id = id });
        }

        public void EditPost(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task<Post> GetPost(long id)
        {
            return await _context.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Post>> GetPostOptions(QueryOptions options)
        {
            return await QueryOptionsRepository<Post>.CreateAsync(_context.Posts.Include(p => p.Category), options);
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.Include(p => p.Category).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
