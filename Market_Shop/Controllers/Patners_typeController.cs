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
    public class Patners_typeController : Controller
    {
        private readonly Market_ShopDB _context;

        public Patners_typeController(Market_ShopDB context)
        {
            _context = context;
        }

        // GET: Patners_type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patners_type.ToListAsync());
        }

        // GET: Patners_type/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patners_type = await _context.Patners_type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patners_type == null)
            {
                return NotFound();
            }

            return View(patners_type);
        }

        // GET: Patners_type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patners_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Patners_types")] Patners_type patners_type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patners_type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patners_type);
        }

        // GET: Patners_type/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patners_type = await _context.Patners_type.FindAsync(id);
            if (patners_type == null)
            {
                return NotFound();
            }
            return View(patners_type);
        }

        // POST: Patners_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Patners_types")] Patners_type patners_type)
        {
            if (id != patners_type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patners_type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Patners_typeExists(patners_type.Id))
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
            return View(patners_type);
        }

        // GET: Patners_type/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patners_type = await _context.Patners_type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patners_type == null)
            {
                return NotFound();
            }

            return View(patners_type);
        }

        // POST: Patners_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var patners_type = await _context.Patners_type.FindAsync(id);
            if (patners_type != null)
            {
                _context.Patners_type.Remove(patners_type);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Patners_typeExists(long id)
        {
            return _context.Patners_type.Any(e => e.Id == id);
        }
    }
}
