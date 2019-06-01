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
    public class PaymentMethodController : Controller
    {
        private readonly MCHeavenContext _context;

        public PaymentMethodController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: PaymentMethod
        public async Task<IActionResult> Index()
        {
            return View(await _context.TPaymentMethod.ToListAsync());
        }

        // GET: PaymentMethod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPaymentMethod = await _context.TPaymentMethod
                .FirstOrDefaultAsync(m => m.PaymentMid == id);
            if (tPaymentMethod == null)
            {
                return NotFound();
            }

            return View(tPaymentMethod);
        }

        // GET: PaymentMethod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentMethod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentMid,TypePayment")] TPaymentMethod tPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tPaymentMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tPaymentMethod);
        }

        // GET: PaymentMethod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPaymentMethod = await _context.TPaymentMethod.FindAsync(id);
            if (tPaymentMethod == null)
            {
                return NotFound();
            }
            return View(tPaymentMethod);
        }

        // POST: PaymentMethod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentMid,TypePayment")] TPaymentMethod tPaymentMethod)
        {
            if (id != tPaymentMethod.PaymentMid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tPaymentMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TPaymentMethodExists(tPaymentMethod.PaymentMid))
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
            return View(tPaymentMethod);
        }

        // GET: PaymentMethod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPaymentMethod = await _context.TPaymentMethod
                .FirstOrDefaultAsync(m => m.PaymentMid == id);
            if (tPaymentMethod == null)
            {
                return NotFound();
            }

            return View(tPaymentMethod);
        }

        // POST: PaymentMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tPaymentMethod = await _context.TPaymentMethod.FindAsync(id);
            _context.TPaymentMethod.Remove(tPaymentMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TPaymentMethodExists(int id)
        {
            return _context.TPaymentMethod.Any(e => e.PaymentMid == id);
        }
    }
}
