using Microsoft.EntityFrameworkCore;
using URL_Shortening.Models;

namespace URL_Shortening.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
