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
    public class Product_typeController : Controller
    {
        private readonly Market_ShopDB _context;

        public Product_typeController(Market_ShopDB context)
        {
            _context = context;
        }

        // GET: Product_type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product_type.ToListAsync());
        }

        // GET: Product_type/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_type = await _context.Product_type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_type == null)
            {
                return NotFound();
            }

            return View(product_type);
        }

        // GET: Product_type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_types,Ratio_Product_types")] Product_type product_type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product_type);
        }

        // GET: Product_type/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_type = await _context.Product_type.FindAsync(id);
            if (product_type == null)
            {
                return NotFound();
            }
            return View(product_type);
        }

        // POST: Product_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Product_types,Ratio_Product_types")] Product_type product_type)
        {
            if (id != product_type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_typeExists(product_type.Id))
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
            return View(product_type);
        }

        // GET: Product_type/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_type = await _context.Product_type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_type == null)
            {
                return NotFound();
            }

            return View(product_type);
        }

        // POST: Product_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product_type = await _context.Product_type.FindAsync(id);
            if (product_type != null)
            {
                _context.Product_type.Remove(product_type);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_typeExists(long id)
        {
            return _context.Product_type.Any(e => e.Id == id);
        }
    }
}
