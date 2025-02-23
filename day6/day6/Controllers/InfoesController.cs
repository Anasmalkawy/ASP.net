using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using day6.Models;

namespace day6.Controllers
{
    public class InfoesController : Controller
    {
        private readonly MyDbContext _context;

        public InfoesController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Info.ToList());
        }






       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Info info)
        {
                _context.Add(info);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }






    }
}
