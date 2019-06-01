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
    public class DrinkController : Controller
    {
        private readonly MCHeavenContext _context;

        public DrinkController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Drink
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TDrink.Include(t => t.Ingredient).Include(t => t.Size);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: Drink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDrink = await _context.TDrink
                .Include(t => t.Ingredient)
                .Include(t => t.Size)
                .FirstOrDefaultAsync(m => m.DrinkId == id);
            if (tDrink == null)
            {
                return NotFound();
            }

            return View(tDrink);
        }

        // GET: Drink/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.TIngredient, "IngredientId", "NameIngredient");
            ViewData["SizeId"] = new SelectList(_context.TSize, "SizeId", "TypeSize");
            return View();
        }

        // POST: Drink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrinkId,DrinkName,Price,ParentDrinkId,SizeId,IngredientId")] TDrink tDrink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tDrink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientId"] = new SelectList(_context.TIngredient, "IngredientId", "NameIngredient", tDrink.IngredientId);
            ViewData["SizeId"] = new SelectList(_context.TSize, "SizeId", "TypeSize", tDrink.SizeId);
            return View(tDrink);
        }

        // GET: Drink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDrink = await _context.TDrink.FindAsync(id);
            if (tDrink == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.TIngredient, "IngredientId", "NameIngredient", tDrink.IngredientId);
            ViewData["SizeId"] = new SelectList(_context.TSize, "SizeId", "TypeSize", tDrink.SizeId);
            return View(tDrink);
        }

        // POST: Drink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrinkId,DrinkName,Price,ParentDrinkId,SizeId,IngredientId")] TDrink tDrink)
        {
            if (id != tDrink.DrinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tDrink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TDrinkExists(tDrink.DrinkId))
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
            ViewData["IngredientId"] = new SelectList(_context.TIngredient, "IngredientId", "NameIngredient", tDrink.IngredientId);
            ViewData["SizeId"] = new SelectList(_context.TSize, "SizeId", "TypeSize", tDrink.SizeId);
            return View(tDrink);
        }

        // GET: Drink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDrink = await _context.TDrink
                .Include(t => t.Ingredient)
                .Include(t => t.Size)
                .FirstOrDefaultAsync(m => m.DrinkId == id);
            if (tDrink == null)
            {
                return NotFound();
            }

            return View(tDrink);
        }

        // POST: Drink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tDrink = await _context.TDrink.FindAsync(id);
            _context.TDrink.Remove(tDrink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TDrinkExists(int id)
        {
            return _context.TDrink.Any(e => e.DrinkId == id);
        }
    }
}
