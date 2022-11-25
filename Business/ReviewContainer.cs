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
    }
}
