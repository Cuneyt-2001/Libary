using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IUserContainerDAL
    {
        int CreateAccount(UserDTO user);
        int GetUserIdByEmail(string email);
        bool GetUserType(string email);
        string GetUserNameByEmail(string email);
        List<UserDTO> GetAllUsers();
    }
}
