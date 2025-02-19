using System.Diagnostics;
using Day4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Reg()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Reg(string fname,string lname ,string mail,string pass)
        {
            TempData["data0"] = fname;
            TempData["data1"] = lname;
            TempData["data2"] = mail;
            TempData["data3"] = pass;

            return RedirectToAction("Log");
        }

   
        public IActionResult Log()
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
