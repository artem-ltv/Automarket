using Automarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }
    }
}
