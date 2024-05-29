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
    [Authorize(Roles = $"{WebConstants.ManagerRole},{WebConstants.SupervisorRole}")]
    public class DBusesController : Controller
    {
        private readonly CarParkContext _context;

        public DBusesController(CarParkContext context)
        {
            _context = context;
        }

        // GET: DBuses
        public async Task<IActionResult> Index()
        {
              return _context.DBuses != null ? 
                          View(await _context.DBuses.ToListAsync()) :
                          Problem("Entity set 'CarParkContext.DBuses'  is null.");
        }

        // GET: DBuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DBuses == null)
            {
                return NotFound();
            }

            var dBuse = await _context.DBuses
                .FirstOrDefaultAsync(m => m.BusId == id);
            if (dBuse == null)
            {
                return NotFound();
            }

            return View(dBuse);
        }

        // GET: DBuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DBuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusId,Brand,Years,Numer,State,Notes")] DBuse dBuse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dBuse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dBuse);
        }

        // GET: DBuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DBuses == null)
            {
                return NotFound();
            }

            var dBuse = await _context.DBuses.FindAsync(id);
            if (dBuse == null)
            {
                return NotFound();
            }
            return View(dBuse);
        }

        // POST: DBuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusId,Brand,Years,Numer,State,Notes")] DBuse dBuse)
        {
            if (id != dBuse.BusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dBuse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DBuseExists(dBuse.BusId))
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
            return View(dBuse);
        }

        // GET: DBuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DBuses == null)
            {
                return NotFound();
            }

            var dBuse = await _context.DBuses
                .FirstOrDefaultAsync(m => m.BusId == id);
            if (dBuse == null)
            {
                return NotFound();
            }

            return View(dBuse);
        }

        // POST: DBuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DBuses == null)
            {
                return Problem("Entity set 'CarParkContext.DBuses'  is null.");
            }
            var dBuse = await _context.DBuses.FindAsync(id);
            if (dBuse != null)
            {
                _context.DBuses.Remove(dBuse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DBuseExists(int id)
        {
          return (_context.DBuses?.Any(e => e.BusId == id)).GetValueOrDefault();
        }
    }
}
