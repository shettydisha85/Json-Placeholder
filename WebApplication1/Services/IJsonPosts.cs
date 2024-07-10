using JsonPost.Models;

namespace JsonPost.Services
{
    public interface IJsonPosts
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<string> GetCatFacts();
    }
}
