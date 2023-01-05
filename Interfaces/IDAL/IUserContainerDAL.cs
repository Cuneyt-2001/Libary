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
        /// <summary>
        /// dit maakt een nieuwe account aan op basis van de gebruiker gegevens
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int CreateAccount(UserDTO user);
        /// <summary>
        /// dit geeft gebruikerid aan de hand van email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        int GetUserIdByEmail(string email);
        /// <summary>
        /// dit geeft aan of de gebruiker toegang heeft.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool GetUserType(string email);
        /// <summary>
        /// dat geeft de naam van de gebruiker op basis van de e-mail.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        string GetUserNameByEmail(string email);
        /// <summary>
        /// dat geeft de lijst van de alle gebruikers.
        /// </summary>
        /// <returns></returns>
        List<UserDTO> GetAllUsers();
    }
}
