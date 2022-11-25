using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IReviewContainerDAL
    {
        bool AddReview(ReviewDTO reviewDTO);
    }
}
