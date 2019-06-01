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
    public class IngredientController : Controller
    {
        private readonly MCHeavenContext _context;

        public IngredientController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Ingredient
        public async Task<IActionResult> Index()
        {
            return View(await _context.TIngredient.ToListAsync());
        }

        // GET: Ingredient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIngredient = await _context.TIngredient
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (tIngredient == null)
            {
                return NotFound();
            }

            return View(tIngredient);
        }

        // GET: Ingredient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,NameIngredient,Price")] TIngredient tIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tIngredient);
        }

        // GET: Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIngredient = await _context.TIngredient.FindAsync(id);
            if (tIngredient == null)
            {
                return NotFound();
            }
            return View(tIngredient);
        }

        // POST: Ingredient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,NameIngredient,Price")] TIngredient tIngredient)
        {
            if (id != tIngredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TIngredientExists(tIngredient.IngredientId))
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
            return View(tIngredient);
        }

        // GET: Ingredient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIngredient = await _context.TIngredient
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (tIngredient == null)
            {
                return NotFound();
            }

            return View(tIngredient);
        }

        // POST: Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tIngredient = await _context.TIngredient.FindAsync(id);
            _context.TIngredient.Remove(tIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TIngredientExists(int id)
        {
            return _context.TIngredient.Any(e => e.IngredientId == id);
        }
    }
}
