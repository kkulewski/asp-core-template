using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreApp.Data.Repositories.Entity
{
    /// <summary>
    /// Entity Framework implementation of person repository.
    /// </summary>
    public class EntityPersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public EntityPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Person>> GetAll()
        {
            return await _context.People
                .Include(x => x.Address)
                .ToListAsync();
        }

        public async Task<Person> GetById(string personId)
        {
            return await _context.People
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == personId);
        }

        public void Add(Person person)
        {
            _context.People.Add(person);
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
        }

        public void Delete(Person person)
        {
            _context.People.Remove(person);
        }
    }
}
