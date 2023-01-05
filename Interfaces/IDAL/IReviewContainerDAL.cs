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
        /// <summary>
        /// Via deze methode kan de gebruiker een review toevoegen.
        /// </summary>
        /// <param name="reviewDTO"></param>
        /// <returns></returns>
        bool AddReview(ReviewDTO reviewDTO);
    }
}
