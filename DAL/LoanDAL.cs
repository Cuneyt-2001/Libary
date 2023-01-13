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
