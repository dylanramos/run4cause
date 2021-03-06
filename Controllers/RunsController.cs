#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using run4cause.Data;
using run4cause.Models;

namespace run4cause.Controllers
{
    public class RunsController : Controller
    {
        private readonly Run4causeContext _context;

        public RunsController(Run4causeContext context)
        {
            _context = context;
        }

        // GET: Runs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Run.ToListAsync());
        }

        // GET: Runs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Run
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // GET: Runs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Runs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Run run)
        {
            if (ModelState.IsValid)
            {
                _context.Add(run);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(run);
        }

        // GET: Runs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Run.FindAsync(id);
            if (run == null)
            {
                return NotFound();
            }
            return View(run);
        }

        // POST: Runs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Run run)
        {
            if (id != run.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(run);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunExists(run.Id))
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
            return View(run);
        }

        // GET: Runs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Run
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // POST: Runs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var run = await _context.Run.FindAsync(id);
            _context.Run.Remove(run);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunExists(int id)
        {
            return _context.Run.Any(e => e.Id == id);
        }
    }
}
