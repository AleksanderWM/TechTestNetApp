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
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string nameSearchString,string salPerSearchString, string addressSearchString, string carModelSearchString, string carMakeSearchString)
        {
            var customer = from c in _context.Customer
                select c;
            var address = from add in _context.Address
                select add;
            var car = from ca in _context.Car
                select ca;
            var carPur = from cp in _context.CarPurchase
                select cp;
            var salPer = from sp in _context.SalesPerson
                select sp;

            if (!String.IsNullOrEmpty(nameSearchString))
            {
                customer = customer.Where(s => s.name.Contains(nameSearchString));
            }
            if (!String.IsNullOrEmpty(addressSearchString))
            {
                customer = from c in customer
                    join ad in address on c.addressID equals ad.Id
                    where ad.street.Equals(addressSearchString)
                    select c;
            }
            if (!String.IsNullOrEmpty(carModelSearchString))
            {
                customer = from c in customer
                    join ad in carPur on c.Id equals ad.customerID
                    join ax in car on ad.carID equals ax.Id
                    where ax.model.Equals(carModelSearchString)
                    select c;
            }
            if (!String.IsNullOrEmpty(carMakeSearchString))
            {
                customer = from c in customer
                    join cp in carPur on c.Id equals cp.customerID
                    join ax in car on cp.carID equals ax.Id
                    where ax.make.Equals(carMakeSearchString)
                    select c;
            }
            if (!String.IsNullOrEmpty(salPerSearchString))
            {
                customer = from c in customer
                    join ad in carPur on c.Id equals ad.customerID
                    join sp in salPer on ad.salesPersonID equals sp.Id
                    where sp.name.Equals(salPerSearchString)
                    select c;
            }

            return View(await customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,surname,age,addressID,created,Id")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,surname,age,addressID,created,Id")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
