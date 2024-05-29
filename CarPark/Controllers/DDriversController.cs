using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarPark.Data;
using CarPark.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarPark.Controllers
{
    [Authorize(Roles = WebConstants.SupervisorRole)]
    public class DDriversController : Controller
    {
        private readonly CarParkContext _context;

        public DDriversController(CarParkContext context)
        {
            _context = context;
        }

        // GET: DDrivers
        public async Task<IActionResult> Index()
        {
              return _context.DDrivers != null ? 
                          View(await _context.DDrivers.ToListAsync()) :
                          Problem("Entity set 'CarParkContext.DDrivers'  is null.");
        }

        // GET: DDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DDrivers == null)
            {
                return NotFound();
            }

            var dDriver = await _context.DDrivers
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (dDriver == null)
            {
                return NotFound();
            }

            return View(dDriver);
        }

        // GET: DDrivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DDrivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,Name,Surname,Phone,Experience")] DDriver dDriver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dDriver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dDriver);
        }

        // GET: DDrivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DDrivers == null)
            {
                return NotFound();
            }

            var dDriver = await _context.DDrivers.FindAsync(id);
            if (dDriver == null)
            {
                return NotFound();
            }
            return View(dDriver);
        }

        // POST: DDrivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverId,Name,Surname,Phone,Experience")] DDriver dDriver)
        {
            if (id != dDriver.DriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dDriver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DDriverExists(dDriver.DriverId))
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
            return View(dDriver);
        }

        // GET: DDrivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DDrivers == null)
            {
                return NotFound();
            }

            var dDriver = await _context.DDrivers
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (dDriver == null)
            {
                return NotFound();
            }

            return View(dDriver);
        }

        // POST: DDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DDrivers == null)
            {
                return Problem("Entity set 'CarParkContext.DDrivers'  is null.");
            }
            var dDriver = await _context.DDrivers.FindAsync(id);
            if (dDriver != null)
            {
                _context.DDrivers.Remove(dDriver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DDriverExists(int id)
        {
          return (_context.DDrivers?.Any(e => e.DriverId == id)).GetValueOrDefault();
        }
    }
}
