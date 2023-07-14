using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> option) : base(option)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}