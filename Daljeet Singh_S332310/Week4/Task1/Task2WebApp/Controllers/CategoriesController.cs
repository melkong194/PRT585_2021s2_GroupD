using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task2WebAppAdmin.Data;
using Task2WebAppAdmin.Models;

namespace Task2WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Task2WebAppAdminContext _context;

        public CategoriesController(Task2WebAppAdminContext context)
        {
            _context = context;
        }
        
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var efmodel = _context.Category.ToList();
            var returnObject = new List<Category>();

            foreach (var item in efmodel)
            {
                returnObject.Add(new Category()
                {
                    Id=item.Id,
                    Name=item.Name,
                   Code=item.Code
                });
            }

            return View(returnObject);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var efmodel = _context.Category.Find(id);
          
            if (id == null)
            {
                return NotFound();
            }

            if (efmodel == null)
            {
                return NotFound();
            }
            var returnObject = new Category()
            {
                Id = efmodel.Id,
                Name = efmodel.Name,
                Code = efmodel.Code
            };
            return View(efmodel);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] Category category)
        {
            if (ModelState.IsValid)
            {
                var efModel = new Category()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Code = category.Code
                };
                _context.Category.Add(efModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var efmodel = _context.Category.Find(id);
                    efmodel.Code = category.Code;
                    efmodel.Name = category.Name;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
