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
        bool AddCategory(CategoryDTO categoryDTO);
        bool AddBookCategory(int CategoryID, int BookID);
        public List<CategoryDTO> GetBookCategoriesByBookId( int bookid);
        public List<CategoryDTO> GetAllCategoriesByIds(List<int> ids);
        //public bool DeleteBookCategory(int id);
        public bool RemoveCategoriesForBookID(int bookid);

    }
}
