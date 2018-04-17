using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories
{
    public interface IPersonRepository
    {
        Task<IList<Person>> GetAll();
        Task<Person> GetById(string personId);
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}
