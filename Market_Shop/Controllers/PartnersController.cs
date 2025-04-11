using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market_Shop.Data;
using Market_Shop.Models;

namespace Market_Shop.Controllers
{
    public class PartnersController : Controller
    {
        private readonly Market_ShopDB _context;

        public PartnersController(Market_ShopDB context)
        {
            _context = context;
        }

        // GET: Partners
        public async Task<IActionResult> Index()
        {
            var market_ShopDB =await _context.Partners.Include(p =>p.PartnerProducts).ToListAsync();
            return View(market_ShopDB);
        }

        // GET: Partners/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partners = await _context.Partners
                .Include(p => p.Patners_Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partners == null)
            {
                return NotFound();
            }

            return View(partners);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            ViewData["Patners_Type_id"] = new SelectList(_context.Patners_type, "Id", "Patners_types");
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Patners_Type_id,Patners_Type_name,Director,Email,Phone,Addres_Partners,INN,Rate")] Partners partners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Patners_Type_id"] = new SelectList(_context.Patners_type, "Id", "Patners_types", partners.Patners_Type_id);
            return View(partners);
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partners = await _context.Partners.FindAsync(id);
            if (partners == null)
            {
                return NotFound();
            }
            ViewData["Patners_Type_id"] = new SelectList(_context.Patners_type, "Id", "Patners_types", partners.Patners_Type_id);
            return View(partners);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Patners_Type_id,Patners_Type_name,Director,Email,Phone,Addres_Partners,INN,Rate")] Partners partners)
        {
            if (id != partners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnersExists(partners.Id))
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
            ViewData["Patners_Type_id"] = new SelectList(_context.Patners_type, "Id", "Patners_types", partners.Patners_Type_id);
            return View(partners);
        }

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partners = await _context.Partners
                .Include(p => p.Patners_Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partners == null)
            {
                return NotFound();
            }

            return View(partners);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var partners = await _context.Partners.FindAsync(id);
            if (partners != null)
            {
                _context.Partners.Remove(partners);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnersExists(long id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
