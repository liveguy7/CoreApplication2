using CoreApplication2.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CoreApplication2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 
        public DbSet<Car> carTarget { get; set; }
        public DbSet<Category> categoryTarget { get; set; }
        

    }
}



