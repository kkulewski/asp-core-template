using System.Collections.Generic;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories.Abstract
{
    public interface IPersonRepository
    {
        IList<Person> GetAll();
        Person GetById(string personId);
        void Add(Person person);
        void Update(Person person);
        void Delete(string personId);
    }
}
