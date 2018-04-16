using AspCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
