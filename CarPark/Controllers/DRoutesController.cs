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
    public class DRoutesController : Controller
    {
        private readonly CarParkContext _context;

        public DRoutesController(CarParkContext context)
        {
            _context = context;
        }

        // GET: DRoutes
        public async Task<IActionResult> Index()
        {
            var carParkContext = _context.DRoutes.Include(d => d.BcityNavigation).Include(d => d.EcityNavigation);
            return View(await carParkContext.ToListAsync());
        }

        // GET: DRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DRoutes == null)
            {
                return NotFound();
            }

            var dRoute = await _context.DRoutes
                .Include(d => d.BcityNavigation)
                .Include(d => d.EcityNavigation)
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (dRoute == null)
            {
                return NotFound();
            }

            return View(dRoute);
        }

        // GET: DRoutes/Create
        public IActionResult Create()
        {
            ViewData["Bcity"] = new SelectList(_context.DCities, "CityId", "CityName");
            ViewData["Ecity"] = new SelectList(_context.DCities, "CityId", "CityName");
            return View();
        }

        // POST: DRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteId,Bcity,Ecity,RouteLen,RouteTime,IsWork,Notes")] DRoute dRoute)
        {
            _context.Add(dRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: DRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DRoutes == null)
            {
                return NotFound();
            }

            var dRoute = await _context.DRoutes.FindAsync(id);
            if (dRoute == null)
            {
                return NotFound();
            }
            ViewData["Bcity"] = new SelectList(_context.DCities, "CityId", "CityName", dRoute.Bcity);
            ViewData["Ecity"] = new SelectList(_context.DCities, "CityId", "CityName", dRoute.Ecity);
            return View(dRoute);
        }

        // POST: DRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteId,Bcity,Ecity,RouteLen,RouteTime,IsWork,Notes")] DRoute dRoute)
        {
            if (id != dRoute.RouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DRouteExists(dRoute.RouteId))
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
            ViewData["Bcity"] = new SelectList(_context.DCities, "CityId", "CityName", dRoute.Bcity);
            ViewData["Ecity"] = new SelectList(_context.DCities, "CityId", "CityName", dRoute.Ecity);
            return View(dRoute);
        }

        // GET: DRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DRoutes == null)
            {
                return NotFound();
            }

            var dRoute = await _context.DRoutes
                .Include(d => d.BcityNavigation)
                .Include(d => d.EcityNavigation)
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (dRoute == null)
            {
                return NotFound();
            }

            return View(dRoute);
        }

        // POST: DRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DRoutes == null)
            {
                return Problem("Entity set 'CarParkContext.DRoutes'  is null.");
            }
            var dRoute = await _context.DRoutes.FindAsync(id);
            if (dRoute != null)
            {
                _context.DRoutes.Remove(dRoute);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DRouteExists(int id)
        {
            return (_context.DRoutes?.Any(e => e.RouteId == id)).GetValueOrDefault();
        }
    }
}
