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
        public List<Category> GetBookCategoriesByBookId(int id)
        {
            List<Category> categoryList = new List<Category>();
            _ICategoryContainerDAL.GetBookCategoriesByBookId(id).ForEach(categoryDTO => categoryList.Add(new Category(categoryDTO)));

            return categoryList;

        }
        public List<Category> GetAllCategoriesByIds(List<int> ids)
        {
            List<Category> categoryList = new List<Category>();
            _ICategoryContainerDAL.GetAllCategoriesByIds(ids).ForEach(categoryDTO => categoryList.Add(new Category(categoryDTO)));
            return categoryList;

           
        }
        public bool RemovecategoriesbyBookId(int id)
        {

            return _ICategoryContainerDAL.RemoveCategoriesForBookID(id);
        }

        public bool PreventDoublecategory(string categoryname)
        {

           return _ICategoryContainerDAL.PreventDoublecategory(categoryname);
        }
        public List<Category> GetCategories()
        {
            List<CategoryDTO> categorydtos = _ICategoryContainerDAL.GetCategory();
            List<Category> categorylist = new List<Category>();
            foreach (CategoryDTO categorydto in categorydtos)
            {
                categorylist.Add(new Category(categorydto));
            }
            return categorylist;


        }


    }
}
