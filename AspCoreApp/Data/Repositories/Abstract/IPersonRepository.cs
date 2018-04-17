using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories.Abstract
{
    public interface IPersonRepository
    {
        Task<IList<Person>> GetAll();
        Task<Person> GetById(string personId);
        Task Add(Person person);
        Task Update(Person person);
        Task Delete(string personId);
    }
}
