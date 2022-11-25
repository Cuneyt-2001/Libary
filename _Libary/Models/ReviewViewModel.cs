using Business;
using System.ComponentModel.DataAnnotations;

namespace _Libary.Models
{
    public class ReviewViewModel
    {
        [Key]
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        [Required]
        public string Review { get; set; }        

        public ReviewViewModel()
        {

        }

        public ReviewViewModel(Review_ review)
        {
            this.ReviewID = review.ReviewID;
            this.UserID = review.UserID;
            this.BookID = review.BookID;
            this.Review = review.Review;
        }

    }
}
