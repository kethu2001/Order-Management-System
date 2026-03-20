using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Controllers{

    public class CustomerController : Controller{

        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync(););
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address")] Customer customer)
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
                    await _context.SaveChangesAsync(); // Saves changes to the database
                    return RedirectToAction(nameof(Index));
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
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer); // Marks the entity for removal
                await _context.SaveChangesAsync(); // Commits the deletion to the database
            }
            
            return RedirectToAction(nameof(Index));
        }
    }

    
}