using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service
{
    public interface IBookService
    {
        BookVO GetBook(long id);
        List<BookVO> GetBooks();
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
