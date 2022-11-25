using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserContainer
    {
        private IUserContainerDAL _IUserContainerDAL;

        public UserContainer(IUserContainerDAL iUserContainerDAL)
        {
            this._IUserContainerDAL = iUserContainerDAL;
        }

        public int CreateUserAccount(User user)
        {
            UserDTO userdto = new UserDTO();
            userdto.UserName = user.UserName;
            userdto.Password = user.Password;
            userdto.Email = user.Email;
            userdto.UserID = user.UserID;
            userdto.Rol=user.Rol;
            userdto.Surname = user.Surname;
           return _IUserContainerDAL.CreateAccount(userdto);

        }
        public int GetUserIdByEmail(string email)
        {

            return _IUserContainerDAL.GetUserIdByEmail(email);
        }
        public bool GetUserType(string email)
        {
            var rol= _IUserContainerDAL.GetUserType(email);

            if(rol==true)
            {
                return true;
            }

            return false;

        }
        public string GetUserNameByEmail(string email)
        {

          return _IUserContainerDAL.GetUserNameByEmail(email);
        }
        public List<User>GetAllUsers()
        {
            List<User> users = new List<User>();
            List<UserDTO> allusers = _IUserContainerDAL.GetAllUsers();
            foreach (UserDTO userdto in allusers)
            {
                users.Add(new User(userdto));

            }

            return users;
        }
    }
}

    
