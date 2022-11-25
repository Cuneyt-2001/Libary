using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryContainer
    {
        private ICategoryContainerDAL _ICategoryContainerDAL;

        public CategoryContainer(ICategoryContainerDAL ICategoryContainerDAL)
        {
            this._ICategoryContainerDAL = ICategoryContainerDAL;
        }

        public bool AddCategory(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.CategoryName = category.CategoryName;
            return _ICategoryContainerDAL.AddCategory(categoryDTO); 

        }
        public bool AddBookCategory(int CategoryID, int BookID)
        {
            return _ICategoryContainerDAL.AddBookCategory(CategoryID, BookID);  

        }
        public List<BookCategoryDTO> GetBookCategoriesByBookId(int id)
        {

            return _ICategoryContainerDAL.GetBookCategoriesByBookId(id);



        }
        public List<CategoryDTO> GetAllCategoriesByIds(List<int> ids)
        {


            return _ICategoryContainerDAL.GetAllCategoriesByIds(ids);
        }
        public int UpdateBookCategory(BookCategory bookCategory)
        {
            BookCategoryDTO bookCategoryDTO = new();
            bookCategoryDTO.CategoryID=bookCategory.CategoryID;
            bookCategoryDTO.BookID=bookCategory.BookID;
            return _ICategoryContainerDAL.UpdateBookCategory(bookCategoryDTO);



        }
        public bool DeleteBookCategory(int id)
        {
            return _ICategoryContainerDAL.DeleteBookCategory(id);

        }

    }
}
