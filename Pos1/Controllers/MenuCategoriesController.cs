using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pos1.Data;
using Pos1.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Pos1.Controllers
{
    public class MenuCategoriesController : Controller
    {
        private readonly MenuContext _context;

        public MenuCategoriesController(MenuContext context)
        {
            _context = context;
        }

        // GET: MenuCategories
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuCategories.ToListAsync());
        }

        // GET: MenuCategories/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuCategory = await _context.MenuCategories
                .SingleOrDefaultAsync(m => m.ID == id);
            if (menuCategory == null)
            {
                return NotFound();
            }

            return View(menuCategory);
        }

        // GET: MenuCategories/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Header")] MenuCategory menuCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuCategory);
        }

        // GET: MenuCategories/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuCategory = await _context.MenuCategories.SingleOrDefaultAsync(m => m.ID == id);
            if (menuCategory == null)
            {
                return NotFound();
            }
            return View(menuCategory);
        }

        // POST: MenuCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Header")] MenuCategory menuCategory)
        {
            if (id != menuCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuCategoryExists(menuCategory.ID))
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
            return View(menuCategory);
        }

        // GET: MenuCategories/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuCategory = await _context.MenuCategories
                .SingleOrDefaultAsync(m => m.ID == id);
            if (menuCategory == null)
            {
                return NotFound();
            }

            return View(menuCategory);
        }

        // POST: MenuCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuCategory = await _context.MenuCategories.SingleOrDefaultAsync(m => m.ID == id);
            _context.MenuCategories.Remove(menuCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuCategoryExists(int id)
        {
            return _context.MenuCategories.Any(e => e.ID == id);
        }
    }
}
