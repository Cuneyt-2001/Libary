using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BookCategory
    {
       
        public int ID { get; set; } 
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public BookCategory(BookCategoryDTO bookCategoryDTO)
        {
            ID = bookCategoryDTO.ID;
            BookID = bookCategoryDTO.BookID;
            CategoryID = bookCategoryDTO.CategoryID;

        }

        public BookCategory()
        {
        }
    }

}
