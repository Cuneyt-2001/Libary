using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BookContainer
    {
       
        private IBookContainerDAL _bookContainerDAL;

        public BookContainer(IBookContainerDAL bookContainerDAL)
        {
            this._bookContainerDAL = bookContainerDAL;
        }
        public List<Book> GetBooks()
        {
            List<BookDTO> bookdtos = _bookContainerDAL.GetBooks();
            List<Book> booklist = new List<Book>();
            foreach (BookDTO dto in bookdtos)
            {
                booklist.Add(new Book(dto));
            }
            return booklist;
        }
        
        public int AddBook(Book book)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.BookID = book.BookID;
            bookDTO.ISBN = book.ISBN;
            bookDTO.Author = book.Author;
            bookDTO.Publisher = book.Publisher;
            bookDTO.BookTitle = book.BookTitle;
            return _bookContainerDAL.AddBook(bookDTO);

        }
        public bool RemoveBook(int bookid)
        {
            return _bookContainerDAL.RemoveBook(bookid);
        }
        public Book GetBook(int BookID)
        {
            BookDTO bookdto = _bookContainerDAL.GetBook(BookID);
            return new Book(bookdto);

        }
        public List<Category> GetCategories()
        {
            List<CategoryDTO> categorydtos = _bookContainerDAL.GetCategory();
            List<Category> categorylist = new List<Category>();
            foreach (CategoryDTO categorydto in categorydtos)
            {
                categorylist.Add(new Category(categorydto));
            }
            return categorylist;


        }

  
    public List<Book> SearchBook(string Booktitle)
    {
        List<BookDTO> bookdtos = _bookContainerDAL.SearchBook(Booktitle);
        List<Book> booklist = new List<Book>();
        foreach (BookDTO dto in bookdtos)
        {
            booklist.Add(new Book(dto));
        }
        return booklist;
    }


}
}
