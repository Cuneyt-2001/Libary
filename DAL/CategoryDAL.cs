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
    public class CategoryDAL : ICategoryContainerDAL
    {

        public bool AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                SqlCommand command = new SqlCommand("Insert into [Category](CategoryName) values(@CategoryName)", Connection.connection);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@CategoryName", categoryDTO.CategoryName);


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
        public bool AddBookCategory(int CategoryID, int BookID)
        {

            try
            {
                SqlCommand command = new SqlCommand("Insert into [Book_Category](CategoryID,BookID) values(@CategoryID,@BookID)", Connection.connection);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@BookID", BookID);


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

        public bool RemoveCategoriesForBookID(int bookid)
        {
            try
            {
                SqlCommand command = new SqlCommand($"Delete from [Book_Category] where BookID={bookid}", Connection.connection);
                
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();

                }
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception exception)
            {

            }
            finally { Connection.connection.Close(); } 
            return false;
        }

        public List<CategoryDTO> GetBookCategoriesByBookId(int bookid)
        {

            try
            {
                List<CategoryDTO> bookCategories = new List<CategoryDTO>();
                SqlCommand command = new SqlCommand($"Select Category.* from [Book_Category] INNER JOIN [Category] ON Book_Category.CategoryID=Category.CategoryID where BookID={bookid}", Connection.connection);
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();

                }
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    CategoryDTO dto = new CategoryDTO();
                    //dto.BookID = Convert.ToInt32(reader["BookID"]);
                    dto.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    dto.CategoryName = Convert.ToString(reader["CategoryName"]);
                    bookCategories.Add(dto);
                }
                reader.Close();
                return bookCategories;

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
       


        public List<CategoryDTO> GetAllCategoriesByIds(List<int> ids)
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            if (ids.Count() == 0)
            {
                return categories;
            }
            var query = "";
            for (int i = 0; i < ids.Count; i++)
            {
                query += ids[i];
                if (i<ids.Count-1)
                {
                    query += ", ";
                }
            }
          
            try
            {
                SqlCommand command = new SqlCommand($"Select * from [Category] where CategoryID in ({query})", Connection.connection);

                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    CategoryDTO categoryDTO = new CategoryDTO();
                    categoryDTO.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    categoryDTO.CategoryName = Convert.ToString(reader["CategoryName"]);

                    categories.Add(categoryDTO);
                }
                reader.Close();

                return categories;
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
    

        public bool DeleteBookCategory(int id)
        {
            try
            {
                var todelete = $"Delete from Book_Category where ID={id}";
                var com = new SqlCommand(todelete, Connection.connection);
              
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
        public bool PreventDoublecategory(string categoryname)
        {

            var result = $"select count(*) from Category where CategoryName = @CategoryName";
            var com = new SqlCommand(result, Connection.connection);
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();

            }
           if(result.Contains(categoryname))
            {
                return false;
            }
            return true;
        }
    }
}
