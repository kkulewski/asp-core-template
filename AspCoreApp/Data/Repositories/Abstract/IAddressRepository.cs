using System.Collections.Generic;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories.Abstract
{
    public interface IAddressRepository
    {
        IList<Address> GetAll();
        Address GetById(string id);
        void Add(Address address);
        void Update(Address address);
        void Delete(string id);
    }
}
