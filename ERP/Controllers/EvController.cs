using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP.Models;

namespace ERP.Controllers
{
    public class EvController : Controller
    {
        private readonly ERP1R82Context _context;

        public EvController(ERP1R82Context context)
        {
            _context = context;
        }

        // GET: Ev
        public async Task<IActionResult> Index()
        {
            var eRP1R82Context = _context.Ev.Include(e => e.CoPrNavigation).Include(e => e.IdEvRefNavigation).Include(e=>e.IdPeNavigation);
            return View(await eRP1R82Context.ToListAsync());
        }

        // GET: Ev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = await _context.Ev
                .Include(e => e.CoPrNavigation)
                .Include(e => e.IdEvRefNavigation)
                .FirstOrDefaultAsync(m => m.IdEv == id);
            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // GET: Ev/Create
        public IActionResult Create()
        {
            ViewData["CoPr"] = new SelectList(_context.Pr, "CoPr", "CoPr");
            ViewData["IdEvRef"] = new SelectList(_context.EvRef, "IdEvRef", "NaEvRef");
            ViewData["IdPe"] = new SelectList(_context.Pe, "IdPe", "NaPe");
            return View();
        }

        // POST: Ev/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEv,DaEv,Ti1Ev,TitEv,ExEv,NotEv,PlEv,DaNev,IdPe,CoPr,IdEvRef,ArEv,Ti2Ev")] Ev ev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoPr"] = new SelectList(_context.Pr, "CoPr", "CoPr", ev.CoPr);
            ViewData["IdEvRef"] = new SelectList(_context.EvRef, "IdEvRef", "NaEvRef", ev.IdEvRef);
            return View(ev);
        }

        // GET: Ev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = await _context.Ev.FindAsync(id);
            if (ev == null)
            {
                return NotFound();
            }
            ViewData["CoPr"] = new SelectList(_context.Pr, "CoPr", "CoPr", ev.CoPr);
            ViewData["IdEvRef"] = new SelectList(_context.EvRef, "IdEvRef", "NaEvRef", ev.IdEvRef);
            return View(ev);
        }

        // POST: Ev/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEv,DaEv,Ti1Ev,TitEv,ExEv,NotEv,PlEv,DaNev,IdPe,CoPr,IdEvRef,ArEv,Ti2Ev")] Ev ev)
        {
            if (id != ev.IdEv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvExists(ev.IdEv))
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
            ViewData["CoPr"] = new SelectList(_context.Pr, "CoPr", "CoPr", ev.CoPr);
            ViewData["IdEvRef"] = new SelectList(_context.EvRef, "IdEvRef", "NaEvRef", ev.IdEvRef);
            return View(ev);
        }

        // GET: Ev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = await _context.Ev
                .Include(e => e.CoPrNavigation)
                .Include(e => e.IdEvRefNavigation)
                .FirstOrDefaultAsync(m => m.IdEv == id);
            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // POST: Ev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ev = await _context.Ev.FindAsync(id);
            _context.Ev.Remove(ev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvExists(int id)
        {
            return _context.Ev.Any(e => e.IdEv == id);
        }
    }
}
