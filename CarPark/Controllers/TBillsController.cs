using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarPark.Data;
using CarPark.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CarPark.Controllers
{
    [Authorize]
    public class TBillsController : Controller
    {
        private readonly CarParkContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TBillsController(CarParkContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TBills
        [Authorize(Roles = $"{WebConstants.SupervisorRole},{WebConstants.ClientRole}")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TBill> bills;

            if (User.IsInRole(WebConstants.ClientRole))
            {
                bills = await _context.TBills.Include(t => t.Client).Include(t => t.Flights).Where(b => b.ClientId == null).ToListAsync();
                return View(bills);
            }

            bills = await _context.TBills.Include(t => t.Client).Include(t => t.Flights).ToListAsync();
            return View(bills);
        }

        [HttpPost]
        [Authorize(Roles = $"{WebConstants.ClientRole}")]
        public async Task<IActionResult> Order(int? id)
        {
            var userId = _userManager.GetUserId(new ClaimsPrincipal(User));

            if (id == null || _context.TBills == null)
            {
                return NotFound();
            }

            var tBill = await _context.TBills
                .Include(t => t.Client)
                .Include(t => t.Flights)
                .FirstOrDefaultAsync(m => m.FlightsId == id);

            if (tBill == null)
            {
                return NotFound();
            }

            tBill.ClientId = userId;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = $"{WebConstants.ClientRole}")]
        public async Task<IActionResult> MyBills()
        {
            var userId = _userManager.GetUserId(new ClaimsPrincipal(User));
            var bills = await _context.TBills.Include(t => t.Client).Include(t => t.Flights).Where(b => b.ClientId == userId).ToListAsync();
            return View(bills);

        }

        // GET: TBills/Details/5
        [Authorize(Roles = $"{WebConstants.SupervisorRole},{WebConstants.ClientRole}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBills == null)
            {
                return NotFound();
            }

            var tBill = await _context.TBills
                .Include(t => t.Client)
                .Include(t => t.Flights)
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (tBill == null)
            {
                return NotFound();
            }

            return View(tBill);
        }

        // GET: TBills/Create
        [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.TClients, "Id", "Id");
            ViewData["FlightsId"] = new SelectList(_context.TFlights, "FlightsId", "FlightsId");
            return View();
        }

        // POST: TBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
        public async Task<IActionResult> Create([Bind("BillId,FlightsId,ClientId")] TBill tBill)
        {
            _context.Add(tBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TBills/Edit/5
        [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBills == null)
            {
                return NotFound();
            }

            var tBill = await _context.TBills.FindAsync(id);
            if (tBill == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.TClients, "Id", "Id", tBill.ClientId);
            ViewData["FlightsId"] = new SelectList(_context.TFlights, "FlightsId", "FlightsId", tBill.FlightsId);
            return View(tBill);
        }

        // POST: TBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,FlightsId,ClientId")] TBill tBill)
        {
            if (id != tBill.FlightsId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(tBill);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBillExists(tBill.FlightsId))
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

        // GET: TBills/Delete/5
        [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBills == null)
            {
                return NotFound();
            }

            var tBill = await _context.TBills
                .Include(t => t.Client)
                .Include(t => t.Flights)
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (tBill == null)
            {
                return NotFound();
            }

            return View(tBill);
        }

        // POST: TBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{WebConstants.SupervisorRole}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBills == null)
            {
                return Problem("Entity set 'CarParkContext.TBills'  is null.");
            }
            var tBill = await _context.TBills.FindAsync(id);
            if (tBill != null)
            {
                _context.TBills.Remove(tBill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBillExists(int id)
        {
            return (_context.TBills?.Any(e => e.FlightsId == id)).GetValueOrDefault();
        }
    }
}
