using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.IRepository
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        void EditPost(Post post);
        void DeletePost(long id);
        Task<bool> SaveAll();

        Task<List<Post>> GetPosts();
        Task<List<Post>> GetPostOptions(QueryOptions options);
        Task<Post> GetPost(long id);
    }
}
