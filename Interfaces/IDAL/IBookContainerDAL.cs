using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IBookContainerDAL
    {
        List<BookDTO> GetBooks();
        BookDTO GetBook(int bookid);
        int AddBook(BookDTO book);
        bool RemoveBook(int bookid);
        List<BookDTO> SearchBook(string Booktitle);
        List<CategoryDTO> GetCategory();
        //BookDTO SearchBook(string Booktitle);


    }
}
