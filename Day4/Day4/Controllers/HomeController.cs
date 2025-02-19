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
            HttpContext.Session.SetString("fname", fname);
            HttpContext.Session.SetString("lname", lname);
            HttpContext.Session.SetString("mail", mail);
            HttpContext.Session.SetString("pass", pass);

            //TempData["data01"] = fname;
            //TempData["data1"] = lname;
            //TempData["data2"] = mail;
            //TempData["data3"] = pass;

            return RedirectToAction("Log");
        }

        [HttpGet]
        public IActionResult Log()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Log_ok(string log1, string log2)
        {
           string nmail= HttpContext.Session.GetString("mail");
           string npass = HttpContext.Session.GetString("pass");
            if ( nmail== log1 && npass == log2)
            {
                return RedirectToAction("Index", "Home2");

            }
            else
            {
                return View();

            }
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
