using System.Diagnostics;
using System.Xml.Linq;
using day3.Models;
using Microsoft.AspNetCore.Mvc;

namespace day3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult index(double number1, double number2, string operation)
        {
            double result = 0;
            switch (operation.ToLower())
            {
                case "add":
                    result = number1 + number2;
                    break;
                case "subtract":
                    result = number1 - number2;
                    break;
                case "multiply":
                    result = number1 * number2;
                    break;
                case "divide":
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                    }
                    else
                    {
                        ViewData["Result"] = "Cannot divide by zero.";
                        return View("Index");
                    }
                    break;
                default:
                    ViewData["Result"] = "Invalid operation.";
                    return View("Index");
            }

            ViewData["Result"] = result;
            return View("Index");
        }

        public IActionResult Privacy()
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
