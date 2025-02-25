using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using task8._2.Models;

namespace task8._2.Controllers
{
    public class Day8Controller : Controller
    {
        private readonly MyDbContext _context;

        public Day8Controller(MyDbContext context)
        {
            _context = context;
        }







        public IActionResult Index()
        {
            TempData["info"] = HttpContext.Session.GetString("type");

            return View();
        }

        public IActionResult adminindex()
        {

            var users = _context.Day8s.ToList();
            TempData["info"] = HttpContext.Session.GetString("type");
            return View(users);
        }







        public IActionResult Create()
        {
            TempData["info"] = HttpContext.Session.GetString("type");




            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Day8 day8)
        {
            if (ModelState.IsValid)
            {

                day8.Rolee = "user";
                _context.Add(day8);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return RedirectToAction("Create");
        }








        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Day8 day8)
        {
            if (ModelState.IsValid)
            {
                var user1 = _context.Day8s.FirstOrDefault(u => u.Mail == day8.Mail && u.Password == day8.Password);
                if (user1 != null)
                {
                    if (user1.Rolee == "user")
                    {
                        HttpContext.Session.SetString("type", user1.Rolee);
                        HttpContext.Session.SetString("name", user1.Name);
                        HttpContext.Session.SetString("mail", user1.Mail);

                        return RedirectToAction("Index", "product");
                    }
                    else if (user1.Rolee == "admin")
                    {
                        HttpContext.Session.SetString("type", user1.Rolee);
                        HttpContext.Session.SetString("name", user1.Name);
                        HttpContext.Session.SetString("mail", user1.Mail);

                        return RedirectToAction(nameof(adminindex) );
                    }
                }
            }
            return RedirectToAction("Login");

        }








    }
}