using Microsoft.EntityFrameworkCore;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Entity
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
