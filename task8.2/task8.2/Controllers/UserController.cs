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
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {


            TempData["info"] = HttpContext.Session.GetString("type");
            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            return View(await _context.Day8s.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            if (id == null)
            {
                return NotFound();
            }

            var day8 = await _context.Day8s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (day8 == null)
            {
                return NotFound();
            }

            return View(day8);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mail,Password,Rolee")] Day8 day8)
        {
            TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            if (ModelState.IsValid)
            {
                _context.Add(day8);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(day8);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            if (id == null)
            {
                return NotFound();
            }

            var day8 = await _context.Day8s.FindAsync(id);
            if (day8 == null)
            {
                return NotFound();
            }
            return View(day8);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mail,Password,Rolee")] Day8 day8)
        {
                        TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            if (id != day8.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(day8);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Day8Exists(day8.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(day8);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            if (id == null)
            {
                return NotFound();
            }

            var day8 = await _context.Day8s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (day8 == null)
            {
                return NotFound();
            }

            return View(day8);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
                        TempData["info"] = HttpContext.Session.GetString("type");

            TempData["name"] = HttpContext.Session.GetString("name");
            TempData["mail"] = HttpContext.Session.GetString("mail");
            var day8 = await _context.Day8s.FindAsync(id);
            if (day8 != null)
            {
                _context.Day8s.Remove(day8);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Day8Exists(int id)
        {
            return _context.Day8s.Any(e => e.Id == id);
        }
    }
}
