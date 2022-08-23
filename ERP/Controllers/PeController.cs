using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace ERP.Controllers
{
    public class PeController : Controller
    {
        private readonly ERP1R82Context _context;

        public PeController(ERP1R82Context context)
        {
            _context = context;
        }

        public Pe Find(int id)
        {
            return _context.Pe.SingleOrDefault(p => p.IdPe == id);
        }
        // GET: Pe

        public async Task<IActionResult> Index(string value, string col)
        {
            FillSelectsWithColumns();

            if (TempData["Deele"] != null)
            {
                ViewBag.Deele = TempData["Deele"];
            }




            var eRPContext = _context.Pe.Include(p => p.IdPeCatNavigation).Where(dn => dn.DaNpe.Date <= DateTime.Now.Date && dn.DaNpe.Date >= DateTime.Now.Date.AddDays(0)).Take(50);
            return View(await eRPContext.ToListAsync());
        }

        // GET: Pe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FillSelectes();
            var pe = await _context.Pe
                .Include(p => p.IdPeCatNavigation)
                .FirstOrDefaultAsync(m => m.IdPe == id);
            if (pe == null)
            {
                return NotFound();
            }

            return View(pe);
        }

        // GET: Pe/Create
        public IActionResult Create()
        {

            FillSelectes();

            return View();
        }

        private void FillSelectes()
        {
            var Per = new SelectList(_context.PeCat, "IdPeCat", "PeCat1");
            ViewData["IdPeCat"] = Per;


            ViewData["TyPe"] = new SelectList(new List<string> { "شخص", "جهة" });

            ViewData["Id1Pe"] = new SelectList(_context.Pe.OrderBy(orderBy => orderBy.NaPe), "IdPe", "NaPe");
        }
        // POST: Pe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPe,NaPe,NatPe,CiPe,JoPe,PhoPe,NotPe,DaPe,CerPe,EmPe,DaNpe,Id1Pe,MetPe,IdPeCat,DaEnPe,TyPe")] Pe pe)
        {

            if (ModelState.IsValid)
            {
                if (pe.PhoPe.Contains('-'))
                {
                    var phones = pe.PhoPe.Split('-');


                    foreach (var phone in phones)
                    {
                        if (phone.Trim().Length > 20)
                        {
                           
                            ModelState.AddModelError(nameof(pe.PhoPe), phone.Trim() + " يحوي اكثر من 20 رقم");
                            return View(pe);
                        }
                        if (_context.Pe.Any(p => p.PhoPe.Trim().Replace(" ", "").Contains(phone.Trim().Replace(" ", ""))))
                        {

                          
                            ModelState.AddModelError(nameof(pe.PhoPe), phone.Trim() + "موجود مسبقاً");
                            return View(pe);

                        }

                    }
                }
                else
                {
                    if (pe.PhoPe.Trim().Length > 20)
                    {

                        ModelState.AddModelError(nameof(pe.PhoPe), pe.PhoPe.Trim() + " يحوي اكثر من 20 رقم");
                        return View(pe);
                    }
                    if (_context.Pe.Any(p => p.PhoPe.Trim().Contains(pe.PhoPe.Trim())))
                    {

                      
                        ModelState.AddModelError(nameof(pe.PhoPe), pe.PhoPe.Trim() + "موجود مسبقاً");
                        return View(pe);

                    }
                }
                if (_context.Pe.SingleOrDefault(p => p.NaPe == pe.NaPe) != null)
                {
                    ViewBag.ChangeName = true;
                }


                else
                {

                    _context.Add(pe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            FillSelectes();

            return View(pe);
        }

        // GET: Pe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pe = await _context.Pe.FindAsync(id);
            if (pe == null)
            {
                return NotFound();
            }
            FillSelectes();
            return View(pe);
        }

        // POST: Pe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPe,NaPe,NatPe,CiPe,JoPe,PhoPe,NotPe,DaPe,CerPe,EmPe,DaNpe,Id1Pe,MetPe,IdPeCat,DaEnPe,TyPe")] Pe pe)
        {
            if (id != pe.IdPe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (pe.PhoPe.Contains('-'))
                {

                    var phones = pe.PhoPe.Split('-');


                    foreach (var phone in phones)
                    {
                        if (phone.Trim().Length > 20)
                        {

                            ModelState.AddModelError(nameof(pe.PhoPe), phone.Trim() + " يحوي اكثر من 20 رقم");
                            return View(pe);
                        }
                        if (_context.Pe.Any(p => p.PhoPe.Trim().Replace(" ", "").Contains(phone.Trim().Replace(" ", ""))&&p.IdPe!=pe.IdPe))
                        {

                           
                            ModelState.AddModelError(nameof(pe.PhoPe), phone.Trim() + "موجود مسبقاً");
                            return View(pe);

                        }

                    }
                }
                else
                {
                    if (pe.PhoPe.Trim().Length > 20)
                    {

                        ModelState.AddModelError(nameof(pe.PhoPe), pe.PhoPe.Trim() + " يحوي اكثر من 20 رقم");
                        return View(pe);
                    }
                    if (_context.Pe.Any(p => p.PhoPe.Trim().Contains(pe.PhoPe)&& p.IdPe!=pe.IdPe))
                    {
                        var p = _context.Pe.Where(id => id.IdPe == pe.IdPe).SingleOrDefault();
                       
                            ViewBag.ChangePhone = true;
                            ModelState.AddModelError(nameof(pe.PhoPe), pe.PhoPe.Trim() + "موجود مسبقاً");
                            return View(pe);

                        

                    }
                }
                if (_context.Pe.SingleOrDefault(p => p.NaPe == pe.NaPe && p.IdPe != pe.IdPe) != null)
                {
                    ViewBag.ChangeName = true;
                }
                else if (_context.Pe.SingleOrDefault(p => p.PhoPe == pe.PhoPe && p.IdPe != pe.IdPe) != null)
                {
                    ViewBag.ChangePhone = true;
                }
                else
                {
                    try
                    {

                        _context.Update(pe);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PeExists(pe.IdPe))
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
                FillSelectes();
                return View(pe);
            }
            FillSelectes();
            //ViewData["IdPeCat"] = new SelectList(_context.PeCat, "IdPeCat", "PeCat1", pe.IdPeCat);
            return View(pe);
        }

        // GET: Pe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pe = await _context.Pe
                .Include(p => p.IdPeCatNavigation)
                .FirstOrDefaultAsync(m => m.IdPe == id);
            if (pe == null)
            {
                return NotFound();
            }

            return View(pe);
        }

        // POST: Pe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var p = _context.Pe.SingleOrDefault(p => p.IdPe == id);
            if (p.Id1Pe == null)
            {
                var pe = await _context.Pe.FindAsync(id);
                _context.Pe.Remove(pe);
                await _context.SaveChangesAsync();
            }

            else
            {
                TempData["Deele"] = "لا يمكن حذف هذا الشخص";
                return RedirectToAction(nameof(Index));
            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string value, string col)
        {
            FillSelectsWithColumns();
            if (!string.IsNullOrEmpty(col))
            {

                var eRPContext = _context.Pe.Include(p => p.IdPeCatNavigation);
                switch (col)
                {

                    case "IdPe":
                        return View(nameof(Index), await eRPContext.Where(c => c.IdPe.ToString() == value).ToListAsync());
                    case "NaPe":
                        return View(nameof(Index), await eRPContext.Where(c => c.NaPe.Contains(value)).ToListAsync());
                    case "IdPeCat":
                        return View(nameof(Index), await eRPContext.Where(c => c.IdPeCatNavigation.PeCat1.Contains(value)).ToListAsync());
                    case "JoPe":
                        return View(nameof(Index), await eRPContext.Where(c => c.JoPe.Contains(value)).ToListAsync());
                    case "DaPe":
                        try
                        {
                            return View(nameof(Index), await eRPContext.Where(c => c.DaPe.Date == Convert.ToDateTime(value)).ToListAsync());
                        }
                        catch
                        {
                            return View(nameof(Index));
                        }
                    case "DaEnPe":
                        try
                        {
                            return View(nameof(Index), await eRPContext.Where(c => c.DaEnPe.Date == Convert.ToDateTime(value)).ToListAsync());
                        }
                        catch
                        {
                            return View(nameof(Index));
                        }
                    case "PhoPe":
                        return View(nameof(Index), await eRPContext.Where(c => c.PhoPe.Contains(value.Trim())).ToListAsync());
                    default: return View(await eRPContext.ToListAsync());
                }
            }
            else
            {
                try
                {
                    var time = Convert.ToDateTime(value);
                    var eRPContext = _context.Pe.Include(p => p.IdPeCatNavigation).Where
                    (
                    c => c.DaPe.Date == Convert.ToDateTime(value) ||
                    c.DaEnPe.Date == Convert.ToDateTime(value)
                    );
                    return View("Index", await eRPContext.ToListAsync());
                }
                catch
                {
                    var eRPContext = _context.Pe.Include(p => p.IdPeCatNavigation).Where
                   (
                   c => c.NaPe.Contains(value) ||
                   c.IdPe.ToString() == value ||
                   c.IdPeCatNavigation.PeCat1.Contains(value) ||
                   c.JoPe.Contains(value) ||
                   c.PhoPe.Contains(value.Trim())
                   );
                    return View("Index", await eRPContext.ToListAsync());
                }
            }



        }

        private bool PeExists(int id)
        {
            return _context.Pe.Any(e => e.IdPe == id);
        }
        //to show column names in select list item in index page  
        private void FillSelectsWithColumns()
        {
            List<SelectListItem> columns = new List<SelectListItem>();
            foreach (var field in typeof(Pe).GetProperties())
            {
                MemberInfo property = typeof(Pe).GetProperty(field.Name);
                var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (dd != null)
                {
                    if (field.Name == "IdPe" || field.Name == "NaPe" || field.Name == "IdPeCat" || field.Name == "JoPe" || field.Name == "DaPe" || field.Name == "DaEnPe" || field.Name == "PhoPe")
                        columns.Add(new SelectListItem
                        {
                            Value = field.Name,
                            Text = dd.Name
                        });
                }
            }
            ViewBag.col = columns;
        }

    }
}
