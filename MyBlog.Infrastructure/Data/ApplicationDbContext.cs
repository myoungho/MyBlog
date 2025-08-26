using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;

namespace MyBlog.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
    }
}
