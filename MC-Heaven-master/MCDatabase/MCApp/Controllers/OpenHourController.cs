using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCApp.Models;

namespace MCApp.Controllers
{
    public class OpenHourController : Controller
    {
        private readonly MCHeavenContext _context;

        public OpenHourController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: OpenHour
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TOpenHour.Include(t => t.Shop);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: OpenHour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOpenHour = await _context.TOpenHour
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.OpenHourId == id);
            if (tOpenHour == null)
            {
                return NotFound();
            }

            return View(tOpenHour);
        }

        // GET: OpenHour/Create
        public IActionResult Create()
        {
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop");
            return View();
        }

        // POST: OpenHour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpenHourId,FromO,ToO,IsSunday,IsSaturday,ShopId")] TOpenHour tOpenHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOpenHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tOpenHour.ShopId);
            return View(tOpenHour);
        }

        // GET: OpenHour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOpenHour = await _context.TOpenHour.FindAsync(id);
            if (tOpenHour == null)
            {
                return NotFound();
            }
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tOpenHour.ShopId);
            return View(tOpenHour);
        }

        // POST: OpenHour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpenHourId,FromO,ToO,IsSunday,IsSaturday,ShopId")] TOpenHour tOpenHour)
        {
            if (id != tOpenHour.OpenHourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOpenHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOpenHourExists(tOpenHour.OpenHourId))
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
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tOpenHour.ShopId);
            return View(tOpenHour);
        }

        // GET: OpenHour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOpenHour = await _context.TOpenHour
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.OpenHourId == id);
            if (tOpenHour == null)
            {
                return NotFound();
            }

            return View(tOpenHour);
        }

        // POST: OpenHour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOpenHour = await _context.TOpenHour.FindAsync(id);
            _context.TOpenHour.Remove(tOpenHour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOpenHourExists(int id)
        {
            return _context.TOpenHour.Any(e => e.OpenHourId == id);
        }
    }
}
