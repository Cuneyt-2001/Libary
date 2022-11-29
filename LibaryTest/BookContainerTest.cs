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
            Assert.AreEqual(2, books.Count);
            for (int i = 0; i < books.Count; i++)
            {
                Assert.AreEqual(books[i].BookID, bookContainerMock.books[i].BookID);
                Assert.AreEqual(books[i].BookTitle, bookContainerMock.books[i].BookTitle);
                Assert.AreEqual(books[i].Author, bookContainerMock.books[i].Author);
                Assert.AreEqual(books[i].Publisher, bookContainerMock.books[i].Publisher);
                Assert.AreEqual(books[i].ISBN, bookContainerMock.books[i].ISBN);
            }





        }
        [TestMethod]
        public void RemoveBook()
        {
            //Arrange
            BookContainerMock bookContainerMock = new BookContainerMock();
            BookContainer bookContainer = new BookContainer(bookContainerMock);
            var booklist = bookContainer.GetBooks();
            var deletebook = booklist[0];
            //Act
            bookContainer.RemoveBook(deletebook.BookID);
            //Assert
            Assert.AreEqual(1, bookContainerMock.books.Count);
            Assert.AreEqual(2, bookContainerMock.books.First().BookID);
            Assert.AreEqual("Trying", bookContainerMock.books[0].BookTitle);
            Assert.AreEqual(deletebook.Author, "Cuneyt");




        }
        [TestMethod]
        public void GetBook()
        {
            //Arrange
            BookContainerMock bookContainerMock = new BookContainerMock();
            BookContainer bookContainer = new BookContainer(bookContainerMock);
            var booklist = bookContainer.GetBooks();
            var getbook = booklist[0];
            //Act
            bookContainer.GetBook(getbook.BookID);
            //Assert
            Assert.AreEqual(1, getbook.BookID);
            Assert.AreEqual(getbook.BookTitle, bookContainerMock.books[0].BookTitle);
            Assert.AreEqual(getbook.BookID, bookContainerMock.books[0].BookID);
            Assert.AreEqual(getbook.Publisher, bookContainerMock.books[0].Publisher);   
            Assert.AreEqual(getbook.Author, bookContainerMock.books[0].Author); 




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
            var booktitel = bookContainer.SearchBook(searchbook.BookTitle);
            //Assert
            Assert.AreEqual(1, booktitel.Count);
            Assert.AreEqual(searchbook.BookID, bookContainerMock.books[1].BookTitle);
            Assert.AreEqual(searchbook.ISBN, bookContainerMock.books[1].ISBN);
            Assert.AreEqual(searchbook.Author, bookContainerMock.books[1].Author);
            Assert.AreEqual(searchbook.Publisher, bookContainerMock.books[1].Publisher);    
          


        }

        [TestMethod]
        public void EditBookTest()
        {
            //Arrange

            BookContainerMock bookContainerMock = new BookContainerMock();
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
            Assert.AreEqual(book2.BookTitle, bookContainerMock.books[1].BookTitle);
            Assert.AreEqual(book2.ISBN, bookContainerMock.books[1].ISBN);
            Assert.AreEqual(book2.Publisher, bookContainerMock.books[1].Publisher);  






        }









    }
}

