using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class User
    {
        private IUserDAL _IUserDAL;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Rol { get; set; }

        public User(IUserDAL _IUserDAL)
        {
            this._IUserDAL = _IUserDAL;

        }
        public User()
        {
           
        }

        public User(UserDTO userdto)
        {
            this.UserID = userdto.UserID;
            this.UserName = userdto.UserName;
            this.Surname = userdto.Surname;
            this.Email = userdto.Email;
            this.Rol = userdto.Rol; 
           

        }
        
        public bool Checkinformation(string email,string password)
        {

            return _IUserDAL.Check_User_Information(email, password);
        }
       

    }

}
