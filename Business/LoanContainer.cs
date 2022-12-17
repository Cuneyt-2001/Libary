using Interfaces.DTO;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoanContainer
    {
        private ILoanContainerDAL _loanContainerDAL;

        public LoanContainer(ILoanContainerDAL loanContainerDAL)
        {
            this._loanContainerDAL = loanContainerDAL;
        }


        public bool AddLoan(Loan loan)
        {
            LoanDTO loanDTO = new LoanDTO();
            loanDTO.UserID = loan.UserID;
            loanDTO.BookID = loan.BookID;
            loanDTO.LoanDate = loan.LoanDate;
            loanDTO.ReturnDate = loan.ReturnDate;
            return _loanContainerDAL.AddLoan(loanDTO);

        }

        public bool CheckAvailibilityofBook(Loan loan)
        {
            LoanDTO loanDTO = new LoanDTO();
            loanDTO.BookID = loan.BookID;
            loanDTO.LoanDate = loan.LoanDate;
            loanDTO.ReturnDate = loan.ReturnDate;

            TimeSpan timeSpan = loanDTO.ReturnDate - loanDTO.LoanDate;
            if (!(loanDTO.LoanDate >= DateTime.Now.Date && loanDTO.ReturnDate >= DateTime.Now.Date && loanDTO.LoanDate.Date <= loanDTO.ReturnDate && timeSpan.Days <= 20))
            {

                return false;
            }
          
            var allLoans = _loanContainerDAL.GetAllLoans();
            if (allLoans.Any(a => a.BookID == loan.BookID && ((loan.LoanDate >= a.LoanDate && loan.LoanDate <= a.ReturnDate) || (loan.ReturnDate >= a.LoanDate && loan.ReturnDate <= a.ReturnDate))))
            {
                return false;
            }
            return true;
        }

        public List<Loan> GetAllLoans()
        {

            List<LoanDTO> loandtos = _loanContainerDAL.GetAllLoans().Where(x=>x.ReturnDate>= DateTime.Now.Date).ToList();
            List<Loan> loanlist = new List<Loan>();
            foreach (LoanDTO loandto in loandtos)
            {
                loanlist.Add(new Loan(loandto));
            }
            return loanlist;

        }

        public List<Loan> GetAllLoansByUser(int userid)
        {

            List<LoanDTO> loandtos = _loanContainerDAL.GetLoansByUser(userid);
            List<Loan> loanlist = new List<Loan>();
            foreach (LoanDTO loandto in loandtos)
            {
                loanlist.Add(new Loan(loandto));
            }
            return loanlist;

        }





    }
}
