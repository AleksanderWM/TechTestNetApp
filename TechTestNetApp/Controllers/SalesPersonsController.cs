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
    public class SalesPersonsController : Controller
    {
        private readonly AppDbContext _context;

        public SalesPersonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SalesPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesPerson.ToListAsync());
        }

        // GET: SalesPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // GET: SalesPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,jobTitle,addressID,salary,Id")] SalesPerson salesPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesPerson);
        }

        // GET: SalesPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson.FindAsync(id);
            if (salesPerson == null)
            {
                return NotFound();
            }
            return View(salesPerson);
        }

        // POST: SalesPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,jobTitle,addressID,salary,Id")] SalesPerson salesPerson)
        {
            if (id != salesPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonExists(salesPerson.Id))
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
            return View(salesPerson);
        }

        // GET: SalesPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // POST: SalesPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesPerson = await _context.SalesPerson.FindAsync(id);
            _context.SalesPerson.Remove(salesPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesPersonExists(int id)
        {
            return _context.SalesPerson.Any(e => e.Id == id);
        }
    }
}
