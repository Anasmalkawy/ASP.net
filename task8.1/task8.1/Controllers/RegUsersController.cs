using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task8._1.Models;

namespace task8._1.Controllers
{
    public class RegUsersController : Controller
    {
        private readonly MyDbContext _context;

        public RegUsersController(MyDbContext context)
        {
            _context = context;
        }




      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegUser regUser)
        {
                _context.Add(regUser);
                _context.SaveChanges();
                return RedirectToAction("Log");
        }





        public IActionResult Log()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log(RegUser regUser)
        {
            var user = _context.RegUsers.FirstOrDefault(u => u.Mail == regUser.Mail && u.Pasword == regUser.Pasword);
            TempData["UserName"] = user.Name;
            return RedirectToAction("Home");
        }


        public IActionResult Home()
        {
            return View();
        }


    }
}
