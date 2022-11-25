using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IBookDAL
    {
        bool EditBook(BookDTO book);
        // Review list dtos BookDTO GetReview(int bookid);
    }
}
