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
    public class SizeController : Controller
    {
        private readonly MCHeavenContext _context;

        public SizeController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Size
        public async Task<IActionResult> Index()
        {
            return View(await _context.TSize.ToListAsync());
        }

        // GET: Size/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSize = await _context.TSize
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (tSize == null)
            {
                return NotFound();
            }

            return View(tSize);
        }

        // GET: Size/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Size/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SizeId,TypeSize")] TSize tSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tSize);
        }

        // GET: Size/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSize = await _context.TSize.FindAsync(id);
            if (tSize == null)
            {
                return NotFound();
            }
            return View(tSize);
        }

        // POST: Size/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SizeId,TypeSize")] TSize tSize)
        {
            if (id != tSize.SizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSizeExists(tSize.SizeId))
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
            return View(tSize);
        }

        // GET: Size/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSize = await _context.TSize
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (tSize == null)
            {
                return NotFound();
            }

            return View(tSize);
        }

        // POST: Size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSize = await _context.TSize.FindAsync(id);
            _context.TSize.Remove(tSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TSizeExists(int id)
        {
            return _context.TSize.Any(e => e.SizeId == id);
        }
    }
}
