using Business;

namespace _Libary.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public CategoryViewModel(Category category)
        {
            this.CategoryID = category.CategoryID;
            this.CategoryName = category.CategoryName;

        }

        public CategoryViewModel()
        {
        }
    }
}
