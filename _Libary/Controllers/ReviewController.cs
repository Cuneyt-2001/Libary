using _Libary.Models;
using Business;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _Libary.Controllers
{
    public class ReviewController : Controller
    {
        ReviewContainer reviewContainer = new ReviewContainer(new ReviewDAL());
        BookContainer bookContainer = new BookContainer(new BookDAL());
      
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddReview(int id )
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "True" || role == null)
            {
              
                return RedirectToAction("Login", "User");

            }
            var review = new ReviewViewModel { BookID = id };
            var book = bookContainer.GetBook(id);
            ViewBag.BookTitle = book.BookTitle;

            return View(review);
           
        }

        [HttpPost]
        public IActionResult AddReview(ReviewViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var userIdString = HttpContext.Session.GetString("UserId");
                    Review_ review = new Review_();
                    review.UserID = Convert.ToInt32(userIdString);
                    review.Review = model.Review;
                    review.BookID = model.BookID;
                    if(review.BookID==0)
                    {
                        return RedirectToAction("index", "Loan");

                    }
                    reviewContainer.AddReview(review);
                    ViewBag.Success = true;
                    ViewBag.message = "Your Review is saved";
                    //
                    var book = bookContainer.GetBook(model.BookID);
                    ViewBag.BookTitle = book.BookTitle;
                    //
                    return RedirectToAction("index", "Loan");
                }
                else
                {
                    var book = bookContainer.GetBook(model.BookID);
                    ViewBag.BookTitle = book.BookTitle;
                    return View(); 

                }
            
            }
            catch
            {
                var book = bookContainer.GetBook(model.BookID);
                ViewBag.BookTitle = book.BookTitle;
                ViewBag.Success = false;
                ViewBag.message = "Your Review didn't saved";
                return View();
            }
        }



    }

}
