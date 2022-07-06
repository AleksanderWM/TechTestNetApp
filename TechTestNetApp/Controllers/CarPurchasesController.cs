using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechTestNetApp.Data;
using TechTestNetApp.Models;

namespace TechTestNetApp.Controllers
{
    public class CarPurchasesController : Controller
    {
        private readonly AppDbContext _context;

        public CarPurchasesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CarPurchases
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarPurchase.ToListAsync());
        }

        // GET: CarPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPurchase = await _context.CarPurchase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carPurchase == null)
            {
                return NotFound();
            }

            return View(carPurchase);
        }

        // GET: CarPurchases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarPurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("customerID,carID,orderDate,pricePaid,salesPersonID,ID")] CarPurchase carPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carPurchase);
        }

        // GET: CarPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPurchase = await _context.CarPurchase.FindAsync(id);
            if (carPurchase == null)
            {
                return NotFound();
            }
            return View(carPurchase);
        }

        // POST: CarPurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customerID,carID,orderDate,pricePaid,salesPersonID,ID")] CarPurchase carPurchase)
        {
            if (id != carPurchase.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPurchaseExists(carPurchase.ID))
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
            return View(carPurchase);
        }

        // GET: CarPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPurchase = await _context.CarPurchase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carPurchase == null)
            {
                return NotFound();
            }

            return View(carPurchase);
        }

        // POST: CarPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carPurchase = await _context.CarPurchase.FindAsync(id);
            _context.CarPurchase.Remove(carPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPurchaseExists(int id)
        {
            return _context.CarPurchase.Any(e => e.ID == id);
        }
    }
}
