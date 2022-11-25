using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    public class CategoryContainerMock : ICategoryContainerDAL, ICategoryDAL
    {
        public List<CategoryDTO> categories = new List<CategoryDTO>();
        public List<BookCategoryDTO> bookcategories = new List<BookCategoryDTO>();
        public CategoryContainerMock()
        {


            CategoryDTO categorydto = new CategoryDTO()
            {
              CategoryID = 1,
              CategoryName="Horror"

            };
            CategoryDTO categorydto2 = new CategoryDTO()
            {CategoryID = 2,
            CategoryName="Funny"

            };
            categories.Add(categorydto);
            categories.Add(categorydto2);

            BookCategoryDTO bookcategorydto = new BookCategoryDTO()
            {
                ID = 1,
                CategoryID = 5,
                BookID = 4,
            };
            BookCategoryDTO bookcategorydto2 = new BookCategoryDTO()
            {
                ID= 2,  
                CategoryID = 3,
                BookID = 4,
            };
            bookcategories.Add(bookcategorydto2);   
            bookcategories.Add(bookcategorydto);
        }


        /* completed!  */
        public bool AddBookCategory(int CategoryID, int BookID)
        {
           // BookCategoryDTO bookCategoryDTO= bookcategories.Find(c => c.BookID == BookID /*&& BookID==c.BookID*/);
            BookCategoryDTO bookcategory = new BookCategoryDTO
            {
                CategoryID = CategoryID,
                BookID = BookID
            };
           bookcategories.Add(bookcategory);
            return true;
        }
        /* completed ! */
        public bool AddCategory(CategoryDTO categoryDTO)
        {
            categories.Add(categoryDTO);
            return true;
                
                  
        }

        /* completed ! */
        public bool DeleteBookCategory(int id)
        {
            CategoryDTO CategoryToDelete = categories.Find(x => x.CategoryID == id);
            categories.Remove(CategoryToDelete);
            return true;
        }
        /* check  */
        public List<CategoryDTO> GetAllCategoriesByIds(List<int> ids)
        {
          
            ////ids.Add(1); 
            ////ids.Add(2);
            //CategoryDTO categoryToFind = categories.Find(x => x.CategoryID ==ids) ;
            //categories.Add();
            //return categories;
            throw new NotImplementedException();    
        }
        /* completed ! */
        public List<BookCategoryDTO> GetBookCategoriesByBookId(int bookid)
        {
            List<BookCategoryDTO> getcategoriesbybookid = bookcategories.FindAll(x => x.BookID == bookid);
            return getcategoriesbybookid;

           
        }
        /* completed ! */
        public int UpdateBookCategory(BookCategoryDTO bookCategoryDTO)
        {
            BookCategoryDTO bookcategorydto = bookcategories.First(x => x.BookID == bookCategoryDTO.BookID);
           // bookcategories.Remove(bookcategorydto);
            bookcategories.Add(bookCategoryDTO);
            return bookcategories.Count();  
        }

      
    }
}
