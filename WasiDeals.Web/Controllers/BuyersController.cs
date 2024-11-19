using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin.Data;
using Admin.Models;

namespace Admin.Controllers
{
    public class BuyersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buyers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buyers.ToListAsync());
        }

        // GET: Buyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyers = await _context.Buyers
                .FirstOrDefaultAsync(m => m.BuyerId == id);
            if (buyers == null)
            {
                return NotFound();
            }

            return View(buyers);
        }

        // GET: Buyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuyerId,BuyerName,BuyerEmail,BuyerPhoneNumber,BuyerAddress,ModifiedById,ModifiedOn")] Buyers buyers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyers);
        }

        // GET: Buyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyers = await _context.Buyers.FindAsync(id);
            if (buyers == null)
            {
                return NotFound();
            }
            return View(buyers);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuyerId,BuyerName,BuyerEmail,BuyerPhoneNumber,BuyerAddress,ModifiedById,ModifiedOn")] Buyers buyers)
        {
            if (id != buyers.BuyerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyersExists(buyers.BuyerId))
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
            return View(buyers);
        }

        // GET: Buyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyers = await _context.Buyers
                .FirstOrDefaultAsync(m => m.BuyerId == id);
            if (buyers == null)
            {
                return NotFound();
            }

            return View(buyers);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyers = await _context.Buyers.FindAsync(id);
            if (buyers != null)
            {
                _context.Buyers.Remove(buyers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyersExists(int id)
        {
            return _context.Buyers.Any(e => e.BuyerId == id);
        }
    }
}
