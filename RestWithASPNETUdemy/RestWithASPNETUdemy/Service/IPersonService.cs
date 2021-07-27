using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service
{
    public interface IPersonService
    {
        PersonVO GetPerson(long id);
        List<PersonVO> GetPersons(); 
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
