using JsonPost.Data;
using JsonPost.Models;

namespace JsonPost.Services
{
    public class DbOperations : IDbOperations
    {
        private readonly PostDbContext _dbContext;
        public DbOperations(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool InsertPosts(Post post)
        {
            try
            {
                _dbContext.Add(post);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
