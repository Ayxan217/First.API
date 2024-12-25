using First.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace First.API.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
       
    }
}
