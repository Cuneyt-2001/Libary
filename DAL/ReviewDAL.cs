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
    public class ReviewDAL : IReviewContainerDAL
    {
        public bool AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                SqlCommand command = new SqlCommand("Insert into [Review](BookID,UserID,Review) values(@BookID,@UserID,@Review)", Connection.connection);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@BookID", reviewDTO.BookID);
                    command.Parameters.AddWithValue("@UserID", reviewDTO.UserID);
                    command.Parameters.AddWithValue("@Review", reviewDTO.Review);

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
        public List<ReviewDTO> GetReview(int id)
        {
            try
            {
                Connection.connection.Open();
                List<ReviewDTO> reviewlist = new List<ReviewDTO>();

                SqlCommand comand = new SqlCommand("select * from [Review] where BookID='" + id + "'", Connection.connection);
                if (comand.Connection.State != ConnectionState.Open)
                {
                    comand.Connection.Open();
                }

                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    ReviewDTO reviewDTO = new ReviewDTO();
                    reviewDTO.BookID = Convert.ToInt32(reader["BookID"]);
                    reviewDTO.Review = Convert.ToString(reader["Review"]);
                    reviewlist.Add(reviewDTO);

                }
                reader.Close();

                return reviewlist;
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
