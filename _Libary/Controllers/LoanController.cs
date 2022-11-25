using _Libary.Models;
using Business;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _Libary.Controllers
{

    public class LoanController : Controller
    {
        BookContainer _book = new BookContainer(new BookDAL());
        LoanContainer _loon = new LoanContainer(new LoanDAL());
        UserContainer _user = new UserContainer(new UserDAL());
        UserViewModel _userViewModel = new UserViewModel();
        CategoryContainer _category = new CategoryContainer(new CategoryDAL());
     


        [HttpGet]
        public ActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "True" || role == null)
            {
               
                return RedirectToAction("Login", "User");

            }

            UserViewModel userViewModel = new UserViewModel();
            

            List<BookViewModel> bookViewModel = new List<BookViewModel>();
            List<Book> books = _book.GetBooks();
            foreach (Book b in books)
            {
                var bookCategories = _category.GetBookCategoriesByBookId(b.BookID);
                var catIds = bookCategories.Select(c => c.CategoryID).ToList();
                var categories = new List<Category>();
                bookViewModel.Add(new BookViewModel(b));
                if (bookCategories != null)
                {
                    categories = _category.GetAllCategoriesByIds(catIds).Select(a => new Category { CategoryID = a.CategoryID, CategoryName = a.CategoryName }).ToList();
                }
                bookViewModel.Add(new BookViewModel(b, categories));
            }

           

            ViewBag.Success = TempData["Success"];
            ViewBag.Message = TempData["Message"];
            TempData.Remove("Success");
            TempData.Remove("Message");

            return View(bookViewModel);
        }

        [HttpPost]
        public ActionResult Index(string BookTitel)
        {
            if (BookTitel == null)
            {
                return this.Index();
            }
            List<BookViewModel> bookViewModel = new List<BookViewModel>();
            List<Book> books = _book.SearchBook(BookTitel);
            foreach (Book book in books)
            {

                bookViewModel.Add(new BookViewModel(book));
            }

            return View(bookViewModel);

            if (BookTitel == null)
            {

                return RedirectToAction("index", "Loan");
            }

        }

        [HttpGet]
        public ActionResult AddLoan(int? id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "True" || role == null)
            {
               
                return RedirectToAction("Login", "User");

            }
            if (id == null)
            {
                return NotFound("id can not be 0");
            }
            var book = _book.GetBook(id.Value);
            if (book == null)
            {
                return NotFound("There is no book");    
            }

            var model = new LoanViewModel
            {
                BookID = book.BookID,
                LoanDate =DateTime.Now,
                ReturnDate = DateTime.Now
            };
            ViewBag.BookTitle = book.BookTitle;

            ViewBag.Success = TempData["Success"];
            ViewBag.Message = TempData["Message"];
            return View(model);
        }

        [HttpPost]
        public ActionResult AddLoan(LoanViewModel model)
        {
       

            try
            {
                var userIdString = HttpContext.Session.GetString("UserId");
                var loan = new Loan {
                    BookID = model.BookID,
                    LoanDate= model.LoanDate,                    
                    ReturnDate= model.ReturnDate,
                    UserID = Convert.ToInt32(userIdString)
                };
                if (_loon.CheckAvailibilityofBook(loan)==true)
                {
                    _loon.AddLoan(loan);

                    TempData["Success"] = true;
                    TempData["Message"] = "Your Loan Request is successfully completed";

                    return RedirectToAction("index", "Loan");
                }

                ViewBag.Success = false;
                ViewBag.Message = "there is a problem or the book has already been borrowed between these dates!";
                var book = _book.GetBook(model.BookID);
                ViewBag.BookTitle = book.BookTitle;
                return View(model);
               
                
              
            }
            catch
            {
                ViewBag.Success = false;
                ViewBag.Message = "there is a problem or the book has already been borrowed between these dates!";
                var book = _book.GetBook(model.BookID);
                ViewBag.BookTitle = book.BookTitle;
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult GetAllLoans()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "False" || role == null)
            {
               
                return RedirectToAction("Login", "User");

            }
            var loans = _loon.GetAllLoans();
            var books = _book.GetBooks();
            var users = _user.GetAllUsers();


            List<LoanViewModel> Loanviewmodels=new List<LoanViewModel>();
            foreach(Loan loan in loans)
            {
                var userName = "";
                var bookTitle = "";
                var book = books.FirstOrDefault(a => a.BookID == loan.BookID);
                var user = users.FirstOrDefault(a => a.UserID == loan.UserID);
                if (book!=null)
                {
                    bookTitle=book.BookTitle;
                }
                if (user!=null)
                {
                    userName = user.UserName;
                }
                Loanviewmodels.Add(new LoanViewModel(loan, bookTitle, userName));
            }
            return View (Loanviewmodels);
        }

        public ActionResult UserLoan()
        {
            var role = HttpContext.Session.GetString("Role");
            var userId =Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if (role == "True" || role == null)
            {

                return RedirectToAction("Login", "User");

            }
            var loans = _loon.GetAllLoans();
           
            loans = loans.Where(a => a.UserID == userId).ToList();
            var books = _book.GetBooks();

            var users = _user.GetAllUsers();


            List<LoanViewModel> Loanviewmodels = new List<LoanViewModel>();
            foreach (Loan loan in loans)
            {
                var userName = "";
                var bookTitle = "";
                var book = books.FirstOrDefault(a => a.BookID == loan.BookID);
                var user = users.FirstOrDefault(a => a.UserID == loan.UserID);
                if (book != null)
                {
                    bookTitle = book.BookTitle;
                }
                if (user != null)
                {
                    userName = user.UserName;
                }
                Loanviewmodels.Add(new LoanViewModel(loan, bookTitle, userName));
            }
            return View(Loanviewmodels);
        }
        

    }
}
