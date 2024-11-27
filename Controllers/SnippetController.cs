using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using snippets.Data;
using snippets.Models;

namespace snippets.Controllers
{
    public class SnippetController(ApiDbContext context) : Controller
    {
        // GET: Snippet
        public async Task<IActionResult> Index()
        {
            var apiDbContext = context.Snippets.Include(s => s.Profile);
            return View(await apiDbContext.ToListAsync());
        }

        // GET: Snippet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await context.Snippets
                .Include(s => s.Profile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snippet == null)
            {
                return NotFound();
            }

            return View(snippet);
        }

        // GET: Snippet/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(context.Profiles, "Id", "Id");
            return View();
        }

        // POST: Snippet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfileId,CreatedAt,UpdatedAt")] Snippet snippet)
        {
            if (ModelState.IsValid)
            {
                snippet.Id = Guid.NewGuid();
                snippet.CreatedAt = DateTime.UtcNow;
                snippet.UpdatedAt = DateTime.UtcNow;
                context.Add(snippet);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(context.Profiles, "Id", "Id", snippet.ProfileId);
            return View(snippet);
        }

        // GET: Snippet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await context.Snippets.FindAsync(id);
            if (snippet == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(context.Profiles, "Id", "Id", snippet.ProfileId);
            return View(snippet);
        }

        // POST: Snippet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProfileId,CreatedAt,UpdatedAt")] Snippet snippet)
        {
            if (id != snippet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(snippet);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnippetExists(snippet.Id))
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
            ViewData["ProfileId"] = new SelectList(context.Profiles, "Id", "Id", snippet.ProfileId);
            return View(snippet);
        }

        // GET: Snippet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await context.Snippets
                .Include(s => s.Profile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snippet == null)
            {
                return NotFound();
            }

            return View(snippet);
        }

        // POST: Snippet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var snippet = await context.Snippets.FindAsync(id);
            if (snippet != null)
            {
                context.Snippets.Remove(snippet);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnippetExists(Guid id)
        {
            return context.Snippets.Any(e => e.Id == id);
        }
    }
}
