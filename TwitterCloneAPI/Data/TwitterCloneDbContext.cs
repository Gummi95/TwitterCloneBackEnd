using Microsoft.EntityFrameworkCore;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.Data
{
    public class TwitterCloneDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TwitterDb");
        }
    }
}
