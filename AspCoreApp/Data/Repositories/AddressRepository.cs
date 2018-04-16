using System;
using System.Collections.Generic;
using System.Linq;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(string addressId)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == addressId);
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void Delete(string addressId)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == addressId);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }
            _context.SaveChanges();
        }
    }
}
