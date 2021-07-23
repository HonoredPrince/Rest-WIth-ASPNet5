using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service
{
    public interface IPersonService
    {
        Person GetPerson(long id);
        List<Person> GetPersons(); 
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
