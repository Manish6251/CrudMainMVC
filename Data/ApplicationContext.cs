using Microsoft.EntityFrameworkCore;
using CrudMAin.Models;

namespace CrudMAin.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; }
    }
}
