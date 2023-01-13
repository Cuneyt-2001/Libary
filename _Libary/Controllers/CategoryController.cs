using _Libary.Models;
using Business;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Libary.Controllers
{
    public class CategoryController:Controller
    {


         internal CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL());



        [HttpGet]
        public IActionResult AddCategory()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "False" || role == null)
            {
                
                return RedirectToAction("Login", "User");

            }

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            try
            {

                Category category = new Category();
                category.CategoryID = model.CategoryID;
                category.CategoryName = model.CategoryName;
                var issamerecord = categoryContainer.PreventDoublecategory(category.CategoryName);
                if (issamerecord == true)
                {
                    categoryContainer.AddCategory(category);
                    ViewBag.Message = "Category added.";

                    ViewBag.Success = true;
                }
                else
                {
                    ViewBag.Message = "Category is already exist";
                    ViewBag.Success=false;
                }


                return View(); 
            }
            catch
            {
                ViewBag.Message = "Category couldn't add.";
                ViewBag.Success = false;

                return View(model);
            }
        }



    }
}
