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
    public class ReceiveController : Controller
    {
        private readonly MCHeavenContext _context;

        public ReceiveController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: Receive
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TReceive.Include(t => t.Order).Include(t => t.PaymentM).Include(t => t.Shop);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: Receive/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tReceive = await _context.TReceive
                .Include(t => t.Order)
                .Include(t => t.PaymentM)
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.ReceiveId == id);
            if (tReceive == null)
            {
                return NotFound();
            }

            return View(tReceive);
        }

        // GET: Receive/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId");
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment");
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop");
            return View();
        }

        // POST: Receive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiveId,ShopId,OrderId,PaymentMid")] TReceive tReceive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tReceive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId", tReceive.OrderId);
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment", tReceive.PaymentMid);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tReceive.ShopId);
            return View(tReceive);
        }

        // GET: Receive/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tReceive = await _context.TReceive.FindAsync(id);
            if (tReceive == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId", tReceive.OrderId);
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment", tReceive.PaymentMid);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tReceive.ShopId);
            return View(tReceive);
        }

        // POST: Receive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceiveId,ShopId,OrderId,PaymentMid")] TReceive tReceive)
        {
            if (id != tReceive.ReceiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tReceive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TReceiveExists(tReceive.ReceiveId))
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
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId", tReceive.OrderId);
            ViewData["PaymentMid"] = new SelectList(_context.TPaymentMethod, "PaymentMid", "TypePayment", tReceive.PaymentMid);
            ViewData["ShopId"] = new SelectList(_context.TShop, "ShopId", "NameShop", tReceive.ShopId);
            return View(tReceive);
        }

        // GET: Receive/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tReceive = await _context.TReceive
                .Include(t => t.Order)
                .Include(t => t.PaymentM)
                .Include(t => t.Shop)
                .FirstOrDefaultAsync(m => m.ReceiveId == id);
            if (tReceive == null)
            {
                return NotFound();
            }

            return View(tReceive);
        }

        // POST: Receive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tReceive = await _context.TReceive.FindAsync(id);
            _context.TReceive.Remove(tReceive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TReceiveExists(int id)
        {
            return _context.TReceive.Any(e => e.ReceiveId == id);
        }
    }
}
