using Microsoft.AspNetCore.Mvc;

namespace task2.Controllers
{
    public class cardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
