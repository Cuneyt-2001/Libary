using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    public class BookContainerMock : IBookContainerDAL,IBookDAL
    {

        public List<BookDTO> books = new List<BookDTO>();
        public BookContainerMock() 
        {
            BookDTO book1 = new BookDTO()
            {
                BookID = 1,
                BookTitle = "Try",
                ISBN = 1234567,
                Author = "Cuneyt",
                Publisher = "Terkesli",
                Visibility = true

            };
            BookDTO book2 = new BookDTO()
            {
                BookID = 2,
                BookTitle = "Trying",
                ISBN = 123456789,
                Author = "Cuneytt",
                Publisher = "Terkeslii",
                Visibility = true

            };
            books.Add(book1);   
            books.Add(book2);


        }
        public int AddBook(BookDTO book)
        {
            books.Add(book);
            return books.Count;
        }

        public bool EditBook(BookDTO book)
        {
            BookDTO bookdto = books.First(x => x.BookID == book.BookID);
            books.Remove(bookdto);
            books.Add(book);
            return true;
            //if (book != null&&book.BookTitle== "Trying"&&book.Author== "Cuneytta")
            //{
            //    return true;
            //}
            //return false;   
        }

        public BookDTO GetBook(int bookid)
        {
            BookDTO booktoget=books.Find(x => x.BookID == bookid);  
            return booktoget;
        }

        public List<BookDTO> GetBooks()
        {
            return books;
        }

        public List<CategoryDTO> GetCategory()
        {
            throw new NotImplementedException();
        }

        public bool RemoveBook(int bookid)
        {
            
            
            BookDTO bookToDelete = books.Find(x => x.BookID == bookid);
            books.Remove(bookToDelete);

            return true;
        }

        public List<BookDTO> SearchBook(string Booktitle)
        {
            List<BookDTO> booktosearch = books.FindAll(x => x.BookTitle == Booktitle);

            return booktosearch;
           
        }
    }
}
