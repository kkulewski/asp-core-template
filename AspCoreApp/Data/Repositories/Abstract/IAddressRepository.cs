using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories.Abstract
{
    public interface IAddressRepository
    {
        Task<IList<Address>> GetAll();
        Task<Address> GetById(string addressId);
        Task Add(Address address);
        Task Update(Address address);
        Task Delete(string addressId);
    }
}
