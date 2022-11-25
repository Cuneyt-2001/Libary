using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface ILoanContainerDAL
    {
        bool AddLoan(LoanDTO loan);
        //List<BookDTO> GetAllBooks();
        //List<BookDTO> SearchBook(string booktitle);
        //BookDTO GetBook(int bookid);
        bool CheckAvailibilityofBook(LoanDTO loan);
        List<LoanDTO> GetAllLoans();
        List<LoanDTO> GetLoansByUser(int userid);
        

    }
}
