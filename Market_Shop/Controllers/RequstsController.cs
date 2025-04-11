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
    public class RequstsController : Controller
    {
        private readonly Market_ShopDB _context;

        public RequstsController(Market_ShopDB context)
        {
            _context = context;
        }

        // GET: Requsts
        public async Task<IActionResult> Index()
        {
            var market_ShopDB = _context.Requst.Include(r => r.Managers).Include(r => r.Partners.PartnerProducts).Include(r => r.Product);
            return View(await market_ShopDB.ToListAsync());
        }

        // GET: Requsts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requst = await _context.Requst
                .Include(r => r.Managers)
                .Include(r => r.Partners)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requst == null)
            {
                return NotFound();
            }

            return View(requst);
        }

        // GET: Requsts/Create
        public IActionResult Create()
        {
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "FullName");
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name");
            ViewData["ProductionId"] = new SelectList(_context.Product, "Id", "Name_Product");
            return View();
        }

        // POST: Requsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductionId,PartnersId,ManagerId,Count,Date,Status")] Requst requst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "FullName", requst.ManagerId);
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name", requst.PartnersId);
            ViewData["ProductionId"] = new SelectList(_context.Product, "Id", "Name_Product", requst.ProductionId);
            return View(requst);
        }

        // GET: Requsts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requst = await _context.Requst.FindAsync(id);
            if (requst == null)
            {
                return NotFound();
            }
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "FullName", requst.ManagerId);
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name", requst.PartnersId);
            ViewData["ProductionId"] = new SelectList(_context.Product, "Id", "Name_Product", requst.ProductionId);
            return View(requst);
        }

        // POST: Requsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProductionId,PartnersId,ManagerId,Count,Date,Status")] Requst requst)
        {
            if (id != requst.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequstExists(requst.Id))
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
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "FullName", requst.ManagerId);
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name", requst.PartnersId);
            ViewData["ProductionId"] = new SelectList(_context.Product, "Id", "Name_Product", requst.ProductionId);
            return View(requst);
        }

        // GET: Requsts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requst = await _context.Requst
                .Include(r => r.Managers)
                .Include(r => r.Partners)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requst == null)
            {
                return NotFound();
            }

            return View(requst);
        }

        // POST: Requsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var requst = await _context.Requst.FindAsync(id);
            if (requst != null)
            {
                _context.Requst.Remove(requst);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequstExists(long id)
        {
            return _context.Requst.Any(e => e.Id == id);
        }
    }
}
