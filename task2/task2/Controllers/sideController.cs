using Microsoft.AspNetCore.Mvc;

namespace task2.Controllers
{
    public class sideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
