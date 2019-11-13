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
    public class ReceiptsController : Controller
    {
        private readonly MvcEESStoreContext _context;

        public ReceiptsController(MvcEESStoreContext context)
        {
            _context = context;
        }

        // GET: Receipts
        public async Task<IActionResult> Index(string searchString)
        {
            var receipts = from m in _context.Receipt select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                receipts = receipts.Where(s => s.maHD.Contains(searchString));
            }
            return View(await receipts.ToListAsync());
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .FirstOrDefaultAsync(m => m.maHD == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maHD,maSP,ngayGiaoDich,soLuongSP,donGia,thanhTieh,tongTien,maKH,tenKH")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maHD,maSP,ngayGiaoDich,soLuongSP,donGia,thanhTieh,tongTien,maKH,tenKH")] Receipt receipt)
        {
            if (id != receipt.maHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.maHD))
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
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .FirstOrDefaultAsync(m => m.maHD == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(string id)
        {
            return _context.Receipt.Any(e => e.maHD == id);
        }
    }
}
