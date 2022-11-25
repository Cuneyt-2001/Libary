using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Loan
    {
        public int UserID;
        public int LoanID;
        public DateTime LoanDate;
        public DateTime ReturnDate;
        public int BookID;

        public Loan()
        {
        }

        public Loan(LoanDTO loanDTO)
        {
            UserID = loanDTO.UserID;
            LoanID =loanDTO.LoanID;
            LoanDate = loanDTO.LoanDate;
            ReturnDate = loanDTO.ReturnDate;
            BookID = loanDTO.BookID;    
        }
    }
}
