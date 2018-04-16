using System;
using System.Collections.Generic;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Address address)
        {
            throw new NotImplementedException();
        }

        public void Update(Address address)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
