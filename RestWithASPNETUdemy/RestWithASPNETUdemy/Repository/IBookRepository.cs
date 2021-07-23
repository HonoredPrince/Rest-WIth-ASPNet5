using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository
    {
        Book FindById(long id);
        List<Book> FindAll();
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        bool Exists(long id);
    }
}
