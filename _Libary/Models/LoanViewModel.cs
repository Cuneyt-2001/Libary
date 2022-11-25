using Business;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _Libary.Models
{
    public class LoanViewModel
    {
        public int UserID { get; set; }

        public int LoanID { get; set; }
        public int BookID { get; set; }
        public string BookTitle { get; set; }   
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
       
        public DateTime ReturnDate {get; set; }

        public LoanViewModel()
        {

        }

        public LoanViewModel(Loan loan, string bookTitle, string userName)
        {
            this.UserID = loan.UserID;
            this.LoanID = loan.LoanID;
            this.LoanDate = loan.LoanDate;
            this.ReturnDate = loan.ReturnDate;
            this.UserName = userName;
            this.BookTitle = bookTitle;
        }

       
    }
}
