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
    public class OrderController : Controller
    {
        private readonly MCHeavenContext _context;

        public OrderController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TOrder.Include(t => t.Address).Include(t => t.Coupon).Include(t => t.PaymentM).Include(t => t.Shop);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrder = await _context.TOrder
                .Include(t => t.Address)
                .Include(t => t.Coupon)
                .Include(t => t.PaymentM)
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (tOrder == null)
            {
                return NotFound();
            }

            return View(tOrder);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City");
            ViewData["CouponId"] = new SelectList(_context.TCoupon, "CouponId", "TypeCoupon");
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment");
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,TotalPrice,AddressId,ShopId,PaymentMid,CouponId")] TOrder tOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City", tOrder.AddressId);
            ViewData["CouponId"] = new SelectList(_context.TCoupon, "CouponId", "TypeCoupon", tOrder.CouponId);
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment", tOrder.PaymentMid);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tOrder.ShopId);
            return View(tOrder);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrder = await _context.TOrder.FindAsync(id);
            if (tOrder == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City", tOrder.AddressId);
            ViewData["CouponId"] = new SelectList(_context.TCoupon, "CouponId", "TypeCoupon", tOrder.CouponId);
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment", tOrder.PaymentMid);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tOrder.ShopId);
            return View(tOrder);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,TotalPrice,AddressId,ShopId,PaymentMid,CouponId")] TOrder tOrder)
        {
            if (id != tOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOrderExists(tOrder.OrderId))
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
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City", tOrder.AddressId);
            ViewData["CouponId"] = new SelectList(_context.TCoupon, "CouponId", "TypeCoupon", tOrder.CouponId);
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment", tOrder.PaymentMid);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tOrder.ShopId);
            return View(tOrder);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrder = await _context.TOrder
                .Include(t => t.Address)
                .Include(t => t.Coupon)
                .Include(t => t.PaymentM)
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (tOrder == null)
            {
                return NotFound();
            }

            return View(tOrder);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOrder = await _context.TOrder.FindAsync(id);
            _context.TOrder.Remove(tOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOrderExists(int id)
        {
            return _context.TOrder.Any(e => e.OrderId == id);
        }
    }
}
