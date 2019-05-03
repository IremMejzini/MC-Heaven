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
    public class CouponController : Controller
    {
        private readonly MCHeavenContext _context;

        public CouponController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Coupon
        public async Task<IActionResult> Index()
        {
            return View(await _context.TCoupon.ToListAsync());
        }

        // GET: Coupon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCoupon = await _context.TCoupon
                .FirstOrDefaultAsync(m => m.CouponId == id);
            if (tCoupon == null)
            {
                return NotFound();
            }

            return View(tCoupon);
        }

        // GET: Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CouponId,TypeCoupon")] TCoupon tCoupon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tCoupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tCoupon);
        }

        // GET: Coupon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCoupon = await _context.TCoupon.FindAsync(id);
            if (tCoupon == null)
            {
                return NotFound();
            }
            return View(tCoupon);
        }

        // POST: Coupon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CouponId,TypeCoupon")] TCoupon tCoupon)
        {
            if (id != tCoupon.CouponId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tCoupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TCouponExists(tCoupon.CouponId))
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
            return View(tCoupon);
        }

        // GET: Coupon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCoupon = await _context.TCoupon
                .FirstOrDefaultAsync(m => m.CouponId == id);
            if (tCoupon == null)
            {
                return NotFound();
            }

            return View(tCoupon);
        }

        // POST: Coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tCoupon = await _context.TCoupon.FindAsync(id);
            _context.TCoupon.Remove(tCoupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TCouponExists(int id)
        {
            return _context.TCoupon.Any(e => e.CouponId == id);
        }
    }
}
