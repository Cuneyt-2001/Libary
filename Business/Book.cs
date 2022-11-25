using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Book
    {
        private IBookDAL _bookDAL;
        public int BookID { get; set; }
        public int ISBN { get; set; }
        public string BookTitle { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }

        public Book(IBookDAL bookDAL)
        {
            this._bookDAL = bookDAL;
        }

        public Book(BookDTO bookDTO)
        {
            this.BookID = bookDTO.BookID;
            this.ISBN = bookDTO.ISBN;
            this.BookTitle = bookDTO.BookTitle;
            this.Publisher = bookDTO.Publisher;
            this.Author = bookDTO.Author;

        }
        public bool EditBook(Book book)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.BookID =book. BookID;
            bookDTO.ISBN = book.ISBN;
            bookDTO.BookTitle = book.BookTitle;
            bookDTO.Publisher = book.Publisher;
            bookDTO.Author = book.Author;
            return _bookDAL.EditBook(bookDTO);
        }

        public Book()
        {
        }
    }
}
