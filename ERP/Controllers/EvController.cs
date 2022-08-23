using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP.Models;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Search(string value, string col)
        {
            FillSelectsWithColumns();
            if (!string.IsNullOrEmpty(col))
            {

                var eRPContext = _context.Ev;
                switch (col)
                {

                    case "IdEv":
                        try
                        {
                           int id= int.Parse(value);
                            return View(nameof(Index), await eRPContext.Where(e => e.IdEv == id).ToListAsync());
                        }
                        catch
                        {
                            return View(nameof(Index));
                        }
                        return View(nameof(Index), await eRPContext.Where(c => c.IdPe.ToString() == value).ToListAsync());
                    case "CoPr":
                       return View(nameof(Index), await eRPContext.Where(c => c.CoPr.Contains(value)).ToListAsync());
                    //case "IdPeCat":
                    //    return View(nameof(Index), await eRPContext.Where(c => c.IdPeCatNavigation.PeCat1.Contains(value)).ToListAsync());
                    //case "JoPe":
                    //    return View(nameof(Index), await eRPContext.Where(c => c.JoPe.Contains(value)).ToListAsync());
                    //case "DaPe":
                    //    try
                    //    {
                    //        return View(nameof(Index), await eRPContext.Where(c => c.DaPe.Date == Convert.ToDateTime(value)).ToListAsync());
                    //    }
                    //    catch
                    //    {
                    //        return View(nameof(Index));
                    //    }
                    //case "DaEnPe":
                    //    try
                    //    {
                    //        return View(nameof(Index), await eRPContext.Where(c => c.DaEnPe.Date == Convert.ToDateTime(value)).ToListAsync());
                    //    }
                    //    catch
                    //    {
                    //        return View(nameof(Index));
                    //    }
                    //case "PhoPe":
                    //    return View(nameof(Index), await eRPContext.Where(c => c.PhoPe.Contains(value.Trim())).ToListAsync());
                    default: return View(await eRPContext.ToListAsync());
                }
            }
            else
            {
               
              
                    var eRPContext = _context.Ev.Where
                   (
                   c => c.IdEv.ToString().Contains(value) ||
                   c.CoPr.Contains(value)
                   
                 
                   );
                    return View(nameof(Index), await eRPContext.ToListAsync());
                
            }



        }
        public async Task<IActionResult> Index()
        {
            FillSelectsWithColumns();
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
        private void FillSelectsWithColumns()
        {
            List<SelectListItem> columns = new List<SelectListItem>();
            foreach (var field in typeof(Ev).GetProperties())
            {
                MemberInfo property = typeof(Ev).GetProperty(field.Name);
                var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (dd != null)
                {
                    if (field.Name == "IdEv" || field.Name == "CoPr" || field.Name == "IdPeCat" || field.Name == "JoPe" || field.Name == "DaPe" || field.Name == "DaEnPe" || field.Name == "PhoPe")
                        columns.Add(new SelectListItem
                        {
                            Value = field.Name,
                            Text = dd.Name
                        });
                }
            }
            ViewBag.col = columns;
        }

        private bool EvExists(int id)
        {
            return _context.Ev.Any(e => e.IdEv == id);
        }
    }
}
