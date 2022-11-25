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
    public class UserDAL : IUserDAL, IUserContainerDAL
    {
        public int CreateAccount(UserDTO user)
        {
            SqlCommand command = new SqlCommand("insert into [User]( UserName,Surname,Email,Password,Rol) values(@UserName,@Surname,@Email,@Password,@Rol)", Connection.connection);
            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();

            }
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Surname", user.Surname);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Rol",false);

            return command.ExecuteNonQuery();
        }

        public bool Check_User_Information(string email, string password)
        {
            SqlCommand command = new SqlCommand("Select * From [User] where Email=@email and Password=@Password ", Connection.connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@Password", password);
            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();

            }
            SqlDataReader reader = command.ExecuteReader();
            var isvalid = reader.Read();
            Connection.connection.Close();
            return isvalid;

        }

        public int GetUserIdByEmail(string email)
        {
            int userid = 0;
            SqlCommand command2 = new SqlCommand("select * from [User] where Email=@email", Connection.connection);
            command2.Parameters.AddWithValue("@email", email);
            if (command2.Connection.State != ConnectionState.Open)
            {
                command2.Connection.Open();

            }
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                userid = Convert.ToInt32(reader["UserID"]);
            }
            reader.Close();
            Connection.connection.Close();
            return userid;
        }
        public bool GetUserType(string email)
        {
            bool usertype = false;
            SqlCommand command2 = new SqlCommand("select * from [User] where Email=@email", Connection.connection);
            command2.Parameters.AddWithValue("@email", email);
            if (command2.Connection.State != ConnectionState.Open)
            {
                command2.Connection.Open();

            }
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                usertype = Convert.ToBoolean(reader["Rol"]);
            }
            reader.Close();
            Connection.connection.Close();
            return usertype;


        }
        public string GetUserNameByEmail(string email)
        {
            string UserName = null;
            SqlCommand command2 = new SqlCommand("select * from [User] where Email=@email", Connection.connection);
            command2.Parameters.AddWithValue("@email", email);
            if (command2.Connection.State != ConnectionState.Open)
            {
                command2.Connection.Open();

            }
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                UserName = Convert.ToString(reader["UserName"]);
            }
            reader.Close();
            Connection.connection.Close();
            return UserName;





        }
        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> userlist = new List<UserDTO>();

            SqlCommand comand = new SqlCommand("select UserID,UserName,Surname,Email,Rol from [User]", Connection.connection);

            if (comand.Connection.State != ConnectionState.Open)
            {
                comand.Connection.Open();
            }

            SqlDataReader reader = comand.ExecuteReader();
            while (reader.Read())
            {
                UserDTO userdto = new UserDTO();
                userdto.UserID = Convert.ToInt32(reader["UserID"]);
                userdto.UserName = Convert.ToString(reader["UserName"]);
                userdto.Surname = Convert.ToString(reader["Surname"]);
                userdto.Email = Convert.ToString(reader["Email"]);
                var test = reader[4];
                userdto.Rol = reader[4] == DBNull.Value ? false : Convert.ToBoolean(reader["Rol"]);
                userlist.Add(userdto);
            }
            reader.Close();

            Connection.connection.Close();

            return userlist;
        }
    }
}
