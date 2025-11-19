using AMAN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AMAN.Areas.Identity.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;





namespace AMAN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]

        public IActionResult Index1()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
               
                return RedirectToAction("Index");
            }
            
            return Redirect("/Identity/Account/Login");
        }


        [Authorize]
        public IActionResult Index()
        {

            var email = HttpContext.Session.GetString("UserEmail");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About1()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
