using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IUserDAL
    {
        bool Check_User_Information(string email, string password);
      //  bool AddReview(ReviewDTO reviw);
    }
}
