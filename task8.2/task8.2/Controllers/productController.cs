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

            return View(_context.Users.ToList());
        }

        public IActionResult Details(int id)
        {

            var user = _context.Users.Find(id);


            return View(user);
        }


        public IActionResult Create()
        {

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


            var user = _context.Users.Find(id);

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {

            _context.Update(user);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {


            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
