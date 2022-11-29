using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    public class LoanContainerMock : ILoanContainerDAL
    {
        public List<LoanDTO> Loans = new List<LoanDTO>();
        public LoanContainerMock()
        {


            LoanDTO loan1 = new LoanDTO()
            {
                LoanID = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
                BookID = 1,
                UserID = 1


            };
            LoanDTO loan2 = new LoanDTO()
            {
                LoanID = 2,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
                BookID = 2,
                UserID = 2

            };
            Loans.Add(loan1);
            Loans.Add(loan2);

        }

        public bool AddLoan(LoanDTO loan)
        {
            var result = CheckAvailibilityofBook(loan);
            if (result == true)
            {
                Loans.Add(loan);
            }
            return false;

        }


        public bool CheckAvailibilityofBook(LoanDTO loan)
        {
            LoanDTO loanDTO = Loans.Find(x => x.BookID == loan.BookID);
            var result = loanDTO.ReturnDate < loan.LoanDate;
            return result;


        }

        public List<LoanDTO> GetAllLoans()
        {
            return Loans;
        }
        public List<LoanDTO> GetLoansByUser(int userid)
        {
            List<LoanDTO> loansbyuser = Loans.FindAll(x => x.UserID == userid);
            return loansbyuser;


        }

        List<LoanDTO> ILoanContainerDAL.CheckAvailibilityofBook(LoanDTO loan)
        {
            throw new NotImplementedException();
        }
    }
}
