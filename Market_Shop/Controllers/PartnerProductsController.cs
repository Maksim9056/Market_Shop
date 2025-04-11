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
    public class PartnerProductsController : Controller
    {
        private readonly Market_ShopDB _context;

        public PartnerProductsController(Market_ShopDB context)
        {
            _context = context;
        }

        // GET: PartnerProducts
        public async Task<IActionResult> Index()
        {
            var market_ShopDB = _context.PartnerProduct.Include(p => p.Partners).Include(p => p.Product);
            return View(await market_ShopDB.ToListAsync());
        }

        // GET: PartnerProducts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerProduct = await _context.PartnerProduct
                .Include(p => p.Partners)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerProduct == null)
            {
                return NotFound();
            }

            return View(partnerProduct);
        }

        // GET: PartnerProducts/Create
        public IActionResult Create()
        {
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name_Product");
            return View();
        }

        // POST: PartnerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartnersId,ProductId,Count")] PartnerProduct partnerProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partnerProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name", partnerProduct.PartnersId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name_Product", partnerProduct.ProductId);
            return View(partnerProduct);
        }

        // GET: PartnerProducts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerProduct = await _context.PartnerProduct.FindAsync(id);
            if (partnerProduct == null)
            {
                return NotFound();
            }
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name", partnerProduct.PartnersId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name_Product", partnerProduct.ProductId);
            return View(partnerProduct);
        }

        // POST: PartnerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PartnersId,ProductId,Count")] PartnerProduct partnerProduct)
        {
            if (id != partnerProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnerProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerProductExists(partnerProduct.Id))
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
            ViewData["PartnersId"] = new SelectList(_context.Partners, "Id", "Patners_Type_name", partnerProduct.PartnersId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name_Product", partnerProduct.ProductId);
            return View(partnerProduct);
        }

        // GET: PartnerProducts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerProduct = await _context.PartnerProduct
                .Include(p => p.Partners)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerProduct == null)
            {
                return NotFound();
            }

            return View(partnerProduct);
        }

        // POST: PartnerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var partnerProduct = await _context.PartnerProduct.FindAsync(id);
            if (partnerProduct != null)
            {
                _context.PartnerProduct.Remove(partnerProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerProductExists(long id)
        {
            return _context.PartnerProduct.Any(e => e.Id == id);
        }
    }
}
