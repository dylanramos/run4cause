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
    public class ParticipationsController : Controller
    {
        private readonly Run4causeContext _context;

        public ParticipationsController(Run4causeContext context)
        {
            _context = context;
        }

        // GET: Participations
        public async Task<IActionResult> Index()
        {
            var participations = _context.Participation
                .Include(p => p.Participant)
                .Include(r => r.Run)
                .AsNoTracking();
            return View(await participations.ToListAsync());
        }

        // GET: Participations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation
                .Include(p => p.Participant)
                .Include(r => r.Run)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // GET: Participations/Create
        public IActionResult Create()
        {
            PopulateParticipantsDropDownList();
            PopulateRunsDropDownList();
            return View();
        }

        // POST: Participations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParticipantID,RunID")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                participation.DateTime = DateTime.Now;
                _context.Add(participation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participation);
        }

        // GET: Participations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }
            PopulateParticipantsDropDownList(participation.ParticipantID);
            PopulateRunsDropDownList(participation.RunID);

            return View(participation);
        }

        // POST: Participations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParticipantID,RunID")] Participation participation)
        {
            if (id != participation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    participation.DateTime = DateTime.Now;
                    _context.Update(participation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipationExists(participation.Id))
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
            return View(participation);
        }

        private void PopulateParticipantsDropDownList(object selectedParticipant = null)
        {
            ViewBag.Participants = new SelectList(_context.Participant.AsNoTracking(), "Id", "FullName", selectedParticipant);
        }

        private void PopulateRunsDropDownList(object selectedRun = null)
        {
            ViewBag.Runs = new SelectList(_context.Run.AsNoTracking(), "Id", "Title", selectedRun);
        }

        // GET: Participations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation
                .Include(p => p.Participant)
                .Include(r => r.Run)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participation = await _context.Participation.FindAsync(id);
            _context.Participation.Remove(participation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipationExists(int id)
        {
            return _context.Participation.Any(e => e.Id == id);
        }
    }
}
