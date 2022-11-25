using _Libary.Models;
using Business;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _Libary.Controllers
{
    public class BookController : Controller
    {


        BookContainer _book = new BookContainer(new BookDAL());
        //
        CategoryContainer _category = new CategoryContainer(new CategoryDAL());

        //

        [HttpGet]
        public ActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "False" || role == null)
            {

                return RedirectToAction("Login", "User");

            }


            List<BookViewModel> bookViewModel = new List<BookViewModel>();
            List<Book> books = _book.GetBooks();
            foreach (Book b in books)
            {
                var bookCategories = _category.GetBookCategoriesByBookId(b.BookID);
                var catIds = bookCategories.Select(c => c.CategoryID).ToList();
                var categories = new List<Category>();

                if (bookCategories != null)
                {
                    categories = _category.GetAllCategoriesByIds(catIds).Select(a => new Category { CategoryID = a.CategoryID, CategoryName = a.CategoryName }).ToList();
                }
                bookViewModel.Add(new BookViewModel(b, categories));
            }

            ViewBag.Success = TempData["Success"];
            TempData.Remove("Success");
            ViewBag.Message = TempData["Message"];
            TempData.Remove("Message");

            return View(bookViewModel);

        }

        [HttpGet]
        public ActionResult AddBook()
        {

            var role = HttpContext.Session.GetString("Role");
            if (role == "False" || role == null)
            {

                return RedirectToAction("Login", "User");

            }

            ViewBag.Categories = _book.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BookViewModel model, int[] categoryIds)
        {
          
                try
                {
                if (ModelState.IsValid)
                {
                    Book book = new Book();
                    book.Author = model.Author;
                    book.ISBN = model.ISBN;
                    book.BookID = model.BookID;
                    book.BookTitle = model.BookTitle;
                    book.Publisher = model.Publisher;
                    var bookId = _book.AddBook(book);




                    foreach (var item in categoryIds)
                    {
                        var category = new
                        {
                            CategoryID = item,
                            BookID = bookId
                        };
                        _category.AddBookCategory(item, bookId);
                    }
                    TempData["Success"] = true;
                    TempData["Message"] = "The book is added.";


                    return RedirectToAction("index", "Book");
                }
                else
                {
                    TempData["Success"] = false;
                    TempData["Message"] = "Adding book failed.";
                    return View(model);
                }
                
                
            }
            catch
            {
                TempData["Success"] = false;
                TempData["Message"] = "Adding book failed.";
                return RedirectToAction("index", "Book");
            }
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
            foreach (Book b in books)
            {

                bookViewModel.Add(new BookViewModel(b));
            }

            return View(bookViewModel);

            if (BookTitel == null)
            {

                return RedirectToAction("index", "Book");
            }




        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "False" || role == null)
            {

                return RedirectToAction("Login", "User");

            }
            try
            {
                Book book = _book.GetBook(id);
                BookViewModel model = new BookViewModel(book);
                var bookCategories = _category.GetBookCategoriesByBookId(id);
                var catIds = bookCategories.Select(c => c.CategoryID).ToList();
                var categories = new List<Category>();
                ViewBag.Categories = _book.GetCategories();
                if (bookCategories != null)
                {
                    categories = _category.GetAllCategoriesByIds(catIds).Select(a => new Category { CategoryID = a.CategoryID, CategoryName = a.CategoryName }).ToList();
                }
                model.Categories = categories;
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }


        }

        [HttpPost]
        public ActionResult UpdateBook(BookViewModel model, int[] categoryIds)
        {
            Book book = new Book(new BookDAL());
            book.Author = model.Author;
            book.ISBN = model.ISBN;
            book.BookID = model.BookID;
            book.Publisher = model.Publisher;
            book.BookTitle = model.BookTitle;
       


            var bookid = book.EditBook(book);

            var bookCategories = _category.GetBookCategoriesByBookId(book.BookID);
            if (bookCategories != null)
            {
                foreach (var item in bookCategories)
                {
                    try
                    {
                        _category.DeleteBookCategory(item.ID);
                    }
                    catch
                    {
                        ViewBag.Success = false;
                        ViewBag.Message = "The book could not be updated";
                        return View();
                    }
                }
            }

            foreach (var item in categoryIds)
            {
                try
                {
                    _category.AddBookCategory(item, book.BookID);
                }
                catch (Exception ex)
                {
                    ViewBag.Success = false;
                    ViewBag.Message = "The book could not be updated";
                    return View();
                }
            }



            TempData["Success"] = true;
            TempData["Message"] = "The book has been successfully updated";
            return RedirectToAction("index", "Book");
        }


        [HttpPost]
        public IActionResult RemoveBook(BookViewModel model)
        {
            try
            {
                _book.RemoveBook(model.BookID);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }
        }

        [HttpGet]
        public IActionResult RemoveBook(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "False" || role == null)
            {

                return RedirectToAction("Login", "User");

            }
            try
            {
                Book book = _book.GetBook(id);

                BookViewModel model = new BookViewModel(book);

                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }



    }
}


