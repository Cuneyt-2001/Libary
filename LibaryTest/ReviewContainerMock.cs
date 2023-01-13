using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    public class ReviewContainerMock : IReviewContainerDAL
    {
        public List<ReviewDTO> reviews = new List<ReviewDTO>();
        public ReviewContainerMock()
        {
            ReviewDTO review1 = new ReviewDTO()
            {
                ReviewID = 1,
                BookID = 1,
                Review = "Super"
               
               


            };
            ReviewDTO review2 = new ReviewDTO()
            {
                ReviewID = 2,
                BookID= 1,
                Review = "Wat saai"

            };
          
            reviews.Add(review1);
            reviews.Add(review2);
           


        }

        public bool AddReview(ReviewDTO reviewDTO)
        {
            reviews.Add(reviewDTO);
           return true;
        }

        public List<ReviewDTO> GetReview(int id)
        {
           List<ReviewDTO> review=reviews.FindAll(x => x.BookID == id);
            return review;
        }
    }
}
