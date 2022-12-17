using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoanDAL : ILoanContainerDAL
    {
        public bool AddLoan(LoanDTO loan)
        {
            try
            {
                SqlCommand command = new SqlCommand("Insert into [Loan](BookID,UserID,LoanDate,ReturnDate) values(@BookID,@UserID,@LoanDate,@ReturnDate)", Connection.connection);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@BookID", loan.BookID);
                    command.Parameters.AddWithValue("@UserID", loan.UserID);
                    command.Parameters.AddWithValue("@LoanDate", loan.LoanDate);
                    command.Parameters.AddWithValue("@ReturnDate", loan.ReturnDate);
                }
                return command.ExecuteNonQuery() > 0;
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
        public List<BookDTO> GetAllBooks()
        {
            try
            {
                Connection.connection.Open();
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
                    // bookdto.Category = Convert.ToString(reader["Category"]);
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
        public List<BookDTO> SearchBook(string booktitle)
        {
            try
            {
                Connection.connection.Open();
                List<BookDTO> booklist = new List<BookDTO>();

                SqlCommand comand = new SqlCommand("select * from[Book] where BookTitle like '%" + booktitle + "%'And Visibility='True'", Connection.connection);
                comand.Parameters.AddWithValue("@BookTitle", booktitle);
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
        public BookDTO GetBook(int bookid)
        {
            try
            {
                Connection.connection.Open();
                SqlCommand command = new SqlCommand("select * from [Book] where BookID=@BookID", Connection.connection);
                command.Parameters.AddWithValue("@BookID", bookid);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();

                }

                BookDTO bookDTO = new BookDTO();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bookDTO.BookID = Convert.ToInt32(reader["BookID"]);
                    bookDTO.BookTitle = Convert.ToString(reader["BookTitle"]);
                    bookDTO.Author = Convert.ToString(reader["Author"]);
                    bookDTO.Publisher = Convert.ToString(reader["Publisher"]);
                    bookDTO.ISBN = Convert.ToInt32(reader["ISBN"]);
                }
                reader.Close();
                return bookDTO;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally { Connection.connection.Close(); }

        }
        public List<LoanDTO> CheckAvailibilityofBook(LoanDTO loandto)
        {
            try
            {
                List<LoanDTO> loanlist = new List<LoanDTO>();
                SqlCommand command2 = new SqlCommand("SELECT Count(*) FROM Loan WHERE LoanDate BETWEEN @selectedloandate AND @selectedreturndate OR ReturnDate BETWEEN @selectedloandate AND @selectedreturndate And BookID = @BookID", Connection.connection);

                command2.Parameters.AddWithValue("@BookID", loandto.BookID);
                command2.Parameters.AddWithValue("@selectedloandate", loandto.LoanDate);
                command2.Parameters.AddWithValue("@selectedreturndate", loandto.ReturnDate);
                if (command2.Connection.State != ConnectionState.Open)
                {
                    command2.Connection.Open();
                }

                Int32 count = Convert.ToInt32(command2.ExecuteScalar());
                SqlDataReader reader = command2.ExecuteReader();
                if (count > 0)
                {
                    
                    while (reader.Read())
                    {
                        LoanDTO loandtos = new LoanDTO();
                        loandtos.LoanDate = Convert.ToDateTime(reader["LoanDate"]);
                        loandtos.ReturnDate = Convert.ToDateTime(reader["ReturnDate"]);

                        loanlist.Add(loandtos);
                    }
                    reader.Close();

                    return loanlist;
                }
                else
                {

                    return new List<LoanDTO>();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.connection.Close();
            }


        }
        public List<LoanDTO> GetAllLoans()
        {

            try
            {

                List<LoanDTO> Loanlist = new List<LoanDTO>();

                SqlCommand comand = new SqlCommand("select * from Loan", Connection.connection);

                if (comand.Connection.State != ConnectionState.Open)
                {
                    comand.Connection.Open();
                }

                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    LoanDTO loandto = new LoanDTO();
                    loandto.LoanID = Convert.ToInt32(reader["LoanID"]);
                    loandto.LoanDate = Convert.ToDateTime(reader["LoanDate"]);
                    loandto.ReturnDate = Convert.ToDateTime(reader["ReturnDate"]);
                    loandto.BookID = Convert.ToInt32(reader["BookID"]);
                    loandto.UserID = Convert.ToInt32(reader["UserID"]);
                    Loanlist.Add(loandto);
                }
                reader.Close();

                return Loanlist;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally

            { Connection.connection.Close(); }

        }

        public List<LoanDTO> GetLoansByUser(int userid)
        {
            try
            {

                List<LoanDTO> Loanlist = new List<LoanDTO>();

                SqlCommand comand = new SqlCommand("select * from Loan where UserID=@UserID", Connection.connection);
                comand.Parameters.AddWithValue("@UserID",userid);
                

                if (comand.Connection.State != ConnectionState.Open)
                {
                    comand.Connection.Open();
                }

                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    LoanDTO loandto = new LoanDTO();
                    loandto.LoanDate = Convert.ToDateTime(reader["LoanDate"]);
                    loandto.ReturnDate = Convert.ToDateTime(reader["ReturnDate"]);
                    loandto.BookID = Convert.ToInt32(reader["BookID"]);
                    loandto.UserID = Convert.ToInt32(reader["UserID"]);
                    Loanlist.Add(loandto);
                }
                reader.Close();

                return Loanlist;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally

            { Connection.connection.Close(); }






        }
    }
}
