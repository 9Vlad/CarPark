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
    [Authorize]
    public class TFlightsController : Controller
    {
        private readonly CarParkContext _context;

        public TFlightsController(CarParkContext context)
        {
            _context = context;
        }

        // GET: TFlights
        [Authorize(Roles = $"{WebConstants.SupervisorRole},{WebConstants.ClientRole}")]
        public async Task<IActionResult> Index()
        {
            var carParkContext = _context.TFlights
                .Include(t => t.Bus)
                .Include(t => t.Driver)
                .Include(t => t.Route.EcityNavigation)
                .Include(t => t.Route.BcityNavigation);
            return View(await carParkContext.ToListAsync());
        }

        // GET: TFlights/Details/5
        [Authorize(Roles = $"{WebConstants.SupervisorRole},{WebConstants.ClientRole}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TFlights == null)
            {
                return NotFound();
            }

            var tFlight = await _context.TFlights
                .Include(t => t.Bus)
                .Include(t => t.Driver)
                .Include(t => t.Route.EcityNavigation)
                .Include(t=>t.Route.BcityNavigation)
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (tFlight == null)
            {
                return NotFound();
            }

            return View(tFlight);
        }

        // GET: TFlights/Create
        [Authorize(Roles = WebConstants.SupervisorRole)]
        public IActionResult Create()
        {
            ViewData["BusId"] = new SelectList(_context.DBuses, "BusId", "Numer");
            ViewData["DriverId"] = new SelectList(_context.DDrivers, "DriverId", "Surname");
            ViewData["RouteId"] = new SelectList(_context.DRoutes, "RouteId", "RouteId");
            return View();
        }

        // POST: TFlights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = WebConstants.SupervisorRole)]
        public async Task<IActionResult> Create([Bind("FlightsId,RouteId,BusId,DriverId,BdateRoute,BtimeRoute,EdateRoute,EtimeRoute,IsEnd,IsCanselet")] TFlight tFlight)
        {
            _context.Add(tFlight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TFlights/Edit/5
        [Authorize(Roles = WebConstants.SupervisorRole)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TFlights == null)
            {
                return NotFound();
            }

            var tFlight = await _context.TFlights.FindAsync(id);
            if (tFlight == null)
            {
                return NotFound();
            }
            ViewData["BusId"] = new SelectList(_context.DBuses, "BusId", "BusId", tFlight.BusId);
            ViewData["DriverId"] = new SelectList(_context.DDrivers, "DriverId", "DriverId", tFlight.DriverId);
            ViewData["RouteId"] = new SelectList(_context.DRoutes, "RouteId", "RouteId", tFlight.RouteId);
            return View(tFlight);
        }

        // POST: TFlights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = WebConstants.SupervisorRole)]
        public async Task<IActionResult> Edit(int id, [Bind("FlightsId,RouteId,BusId,DriverId,BdateRoute,BtimeRoute,EdateRoute,EtimeRoute,IsEnd,IsCanselet")] TFlight tFlight)
        {
            if (id != tFlight.FlightsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tFlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TFlightExists(tFlight.FlightsId))
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
            ViewData["BusId"] = new SelectList(_context.DBuses, "BusId", "BusId", tFlight.BusId);
            ViewData["DriverId"] = new SelectList(_context.DDrivers, "DriverId", "DriverId", tFlight.DriverId);
            ViewData["RouteId"] = new SelectList(_context.DRoutes, "RouteId", "RouteId", tFlight.RouteId);
            return View(tFlight);
        }

        // GET: TFlights/Delete/5
        [Authorize(Roles = WebConstants.SupervisorRole)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TFlights == null)
            {
                return NotFound();
            }

            var tFlight = await _context.TFlights
                .Include(t => t.Bus)
                .Include(t => t.Driver)
                .Include(t => t.Route)
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (tFlight == null)
            {
                return NotFound();
            }

            return View(tFlight);
        }

        // POST: TFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = WebConstants.SupervisorRole)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TFlights == null)
            {
                return Problem("Entity set 'CarParkContext.TFlights'  is null.");
            }
            var tFlight = await _context.TFlights.FindAsync(id);
            if (tFlight != null)
            {
                _context.TFlights.Remove(tFlight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TFlightExists(int id)
        {
            return (_context.TFlights?.Any(e => e.FlightsId == id)).GetValueOrDefault();
        }
    }
}
