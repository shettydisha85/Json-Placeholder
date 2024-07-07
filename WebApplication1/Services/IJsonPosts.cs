using JsonPost.Models;

namespace JsonPost.Services
{
    public interface IAddJsonPosts
    {
        Task<IEnumerable<Post>> GetAllPosts();
    }
}
