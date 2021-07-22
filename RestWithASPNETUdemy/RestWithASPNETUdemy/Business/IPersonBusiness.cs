using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        Person GetPerson(long id);
        List<Person> GetPersons(); 
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
