using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreApp.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
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

        public async Task Add(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string personId)
        {
            var person = await _context.People.FindAsync(personId);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
