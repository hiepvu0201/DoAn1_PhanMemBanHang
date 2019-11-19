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
    public class ProductGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductGroups
        public async Task<IActionResult> Index(string searchString)
        {
            var productgroups = from m in _context.ProductGroup select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                productgroups = productgroups.Where(s => s.tenNSP.Contains(searchString));
            }
            return View(await productgroups.ToListAsync());
        }

        // GET: Details Action Method
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroup
                .FirstOrDefaultAsync(m => m.maNSP == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // GET: Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maNSP,tenNSP,soLuongSpMoiNhom,maDM")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productGroup);
        }

        // GET: Edit Action Method
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroup.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }
            return View(productGroup);
        }

        // POST: Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maNSP,tenNSP,soLuongSpMoiNhom,maDM")] ProductGroup productGroup)
        {
            if (id != productGroup.maNSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductGroupExists(productGroup.maNSP))
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
            return View(productGroup);
        }

        // GET: Delete Action Method
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroup
                .FirstOrDefaultAsync(m => m.maNSP == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // POST: Delete Action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productGroup = await _context.ProductGroup.FindAsync(id);
            _context.ProductGroup.Remove(productGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductGroupExists(string id)
        {
            return _context.ProductGroup.Any(e => e.maNSP == id);
        }
    }
}
