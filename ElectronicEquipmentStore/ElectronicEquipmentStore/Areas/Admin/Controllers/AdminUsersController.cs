using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicEquipmentStore.Data;
using ElectronicEquipmentStore.Models;
using ElectronicEquipmentStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicEquipmentStore.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        public readonly ApplicationDbContext _context;
       
        public AdminUsersController(ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View(_context.ApplicationUser.ToList());
        }

        //Get edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || id.Trim().Length == 0)
                return NotFound();

            var userFromDb =await _context.ApplicationUser.FindAsync(id);
            if(userFromDb==null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        //Post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id,ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
                return NotFound();
            if(ModelState.IsValid)
            {
                ApplicationUser userFromDb = _context.ApplicationUser.Where(u=>u.Id==id).FirstOrDefault();
                userFromDb.Name = applicationUser.Name;
                userFromDb.PhoneNumber = applicationUser.PhoneNumber;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        //Get delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || id.Trim().Length == 0)
                return NotFound();

            var userFromDb = await _context.ApplicationUser.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        //Post edit
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string id)
        {
                ApplicationUser userFromDb = _context.ApplicationUser.Where(u => u.Id == id).FirstOrDefault();
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }
    }
}