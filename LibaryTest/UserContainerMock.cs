using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    public class UserContainerMock : IUserDAL, IUserContainerDAL

    {
        public List<UserDTO> users = new List<UserDTO>();
        public UserContainerMock()
        {
            UserDTO user1 = new()
            {
                UserID = 1,
                Email = "cuneyt@gmail.com",
                UserName = "Cuneyt",
                Password = "12345678",
                Rol = true,
                Surname = "Terkesli"
            };

            UserDTO user2 = new UserDTO()
            {
                UserID = 2,
                Email = "Tim@gmail.com",
                UserName = "Tim",
                Password = "1234567890",
                Rol = false,
                Surname = "thone"

            };

            users.Add(user1);
            users.Add(user2);


        }
        public bool Check_User_Information(string email, string password)
        {
            var user = users.Find(x => x.Email == email&& password==x.Password);

            if (user.Email == email&&user.Password==password) return true;
            return false;
        
        }

        public int CreateAccount(UserDTO user)
        {
            users.Add(user);
            return users.Count();
        }

        public List<UserDTO> GetAllUsers()
        {
            return users;
        }

        public int GetUserIdByEmail(string email)
        {
           var user= users.Find(x => x.Email == email);
            return user.UserID;
        }

        public string GetUserNameByEmail(string email)
        {
         var user=users.Find(x => x.Email == email);
            return user.UserName;
        }

        public bool GetUserType(string email)
        {
            var user = users.Find(x => x.Email == email);
            return user.Rol;
        }
    }
}
