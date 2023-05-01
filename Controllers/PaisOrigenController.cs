using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using segundoPractico.Data;

namespace segundoPractico.Controllers
{
    public class PaisOrigenController : Controller
    {
        private readonly MvcNotebooksContext _context;

        public PaisOrigenController(MvcNotebooksContext context)
        {
            _context = context;
        }

        // GET: PaisOrigen
        public async Task<IActionResult> Index()
        {
            var mvcNotebooksContext = _context.PaisOrigen.Include(p => p.Notebook);
            return View(await mvcNotebooksContext.ToListAsync());
        }

        // GET: PaisOrigen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaisOrigen == null)
            {
                return NotFound();
            }

            var paisOrigen = await _context.PaisOrigen
                .Include(p => p.Notebook)
                .FirstOrDefaultAsync(m => m.id == id);
            if (paisOrigen == null)
            {
                return NotFound();
            }

            return View(paisOrigen);
        }

        // GET: PaisOrigen/Create
        public IActionResult Create()
        {
            ViewData["NotebookId"] = new SelectList(_context.Notebook, "id", "id");
            return View();
        }

        // POST: PaisOrigen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,NotebookId")] PaisOrigen paisOrigen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paisOrigen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotebookId"] = new SelectList(_context.Notebook, "id", "id", paisOrigen.NotebookId);
            return View(paisOrigen);
        }

        // GET: PaisOrigen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaisOrigen == null)
            {
                return NotFound();
            }

            var paisOrigen = await _context.PaisOrigen.FindAsync(id);
            if (paisOrigen == null)
            {
                return NotFound();
            }
            ViewData["NotebookId"] = new SelectList(_context.Notebook, "id", "id", paisOrigen.NotebookId);
            return View(paisOrigen);
        }

        // POST: PaisOrigen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,NotebookId")] PaisOrigen paisOrigen)
        {
            if (id != paisOrigen.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paisOrigen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisOrigenExists(paisOrigen.id))
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
            ViewData["NotebookId"] = new SelectList(_context.Notebook, "id", "id", paisOrigen.NotebookId);
            return View(paisOrigen);
        }

        // GET: PaisOrigen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaisOrigen == null)
            {
                return NotFound();
            }

            var paisOrigen = await _context.PaisOrigen
                .Include(p => p.Notebook)
                .FirstOrDefaultAsync(m => m.id == id);
            if (paisOrigen == null)
            {
                return NotFound();
            }

            return View(paisOrigen);
        }

        // POST: PaisOrigen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaisOrigen == null)
            {
                return Problem("Entity set 'MvcNotebooksContext.PaisOrigen'  is null.");
            }
            var paisOrigen = await _context.PaisOrigen.FindAsync(id);
            if (paisOrigen != null)
            {
                _context.PaisOrigen.Remove(paisOrigen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisOrigenExists(int id)
        {
          return (_context.PaisOrigen?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
