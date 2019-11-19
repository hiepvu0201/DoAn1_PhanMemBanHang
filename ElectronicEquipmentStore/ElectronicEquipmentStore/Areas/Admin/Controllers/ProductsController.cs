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
using ElectronicEquipmentStore.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;

namespace ElectronicEquipmentStore.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

            ProductVM = new ProductViewModel()
            {
                ProductGroups = _context.ProductGroup.ToList(),
                Categories = _context.Category.ToList(),
                Product = new Product()
            };
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var products = from m in _context.Product select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.tenSP.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }

        // GET: Details Action Method
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.maSP == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Create Action Method
        public IActionResult Create()
        {
            return View(ProductVM);
        }

        // POST: Create Action Method
        [HttpPost,ActionName("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if(!ModelState.IsValid)
            {
                return View(ProductVM);
            }

            _context.Product.Add(ProductVM.Product);
            await _context.SaveChangesAsync();
             
            //Image being saved
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productsFromDb = _context.Product.Find(ProductVM.Product.maSP);

            if(files.Count!=0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath,SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads,ProductVM.Product.maSP+extension),FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                productsFromDb.hinhAnh = @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + extension;
            }
            else
            {
                //when user does not upload image
                var uploads = Path.Combine(webRootPath,SD.ImageFolder+@"\"+SD.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + ".png");
                productsFromDb.hinhAnh = @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + ".png";
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Edit Action Method
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maSP,tenSP,hinhAnh,soLuongSP,giaKhuyenMai,giaGoc,trangThai,maNSX,maNSP")] Product product)
        {
            if (id != product.maSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.maSP))
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
            return View(product);
        }

        // GET: Delete Action Method
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.maSP == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Delete Action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Product.Any(e => e.maSP == id);
        }
    }
}
