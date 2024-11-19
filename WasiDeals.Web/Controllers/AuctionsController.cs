using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin.Data;
using Admin.Models;
using Admin.Models.viewmodel;

namespace Admin.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Auctions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auctions.ToListAsync());
        }

        // GET: Auctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctions = await _context.Auctions
                .FirstOrDefaultAsync(m => m.AuctionId == id);
            if (auctions == null)
            {
                return NotFound();
            }

            return View(auctions);
        }

        public IActionResult Create()
        {
            var availableItems = _context.Items
                .Where(item => item.Qty > 0)
                .Select(item => new AuctionCreateViewModel.ItemViewModel
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ItemDescription = item.ItemDescription,
                    MinimumBid = item.MinimumBid,
                    Picture = item.Picture,
                    SellerName = item.SellerName
                }).ToList();

            var viewModel = new AuctionCreateViewModel
            {
                AvailableItems = availableItems
            };

            return View(viewModel);
        }

        // POST: Auctions/Create
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuctionCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var auction = new Auctions
                {
                    AuctionName = model.AuctionName,
                    AuctionStartDate = model.AuctionStartDate,
                    AuctionStartTime = model.AuctionStartTime,
                    TimeBtwItemChange = model.TimeBtwItemChange,
                    AuctionStatus = model.AuctionStatus,
                    HighestBids = "N/A",
                    AuctionItems = string.Join(",", model.SelectedItemIds)
                };

                _context.Auctions.Add(auction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Reload available items if ModelState is invalid
            model.AvailableItems = _context.Items
                .Where(item => item.Qty > 0)
                .Select(item => new AuctionCreateViewModel.ItemViewModel
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ItemDescription = item.ItemDescription,
                    MinimumBid = item.MinimumBid,
                    Picture = item.Picture,
                    SellerName = item.SellerName
                }).ToList();

            return View(model);
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuctionCreateViewModel auctionViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Iterate through the ModelState errors to find out which fields are failing validation
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Validation error in field '{key}': {error.ErrorMessage}");
                    }
                }

                // Re-populate available items to display them again after validation fails
                ViewBag.AvailableItems = _context.Items.Where(item => item.Qty > 0).ToList();
                return View(auctionViewModel); // Return the view with validation errors displayed
            }

            // Create a new Auctions object
            var auction = new Auctions
            {
                AuctionName = auctionViewModel.AuctionName,
                AuctionStartDate = auctionViewModel.AuctionStartDate,
                AuctionStartTime = auctionViewModel.AuctionStartTime,
                TimeBtwItemChange = auctionViewModel.TimeBtwItemChange,
                AuctionItems = string.Join(",", auctionViewModel.SelectedItemIds),
                AuctionStatus = auctionViewModel.AuctionStatus,
                HighestBids = "0" // Set a default or initial value if required
            };

            // Add to the database context and save changes
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();

            // Redirect to the index or confirmation page
            return RedirectToAction(nameof(Index));
        }


        // GET: Auctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctions = await _context.Auctions.FindAsync(id);
            if (auctions == null)
            {
                return NotFound();
            }
            return View(auctions);
        }

        // POST: Auctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuctionId,BuyerId,HighestBids,AuctionName,AuctionStartDate,AuctionStartTime,TimeBtwItemChange,AuctionItems,AuctionStatus")] Auctions auctions)
        {
            if (id != auctions.AuctionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auctions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionsExists(auctions.AuctionId))
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
            return View(auctions);
        }

        // GET: Auctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctions = await _context.Auctions
                .FirstOrDefaultAsync(m => m.AuctionId == id);
            if (auctions == null)
            {
                return NotFound();
            }

            return View(auctions);
        }

        // POST: Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auctions = await _context.Auctions.FindAsync(id);
            if (auctions != null)
            {
                _context.Auctions.Remove(auctions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionsExists(int id)
        {
            return _context.Auctions.Any(e => e.AuctionId == id);
        }
    }
}
