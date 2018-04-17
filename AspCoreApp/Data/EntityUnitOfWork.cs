using System.Threading.Tasks;

namespace AspCoreApp.Data
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public EntityUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
