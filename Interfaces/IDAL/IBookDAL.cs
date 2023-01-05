using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IBookDAL
    {
        /// <summary>
        /// Via deze methode kan de gebruiker boekgegevens updaten.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool EditBook(BookDTO book);
        
    }
}
