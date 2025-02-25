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
    public class qqqqqqqqqqqController : Controller
    {
        private readonly MyDbContext _context;

        public qqqqqqqqqqqController(MyDbContext context)
        {
            _context = context;
        }

        // GET: qqqqqqqqqqq
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegUsers.ToListAsync());
        }

        // GET: qqqqqqqqqqq/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regUser = await _context.RegUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regUser == null)
            {
                return NotFound();
            }

            return View(regUser);
        }

        // GET: qqqqqqqqqqq/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: qqqqqqqqqqq/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mail,Name,Pasword")] RegUser regUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regUser);
        }

        // GET: qqqqqqqqqqq/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regUser = await _context.RegUsers.FindAsync(id);
            if (regUser == null)
            {
                return NotFound();
            }
            return View(regUser);
        }

        // POST: qqqqqqqqqqq/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mail,Name,Pasword")] RegUser regUser)
        {
            if (id != regUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegUserExists(regUser.Id))
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
            return View(regUser);
        }

        // GET: qqqqqqqqqqq/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regUser = await _context.RegUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regUser == null)
            {
                return NotFound();
            }

            return View(regUser);
        }

        // POST: qqqqqqqqqqq/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regUser = await _context.RegUsers.FindAsync(id);
            if (regUser != null)
            {
                _context.RegUsers.Remove(regUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegUserExists(int id)
        {
            return _context.RegUsers.Any(e => e.Id == id);
        }
    }
}
