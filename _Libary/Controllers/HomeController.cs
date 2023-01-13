using _Libary.Models;
using Business;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _Libary.Controllers
{
    public class HomeController : Controller
    {
        User _user = new User(new UserDAL());
        UserContainer _container = new UserContainer(new UserDAL());
        UserViewModel _userViewModel=new UserViewModel();
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Success = TempData["Success"];
            TempData.Remove("Success");
            ViewBag.Message = TempData["Message"];
            TempData.Remove("Message");
            return View();

        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
