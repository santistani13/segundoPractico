using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using segundoPractico.Data;
using segundoPractico.Models;

namespace segundoPractico.Controllers
{
    public class NotebookController : Controller
    {
        private readonly MvcNotebooksContext _context;

        public NotebookController(MvcNotebooksContext context)
        {
            _context = context;
        }

        // GET: Notebook
        public async Task<IActionResult> Index()
        {

              return _context.Notebook != null ? 
                          View(await _context.Notebook.ToListAsync()) :
                          Problem("Entity set 'MvcNotebooksContext.Notebook'  is null.");
        }

        // GET: Notebook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notebook == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebook
                .FirstOrDefaultAsync(m => m.id == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // GET: Notebook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notebook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,marca,modelo,precio")] Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notebook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notebook);
        }

        // GET: Notebook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notebook == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebook.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }
            return View(notebook);
        }

        // POST: Notebook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,marca,modelo,precio")] Notebook notebook)
        {
            if (id != notebook.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotebookExists(notebook.id))
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
            return View(notebook);
        }

        // GET: Notebook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notebook == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebook
                .FirstOrDefaultAsync(m => m.id == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // POST: Notebook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notebook == null)
            {
                return Problem("Entity set 'MvcNotebooksContext.Notebook'  is null.");
            }
            var notebook = await _context.Notebook.FindAsync(id);
            if (notebook != null)
            {
                _context.Notebook.Remove(notebook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotebookExists(int id)
        {
          return (_context.Notebook?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
