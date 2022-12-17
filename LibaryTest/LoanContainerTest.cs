using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    [TestClass]
    public class LoanContainerTest
    {
        [TestMethod]
        public void AddLoan()
        {
            //Arrange

            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);
           
            DateTime date1 = DateTime.Now.AddDays(5);
            DateTime date3 = DateTime.Now.AddDays(8);


            Loan loan = new Loan()
            {
                LoanDate = date1,
                LoanID = 3,
                BookID = 1,
                ReturnDate = date3,
                UserID = 3,


            };

            //Act

            loancontainer.AddLoan(loan);
            var result = loancontainermock.Loans.Count;

            //Assert

            Assert.AreEqual(3, result);
            Assert.AreEqual(loan.BookID, loancontainermock.Loans.Last().BookID);
            Assert.AreEqual(loan.UserID, loancontainermock.Loans.Last().UserID);
            Assert.AreEqual(loan.LoanDate, loancontainermock.Loans.Last().LoanDate);
            Assert.AreEqual(loan.ReturnDate, loancontainermock.Loans.Last().ReturnDate);
           
        }

        [TestMethod]
        public void GetAllLoan()
        {
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);



            //Act

            List<Loan> loans = loancontainer.GetAllLoans();


            //Assert
            Assert.AreEqual(loancontainermock.GetAllLoans().Count(), loans.Count); ;
            for (int i = 0; i < loans.Count; i++)
            {
                Assert.AreEqual(loans[i].LoanDate, loancontainermock.Loans[i].LoanDate);
                Assert.AreEqual(loans[i].ReturnDate,loancontainermock.Loans[i].ReturnDate);
                Assert.AreEqual(loans[i].LoanID, loancontainermock.Loans[i].LoanID);    
                Assert.AreEqual(loans[i].BookID,loancontainermock.Loans[i].BookID);

            }


        }
        [TestMethod]
        public void BarrowdaysmallerthanToday()
        {
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();
            LoanContainer loancontainer = new LoanContainer(loancontainermock);
            DateTime date9 = DateTime.Today.AddDays(-5);
            DateTime date10 = DateTime.Today.AddDays(5);
            Loan loan4 = new Loan()
            {
                LoanDate = date9,
                ReturnDate = date10,
                BookID = 2,
                UserID = 3,

            };


            //Act
           
            var barrowdaybiggerthantoday = loancontainer.CheckAvailibilityofBook(loan4);


            //Assert
          
            Assert.IsFalse(barrowdaybiggerthantoday);


        }
        [TestMethod]
        public void ReturndateSmallerthanBarrowday()
        {
            //to do future
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);
            DateTime date3 = DateTime.Today.AddDays(1);
            DateTime date4 = DateTime.Today.AddDays(-5);
            Loan loan = new Loan()
            {
                LoanDate = date3,
                LoanID = 3,
                BookID = 2,
                ReturnDate = date4,
                UserID = 3,


            };
            //Act
            var barraowdaysmallerthantoday = loancontainer.CheckAvailibilityofBook(loan);

            //Assert
            Assert.IsFalse(barraowdaysmallerthantoday);
        }

        [TestMethod]
        public void BarrowMoreThan3week()
        {//precies na geldige datum
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);
            DateTime date5 = DateTime.Today.AddDays(10);
            DateTime date6 = DateTime.Today.AddDays(70);
            Loan loan2 = new Loan()
            {
                LoanDate = date5,
                ReturnDate = date6,
                BookID = 2,
                UserID = 3,

            };
            //Act
            var morethan3week = loancontainer.CheckAvailibilityofBook(loan2);

            //Assert
            Assert.IsFalse(morethan3week);
        }
        [TestMethod]
        public void BarrowdayBiggerThanReturnDate()
        {
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);
            DateTime date7 = DateTime.Today.AddDays(30);
            DateTime date8 = DateTime.Today.AddDays(5);
            Loan loan3 = new Loan()
            {
                LoanDate = date7,
                ReturnDate = date8,
                BookID = 2,
                UserID = 3,

            };
            //Act
            var barrowdaybiggerthanreturn = loancontainer.CheckAvailibilityofBook(loan3);

            //Assert
            Assert.IsFalse(barrowdaybiggerthanreturn);
        }
        [TestMethod]
        public void GetLoansByUserNone()
        {
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);
            int userid = 3;
            //Act
            var getloansbyuser = loancontainer.GetAllLoansByUser(userid);

            //Assert
            Assert.AreEqual(0, getloansbyuser.Count());
        }
        [TestMethod]
        public void GetLoansByUser()
        {
            //inhoud test
            //Arrange
            LoanContainerMock loancontainermock = new LoanContainerMock();

            LoanContainer loancontainer = new LoanContainer(loancontainermock);
            int userid = 2;
            //Act
            var getloansbyuser = loancontainer.GetAllLoansByUser(userid);

            //Assert
            Assert.AreEqual(1, getloansbyuser.Count());
          
        }




    }
    
}
