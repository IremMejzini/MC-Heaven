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
    public class OrderDetailController : Controller
    {
        private readonly MCHeavenContext _context;

        public OrderDetailController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: OrderDetail
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TOrderDetail.Include(t => t.Order).Include(t => t.Receive);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: OrderDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrderDetail = await _context.TOrderDetail
                .Include(t => t.Order)
                .Include(t => t.Receive)
                .FirstOrDefaultAsync(m => m.OrderDid == id);
            if (tOrderDetail == null)
            {
                return NotFound();
            }

            return View(tOrderDetail);
        }

        // GET: OrderDetail/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId");
            ViewData["ReceiveId"] = new SelectList(_context.TReceive, "ReceiveId", "ReceiveId");
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDid,Quantity,Price,OrderId,ReceiveId")] TOrderDetail tOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId", tOrderDetail.OrderId);
            ViewData["ReceiveId"] = new SelectList(_context.TReceive, "ReceiveId", "ReceiveId", tOrderDetail.ReceiveId);
            return View(tOrderDetail);
        }

        // GET: OrderDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrderDetail = await _context.TOrderDetail.FindAsync(id);
            if (tOrderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId", tOrderDetail.OrderId);
            ViewData["ReceiveId"] = new SelectList(_context.TReceive, "ReceiveId", "ReceiveId", tOrderDetail.ReceiveId);
            return View(tOrderDetail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDid,Quantity,Price,OrderId,ReceiveId")] TOrderDetail tOrderDetail)
        {
            if (id != tOrderDetail.OrderDid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOrderDetailExists(tOrderDetail.OrderDid))
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
            ViewData["OrderId"] = new SelectList(_context.TOrder, "OrderId", "OrderId", tOrderDetail.OrderId);
            ViewData["ReceiveId"] = new SelectList(_context.TReceive, "ReceiveId", "ReceiveId", tOrderDetail.ReceiveId);
            return View(tOrderDetail);
        }

        // GET: OrderDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrderDetail = await _context.TOrderDetail
                .Include(t => t.Order)
                .Include(t => t.Receive)
                .FirstOrDefaultAsync(m => m.OrderDid == id);
            if (tOrderDetail == null)
            {
                return NotFound();
            }

            return View(tOrderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOrderDetail = await _context.TOrderDetail.FindAsync(id);
            _context.TOrderDetail.Remove(tOrderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOrderDetailExists(int id)
        {
            return _context.TOrderDetail.Any(e => e.OrderDid == id);
        }
    }
}
