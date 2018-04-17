using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Entity
{
    /// <summary>
    /// Entity Framework implementation of address repository.
    /// </summary>
    public class EntityAddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public EntityAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Address>> GetAll()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetById(string addressId)
        {
            return await _context.Addresses.FindAsync(addressId);
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
        }
    }
}
