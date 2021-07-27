using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service
{
    public interface IPersonService
    {
        PersonVO GetPerson(long id);
        List<PersonVO> GetPersonsByName(string firstName, string lastName);
        List<PersonVO> GetPersons();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
