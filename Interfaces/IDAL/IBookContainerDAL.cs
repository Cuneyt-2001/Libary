using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IBookContainerDAL
    {
        /// <summary>
        /// die geeft de lijst van de boeken.
        /// </summary>
        /// <returns></returns>
        List<BookDTO> GetBooks();
        /// <summary>
        /// die geeft boek op basis van de boekid.
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        BookDTO GetBook(int bookid);
        /// <summary>
        /// om boek toe te voegen.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int AddBook(BookDTO book);
        /// <summary>
        /// om een boek te verwijderen op basis van de boekid.
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        bool RemoveBook(int bookid);
        /// <summary>
        /// Via deze methode kan de gebruiker boek zoeken op basis van de boektitel.
        /// </summary>
        /// <param name="Booktitle"></param>
        /// <returns></returns>
        List<BookDTO> SearchBook(string Booktitle);
        /// <summary>
        /// die geeft alle categories
        /// </summary>
        /// <returns></returns>
        List<CategoryDTO> GetCategory();
        


    }
}
