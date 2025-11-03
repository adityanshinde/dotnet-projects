using Microsoft.EntityFrameworkCore;
using ZestromAssignment.Models;

namespace ZestromAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
