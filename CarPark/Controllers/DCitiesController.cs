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
    [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
    public class DCitiesController : Controller
    {
        private readonly CarParkContext _context;

        public DCitiesController(CarParkContext context)
        {
            _context = context;
        }

        // GET: DCities
        public async Task<IActionResult> Index()
        {
              return _context.DCities != null ? 
                          View(await _context.DCities.ToListAsync()) :
                          Problem("Entity set 'CarParkContext.DCities'  is null.");
        }

        // GET: DCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DCities == null)
            {
                return NotFound();
            }

            var dCity = await _context.DCities
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (dCity == null)
            {
                return NotFound();
            }

            return View(dCity);
        }

        // GET: DCities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,Notes")] DCity dCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dCity);
        }

        // GET: DCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DCities == null)
            {
                return NotFound();
            }

            var dCity = await _context.DCities.FindAsync(id);
            if (dCity == null)
            {
                return NotFound();
            }
            return View(dCity);
        }

        // POST: DCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,Notes")] DCity dCity)
        {
            if (id != dCity.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DCityExists(dCity.CityId))
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
            return View(dCity);
        }

        // GET: DCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DCities == null)
            {
                return NotFound();
            }

            var dCity = await _context.DCities
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (dCity == null)
            {
                return NotFound();
            }

            return View(dCity);
        }

        // POST: DCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DCities == null)
            {
                return Problem("Entity set 'CarParkContext.DCities'  is null.");
            }
            var dCity = await _context.DCities.FindAsync(id);
            if (dCity != null)
            {
                _context.DCities.Remove(dCity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DCityExists(int id)
        {
          return (_context.DCities?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
