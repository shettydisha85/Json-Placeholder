using JsonPost.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonPost.Data
{
    public class PostDbContext : DbContext
    {

        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) 
        {
        }

        public DbSet<Post> Posts { get; set; }

    }
}
