using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Person> GetAll()
        {
            return _context.People
                .Include(x => x.Address)
                .ToList();
        }

        public Person GetById(string personId)
        {
            return _context.People
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Id == personId);
        }

        public void Add(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }

        public void Delete(string personId)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == personId);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
