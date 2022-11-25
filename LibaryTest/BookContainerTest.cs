using Business;
using Interfaces.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    [TestClass]
   public class BookContainerTest
    {
        
        
        [TestMethod]
        public void AddBookTest()
        {
            //Arrange

            BookContainerMock bookContainerMock = new BookContainerMock();

            BookContainer bookContainer = new BookContainer(bookContainerMock);
            Book book = new Book()
            {
                BookID = 3,
                BookTitle = "Trying",
                ISBN = 1234,
                Author = "Cuneytt",
                Publisher = "Terkeslii",
               
            };

           
            //Act

           bookContainer.AddBook(book);
            var result = bookContainerMock.books.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(book.BookTitle, bookContainerMock.books.Last().BookTitle);
            Assert.AreEqual(book.BookID, bookContainerMock.books.Last().BookID);
            Assert.AreEqual(book.ISBN, bookContainerMock.books.Last().ISBN);
            Assert.AreEqual(book.Author, bookContainerMock.books.Last().Author);
            Assert.AreEqual(book.Publisher, bookContainerMock.books.Last().Publisher);

          



        }
        [TestMethod]
        public void GetBooks()
        {
            //Arrange
            BookContainerMock bookContainerMock = new BookContainerMock();
            BookContainer bookContainer = new BookContainer(bookContainerMock);
           


            //Act

            List<Book> books = bookContainer.GetBooks();


            //Assert
            Assert.AreEqual(bookContainerMock.GetBooks().Count(), books.Count); ;
            Assert.AreEqual(2,books.Count) ;
            Assert.AreEqual(books[0].BookID,bookContainerMock.books[0].BookID);
            Assert.AreEqual(books[0].BookTitle, bookContainerMock.books[0].BookTitle);
            Assert.AreEqual(books[0].Author, bookContainerMock.books[0].Author);
            Assert.AreEqual(books[0].Publisher, bookContainerMock.books[0].Publisher);
            Assert.AreEqual(books[0].ISBN, bookContainerMock.books[0].ISBN);





        }
        [TestMethod]
        public void RemoveBook()
        {
            //Arrange
            BookContainerMock bookContainerMock = new BookContainerMock();
            BookContainer bookContainer = new BookContainer(bookContainerMock);
            var booklist= bookContainer.GetBooks();
            var deletebook = booklist[0];
            //Act
            bookContainer.RemoveBook(deletebook.BookID);
            //Assert
            Assert.AreEqual(1, bookContainerMock.books.Count);
          
          


        }
        [TestMethod]
        public void GetBook()
        {
            //Arrange
            BookContainerMock bookContainerMock = new BookContainerMock();
            BookContainer bookContainer = new BookContainer(bookContainerMock);
            var booklist = bookContainer.GetBooks();
            var getbook= booklist[0];   
            //Act
            bookContainer.GetBook(getbook.BookID);
            //
            Assert.AreEqual(1,getbook.BookID);
            Assert.AreEqual(getbook.BookTitle, bookContainerMock.books[0].BookTitle);


        }

        [TestMethod]
        public void GetBookbytitle()
        {
            //Arrange
            BookContainerMock bookContainerMock = new BookContainerMock();
            BookContainer bookContainer = new BookContainer(bookContainerMock);
            var booklist = bookContainer.GetBooks();
            var searchbook = booklist[1];
            //Act
          var booktitel=  bookContainer.SearchBook(searchbook.BookTitle);
            //Assert
            Assert.AreEqual(1,booktitel.Count);
            

        }

        [TestMethod]
        public void EditBookTest()
        {
            //Arrange

            BookContainerMock bookContainerMock = new BookContainerMock();
           // Book book=new Book(bookContainerMock);
          //  BookContainer bookContainer = new BookContainer(bookContainerMock);
            Book book2 = new Book(bookContainerMock)
            {
                BookID = 1,
                BookTitle = "Trying",
                ISBN = 1234,
                Author = "Cuneytta",
                Publisher = "Terkeslii",

            };


            //Act

            book2.EditBook(book2);
           

            //Assert
           Assert.AreEqual(book2.Author, bookContainerMock.books[1].Author);   
            Assert.AreEqual(book2.BookID, bookContainerMock.books[1].BookID);
          
           
           



        }









    }
}

