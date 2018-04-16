using Microsoft.EntityFrameworkCore;

namespace AspCoreApp.Data
{
    public class MigrationService
    {
        private readonly AppDbContext _context;

        public MigrationService(AppDbContext context)
        {
            _context = context;
        }

        public void Apply()
        {
            _context.Database.Migrate();
        }
    }
}
