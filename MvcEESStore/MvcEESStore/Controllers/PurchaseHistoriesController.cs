using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEESStore.Data;
using MvcEESStore.Models;

namespace MvcEESStore.Controllers
{
    public class PurchaseHistoriesController : Controller
    {
        private readonly MvcEESStoreContext _context;

        public PurchaseHistoriesController(MvcEESStoreContext context)
        {
            _context = context;
        }

        // GET: PurchaseHistories
        public async Task<IActionResult> Index(string searchString)
        {
            var purchaseHistories = from m in _context.PurchaseHistory select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                purchaseHistories = purchaseHistories.Where(s => s.maPurchaseHistory.Contains(searchString));
            }
            return View(await purchaseHistories.ToListAsync());
        }

        // GET: PurchaseHistories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistory
                .FirstOrDefaultAsync(m => m.maPurchaseHistory == id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return View(purchaseHistory);
        }

        // GET: PurchaseHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maPurchaseHistory,maHD")] PurchaseHistory purchaseHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseHistory);
        }

        // GET: PurchaseHistories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistory.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }
            return View(purchaseHistory);
        }

        // POST: PurchaseHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maPurchaseHistory,maHD")] PurchaseHistory purchaseHistory)
        {
            if (id != purchaseHistory.maPurchaseHistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseHistoryExists(purchaseHistory.maPurchaseHistory))
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
            return View(purchaseHistory);
        }

        // GET: PurchaseHistories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistory
                .FirstOrDefaultAsync(m => m.maPurchaseHistory == id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return View(purchaseHistory);
        }

        // POST: PurchaseHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var purchaseHistory = await _context.PurchaseHistory.FindAsync(id);
            _context.PurchaseHistory.Remove(purchaseHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseHistoryExists(string id)
        {
            return _context.PurchaseHistory.Any(e => e.maPurchaseHistory == id);
        }
    }
}
