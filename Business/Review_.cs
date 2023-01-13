using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Review_
    {
        public int ReviewID;
        public int UserID;
        public int BookID;
        public string Review;

        public Review_()
        {
        }

        public Review_(ReviewDTO reviewDTO)
        {
            this.ReviewID = reviewDTO.ReviewID;
            this.UserID = reviewDTO.UserID;
            this.BookID = reviewDTO.BookID;
            this.Review = reviewDTO.Review;
        }
    }
}
