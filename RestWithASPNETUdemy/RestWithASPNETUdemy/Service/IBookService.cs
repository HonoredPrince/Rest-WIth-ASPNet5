using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service
{
    public interface IBookService
    {
        Book GetBook(long id);
        List<Book> GetBooks();
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
