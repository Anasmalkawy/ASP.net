using Microsoft.AspNetCore.Mvc;

namespace master.Models
{
    public class Master : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();

        }
        public IActionResult ask()
        {
            return View();
        }
        public IActionResult profile()
        {
            return View();
        }
    }
}
