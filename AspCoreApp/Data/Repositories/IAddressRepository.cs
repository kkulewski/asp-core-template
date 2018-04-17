using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories
{
    public interface IAddressRepository
    {
        Task<IList<Address>> GetAll();
        Task<Address> GetById(string addressId);
        void Add(Address address);
        void Update(Address address);
        void Delete(Address address);
    }
}
