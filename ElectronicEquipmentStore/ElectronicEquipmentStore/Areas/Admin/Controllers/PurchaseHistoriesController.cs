using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicEquipmentStore.Data;
using ElectronicEquipmentStore.Models;
using Microsoft.AspNetCore.Authorization;
using ElectronicEquipmentStore.Utility;

namespace ElectronicEquipmentStore.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class PurchaseHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoriesController(ApplicationDbContext context)
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

        // GET: Details Action Method
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

        // GET: Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Action Method
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

        // GET: Edit Action Method
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

        // POST: Edit Action Method
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

        // GET: Delete Action Method
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

        // POST: Delete Action Method
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
