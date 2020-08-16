using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITL_MakeId.Data;
using ITL_MakeId.Model.DomainModel;

namespace ITL_MakeId.Web.Controllers
{
    public class CardCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardCategorys.ToListAsync());
        }

        // GET: CardCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCategory = await _context.CardCategorys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardCategory == null)
            {
                return NotFound();
            }

            return View(cardCategory);
        }

        // GET: CardCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] CardCategory cardCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardCategory);
        }

        // GET: CardCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCategory = await _context.CardCategorys.FindAsync(id);
            if (cardCategory == null)
            {
                return NotFound();
            }
            return View(cardCategory);
        }

        // POST: CardCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName")] CardCategory cardCategory)
        {
            if (id != cardCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardCategoryExists(cardCategory.Id))
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
            return View(cardCategory);
        }

        // GET: CardCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCategory = await _context.CardCategorys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardCategory == null)
            {
                return NotFound();
            }

            return View(cardCategory);
        }

        // POST: CardCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardCategory = await _context.CardCategorys.FindAsync(id);
            _context.CardCategorys.Remove(cardCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardCategoryExists(int id)
        {
            return _context.CardCategorys.Any(e => e.Id == id);
        }
    }
}
