using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusiness(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book GetBook(long id)
        {
            return _repository.FindById(id);
        }

        public List<Book> GetBooks()
        {
            return _repository.FindAll();
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
