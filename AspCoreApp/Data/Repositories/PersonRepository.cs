using System;
using System.Collections.Generic;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IList<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(string personId)
        {
            throw new NotImplementedException();
        }

        public void Add(Person person)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(string personId)
        {
            throw new NotImplementedException();
        }
    }
}
