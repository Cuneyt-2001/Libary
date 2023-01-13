using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface ICategoryContainerDAL
    {
        /// <summary>
        /// om categorie toe te voegen 
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns></returns>
        bool AddCategory(CategoryDTO categoryDTO);
        /// <summary>
        /// Via deze methode kan de gebruiker boekcategorie toevoegen voor bepaalde boek.
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="BookID"></param>
        /// <returns></returns>
        bool AddBookCategory(int CategoryID, int BookID);
        /// <summary>
        /// die geeft categories van een boek aan de hand van boekid.
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public List<CategoryDTO> GetBookCategoriesByBookId( int bookid);
        /// <summary>
        /// die geeft categories van een boek aan de hand van boekid.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<CategoryDTO> GetAllCategoriesByIds(List<int> ids);
        //public bool DeleteBookCategory(int id);
        /// <summary>
        /// Deze methode verwijdert de categories van een boek.
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool RemoveCategoriesForBookID(int bookid);
        /// <summary>
        /// zorgt dat een categorie gewoon een keer toegevoegd kan worden.
        /// </summary>
        /// <param name="categoryname"></param>
        /// <returns></returns>
        public bool PreventDoublecategory(string categoryname);
        /// <summary>
        /// Geeft lijst van de categories.
        /// </summary>
        /// <returns></returns>
        public List<CategoryDTO> GetCategory();

    }
}
