using JsonPost.Models;

namespace JsonPost.Services
{
    public interface IDbOperations
    {
        bool InsertPosts(Post post);
    }
}
