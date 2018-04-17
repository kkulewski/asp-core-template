using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreApp.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
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

        public async Task Add(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string addressId)
        {
            var address = await _context.Addresses.FindAsync(addressId);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
