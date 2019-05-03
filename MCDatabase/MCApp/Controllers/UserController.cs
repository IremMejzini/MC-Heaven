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
    public class UserController : Controller
    {
        private readonly MCHeavenContext _context;

        public UserController(MCHeavenContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var mCHeavenContext = _context.TUser.Include(t => t.Address);
            return View(await mCHeavenContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUser = await _context.TUser
                .Include(t => t.Address)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tUser == null)
            {
                return NotFound();
            }

            return View(tUser);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserLogin,Pass,FirstName,LastName,Age,Email,PhoneNumber,AddressId")] TUser tUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City", tUser.AddressId);
            return View(tUser);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUser = await _context.TUser.FindAsync(id);
            if (tUser == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City", tUser.AddressId);
            return View(tUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserLogin,Pass,FirstName,LastName,Age,Email,PhoneNumber,AddressId")] TUser tUser)
        {
            if (id != tUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TUserExists(tUser.UserId))
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
            ViewData["AddressId"] = new SelectList(_context.TAddress, "AddressId", "City", tUser.AddressId);
            return View(tUser);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUser = await _context.TUser
                .Include(t => t.Address)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tUser == null)
            {
                return NotFound();
            }

            return View(tUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tUser = await _context.TUser.FindAsync(id);
            _context.TUser.Remove(tUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TUserExists(int id)
        {
            return _context.TUser.Any(e => e.UserId == id);
        }
    }
}
