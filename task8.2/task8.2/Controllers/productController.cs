using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task8._2.Models;

namespace task8._2.Controllers
{
    public class productController : Controller
    {
        private readonly MyDbContext _context;

        public productController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            return View(_context.Users.ToList());
        }

        public IActionResult Details(int id)
        {
            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            var user = _context.Users.Find(id);


            return View(user);
        }


        public IActionResult Create()
        {
            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {

            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");


            var user = _context.Users.Find(id);

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            _context.Update(user);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");

            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
