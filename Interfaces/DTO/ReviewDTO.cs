using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string Review { get; set; }

    }

}
