using Interfaces.DTO;
using Interfaces.IDAL;
using MaxMind.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookDAL: IBookDAL, IBookContainerDAL
    {
        public int AddBook(BookDTO book)
        {
            try
            {
                SqlCommand command = new SqlCommand("Insert into [Book](ISBN,BookTitle,Publisher,Author,Visibility)  OUTPUT INSERTED.BookID values(@ISBN,@BookTitle,@Publisher,@Author, @Visibility)", Connection.connection);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                    command.Parameters.AddWithValue("@Publisher", book.Publisher);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Visibility", true);    
                }
                 return (int)command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                Connection.connection.Close();
            }
        }

        public bool EditBook(BookDTO book)
        {
            try
            {
                var command = "update Book set ISBN=@ISBN,BookTitle=@BookTitle,Publisher=@Publisher,Author=@Author Where BookID=@BookID";
                var com = new SqlCommand(command, Connection.connection);
                com.Parameters.AddWithValue("@BookID", book.BookID);
                com.Parameters.AddWithValue("@ISBN", book.ISBN);
                com.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                com.Parameters.AddWithValue("@Publisher", book.Publisher);
                com.Parameters.AddWithValue("@Author", book.Author);
              
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();

                }
                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally { Connection.connection.Close(); }
        }

        public BookDTO GetBook(int bookid)
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from [Book] where BookID=@BookID", Connection.connection);
                command.Parameters.AddWithValue("@BookID", bookid);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();

                }

                BookDTO bookdto = new BookDTO();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bookdto.BookID = Convert.ToInt32(reader["BookID"]);
                    bookdto.BookTitle = Convert.ToString(reader["BookTitle"]);
                    bookdto.Author = Convert.ToString(reader["Author"]);
                    bookdto.Publisher = Convert.ToString(reader["Publisher"]);
                    bookdto.ISBN = Convert.ToInt32(reader["ISBN"]);
                }
                reader.Close();
                return bookdto;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally { Connection.connection.Close(); }


        }

        public List<BookDTO> GetBooks()
        {
            try
            {
                List<BookDTO> booklist = new List<BookDTO>();

                SqlCommand comand = new SqlCommand("select * from [Book] where Visibility='True'", Connection.connection);
                if (comand.Connection.State != ConnectionState.Open)
                {
                    comand.Connection.Open();
                }

                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {

                    BookDTO bookdto = new BookDTO();
                    bookdto.BookID = Convert.ToInt32(reader["BookID"]);
                    bookdto.BookTitle = Convert.ToString(reader["BookTitle"]);
                    bookdto.Author = Convert.ToString(reader["Author"]);
                    bookdto.Publisher = Convert.ToString(reader["Publisher"]);
                    bookdto.ISBN = Convert.ToInt32(reader["ISBN"]);
                    booklist.Add(bookdto);
                }
                reader.Close();

                return booklist;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally

            { Connection.connection.Close(); }
        }

        public BookDTO GetReview(int bookid)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBook(int bookid)
        {
            try
            {
                Connection.connection.Open();
                SqlCommand command = new SqlCommand(" update Book set Visibility='False' Where BookID=@BookID", Connection.connection);
                command.Parameters.AddWithValue("@BookID", bookid);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();

                }
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connection.connection.Close(); }
        }
     
         public List<BookDTO> SearchBook(string Booktitle)
        {
            try
            {
                List<BookDTO> booklist = new List<BookDTO>();

                SqlCommand comand = new SqlCommand("select * from[Book] where BookTitle like '%"+Booktitle+"%'And Visibility='True'" , Connection.connection);
                comand.Parameters.AddWithValue("@BookTitle", Booktitle);
                if (comand.Connection.State != ConnectionState.Open)
                {
                    comand.Connection.Open();
                }

                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {

                    BookDTO bookdto = new BookDTO();
                    bookdto.BookID = Convert.ToInt32(reader["BookID"]);
                    bookdto.BookTitle = Convert.ToString(reader["BookTitle"]);
                    bookdto.Author = Convert.ToString(reader["Author"]);
                    bookdto.Publisher = Convert.ToString(reader["Publisher"]);
                    bookdto.ISBN = Convert.ToInt32(reader["ISBN"]);
                    booklist.Add(bookdto);
                }
                reader.Close();

                return booklist;
            }

            catch (Exception exception)
            {
                throw exception;
              
            }
            finally

            { Connection.connection.Close(); }

        }


        public List<CategoryDTO>GetCategory()
        {
            try
            {
                List<CategoryDTO> categorylist = new List<CategoryDTO>();
                SqlCommand comand = new SqlCommand("select * from[Category]", Connection.connection);

                if (comand.Connection.State != ConnectionState.Open)
                {
                    comand.Connection.Open();
                }

                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {

                    CategoryDTO categoryDTO = new CategoryDTO();
                    categoryDTO.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    categoryDTO.CategoryName = Convert.ToString(reader["CategoryName"]);

                    categorylist.Add(categoryDTO);
                }
                reader.Close();

                return categorylist;
            }

            catch (Exception exception)
            {
                throw exception;
              
            }
            finally

            { Connection.connection.Close(); }
        }



    }
}
