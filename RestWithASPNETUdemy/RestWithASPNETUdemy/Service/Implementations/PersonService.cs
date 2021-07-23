using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        
        public PersonService(IRepository<Person> repository)
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