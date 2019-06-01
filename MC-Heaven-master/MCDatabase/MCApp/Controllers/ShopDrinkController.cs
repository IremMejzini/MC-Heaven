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
    public class ShopDrinkController : Controller
    {
        private readonly MCHeavenContext _context;

        public ShopDrinkController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: ShopDrink
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TShopDrink.Include(t => t.Drink).Include(t => t.Shop);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: ShopDrink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tShopDrink = await _context.TShopDrink
                .Include(t => t.Drink)
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.DrinkId == id);
            if (tShopDrink == null)
            {
                return NotFound();
            }

            return View(tShopDrink);
        }

        // GET: ShopDrink/Create
        public IActionResult Create()
        {
            ViewData["DrinkId"] = new SelectList(_context.TDrink, "DrinkId", "DrinkName");
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop");
            return View();
        }

        // POST: ShopDrink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrinkId,ShopId")] TShopDrink tShopDrink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tShopDrink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrinkId"] = new SelectList(_context.TDrink, "DrinkId", "DrinkName", tShopDrink.DrinkId);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tShopDrink.ShopId);
            return View(tShopDrink);
        }

        // GET: ShopDrink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tShopDrink = await _context.TShopDrink.FindAsync(id);
            if (tShopDrink == null)
            {
                return NotFound();
            }
            ViewData["DrinkId"] = new SelectList(_context.TDrink, "DrinkId", "DrinkName", tShopDrink.DrinkId);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tShopDrink.ShopId);
            return View(tShopDrink);
        }

        // POST: ShopDrink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrinkId,ShopId")] TShopDrink tShopDrink)
        {
            if (id != tShopDrink.DrinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tShopDrink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TShopDrinkExists(tShopDrink.DrinkId))
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
            ViewData["DrinkId"] = new SelectList(_context.TDrink, "DrinkId", "DrinkName", tShopDrink.DrinkId);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tShopDrink.ShopId);
            return View(tShopDrink);
        }

        // GET: ShopDrink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tShopDrink = await _context.TShopDrink
                .Include(t => t.Drink)
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.DrinkId == id);
            if (tShopDrink == null)
            {
                return NotFound();
            }

            return View(tShopDrink);
        }

        // POST: ShopDrink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tShopDrink = await _context.TShopDrink.FindAsync(id);
            _context.TShopDrink.Remove(tShopDrink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TShopDrinkExists(int id)
        {
            return _context.TShopDrink.Any(e => e.DrinkId == id);
        }
    }
}
