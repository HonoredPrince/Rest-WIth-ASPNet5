using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        
        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person GetPerson(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> GetPersons()
        {
            return _repository.FindAll();
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
