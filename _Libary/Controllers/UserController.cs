using _Libary.Models;
using Business;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _Libary.Controllers
{
    public class UserController : Controller
    {

        UserContainer _userContainer = new UserContainer(new UserDAL());

        public IActionResult Login()
        {


            ViewBag.message = TempData["Message"];
            ViewBag.Success = TempData["Success"];
            TempData.Remove("Message");
            TempData.Remove("Success");



            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewModel usermodel)
        {
            User user = new User(new UserDAL());
            var result = user.Checkinformation(usermodel.Email, usermodel.Password);
            var username = _userContainer.GetUserNameByEmail(usermodel.Email);
            var role = _userContainer.GetUserType(usermodel.Email);
            var userId = _userContainer.GetUserIdByEmail(usermodel.Email);



            if (result == true)

            {

                TempData["Success"] = true;
                TempData["Message"] = "Login Succeeded";

                HttpContext.Session.SetString("UserName", username);
                HttpContext.Session.SetString("UserId", userId.ToString());

                HttpContext.Session.SetString("Role", role.ToString());

                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Success = false;
                ViewBag.Message = "Please check your user credentials";
                return View();

            }



        }



        [HttpGet]
        public IActionResult CreateUser()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != null)
            {

                return RedirectToAction("Login", "User");

            }

            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(UserViewModel usermodel)
        {
            if (ModelState.IsValid)
            {
                User user = new User(new UserDAL());
                user.UserName = usermodel.UserName;
                user.Surname = usermodel.Surname;
                user.Email = usermodel.Email;
                user.Password = usermodel.Password;
                user.Rol = usermodel.Rol;
                user.UserID = usermodel.UserID;
                _userContainer.CreateUserAccount(user);
                TempData["Success"] = true;
                TempData["Message"] = "The user is created.";
                return RedirectToAction("Login", "User");
            }

            else
            {
                ViewBag.Success = false;
                ViewBag.Message = "Please check your user credentials";
                return View(usermodel);

            }

        }
        public IActionResult Logout()
        {
            if (HttpContext.Session != null)
            {

                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("Role");
                HttpContext.Session.Remove("UserName");
            }
            return RedirectToAction("Login", "User");
        }


    }
}
