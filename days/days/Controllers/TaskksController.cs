using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using days.Models;

namespace days.Controllers
{
    public class TaskksController : Controller
    {
        private readonly MyDbContext _context;

        public TaskksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Taskks
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Taskks.Include(t => t.Employee);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Taskks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskk = await _context.Taskks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskk == null)
            {
                return NotFound();
            }

            return View(taskk);
        }

        // GET: Taskks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Taskks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,StartDate,EndDate,EmployeeId")] Taskk taskk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", taskk.EmployeeId);
            return View(taskk);
        }

        // GET: Taskks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {

                
                =]
                return NotFound();
            }

            var taskk = await _context.Taskks.FindAsync(id);
            if (taskk == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", taskk.EmployeeId);
            return View(taskk);
        }

        // POST: Taskks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,StartDate,EndDate,EmployeeId")] Taskk taskk)
        {
            if (id != taskk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskkExists(taskk.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", taskk.EmployeeId);
            return View(taskk);
        }

        // GET: Taskks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskk = await _context.Taskks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskk == null)
            {
                return NotFound();
            }

            return View(taskk);
        }

        // POST: Taskks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskk = await _context.Taskks.FindAsync(id);
            if (taskk != null)
            {
                _context.Taskks.Remove(taskk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskkExists(int id)
        {
            return _context.Taskks.Any(e => e.Id == id);
        }
    }
}
