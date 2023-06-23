using ContctosApi4.Models;
using Microsoft.EntityFrameworkCore;

namespace ContctosApi4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
                
        }

        public DbSet<Persona> personas => Set<Persona>();
    }
}
