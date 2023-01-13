using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReviewContainer
    {
        private IReviewContainerDAL _IReviewContainerDAL;

        public ReviewContainer(IReviewContainerDAL iReviewContainerDAL)
        {
            _IReviewContainerDAL = iReviewContainerDAL;
        }
        public bool AddReview(Review_ review)

        {
            ReviewDTO reviewDTO = new ReviewDTO();
            reviewDTO.UserID = review.UserID;
            reviewDTO.BookID = review.BookID;
            reviewDTO.Review = review.Review;
            reviewDTO.ReviewID = review.ReviewID;
            return _IReviewContainerDAL.AddReview(reviewDTO);
        }
        public List<Review_> GetReview(int id)
        {
            List<Review_> reviewlist = new List<Review_>();
            _IReviewContainerDAL.GetReview(id).ForEach(reviewdto => reviewlist.Add(new Review_(reviewdto)));
            return reviewlist;

        }
    }
}
