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
    public class AddressController : Controller
    {
        private readonly MCHeavenContext _context;

        public AddressController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Address
        public async Task<IActionResult> Index()
        {
            return View(await _context.TAddress.ToListAsync());
        }

        // GET: Address/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAddress = await _context.TAddress
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (tAddress == null)
            {
                return NotFound();
            }

            return View(tAddress);
        }

        // GET: Address/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,Street,HouseNumber,FlatNumber,PostalCode,City")] TAddress tAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tAddress);
        }

        // GET: Address/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAddress = await _context.TAddress.FindAsync(id);
            if (tAddress == null)
            {
                return NotFound();
            }
            return View(tAddress);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,Street,HouseNumber,FlatNumber,PostalCode,City")] TAddress tAddress)
        {
            if (id != tAddress.AddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAddressExists(tAddress.AddressId))
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
            return View(tAddress);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAddress = await _context.TAddress
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (tAddress == null)
            {
                return NotFound();
            }

            return View(tAddress);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tAddress = await _context.TAddress.FindAsync(id);
            _context.TAddress.Remove(tAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAddressExists(int id)
        {
            return _context.TAddress.Any(e => e.AddressId == id);
        }
    }
}
