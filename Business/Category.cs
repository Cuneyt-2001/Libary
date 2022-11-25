using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }


        public Category(CategoryDTO categoryDTO)
        {
            CategoryID = categoryDTO.CategoryID;
            CategoryName = categoryDTO.CategoryName;

        }

        public Category()
        {
        }
    }
}
