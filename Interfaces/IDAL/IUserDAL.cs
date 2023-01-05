using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IUserDAL
    {
        /// <summary>
        /// dit controleert de gebruiker gegevens op basis van email en wachtwoord
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Check_User_Information(string email, string password);
     
    }
}
