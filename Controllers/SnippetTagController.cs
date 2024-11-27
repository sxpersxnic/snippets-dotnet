using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using snippets.Data;
using snippets.Models;

namespace snippets.Controllers
{
    public class SnippetTagController(ApiDbContext context) : Controller
    {
        // GET: SnippetTag
        public async Task<IActionResult> Index()
        {
            var apiDbContext = context.SnippetTags.Include(s => s.Snippet).Include(s => s.Tag);
            return View(await apiDbContext.ToListAsync());
        }

        // GET: SnippetTag/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippetTag = await context.SnippetTags
                .Include(s => s.Snippet)
                .Include(s => s.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snippetTag == null)
            {
                return NotFound();
            }

            return View(snippetTag);
        }

        // GET: SnippetTag/Create
        public IActionResult Create()
        {
            ViewData["SnippetId"] = new SelectList(context.Snippets, "Id", "Id");
            ViewData["TagId"] = new SelectList(context.Tags, "Id", "Id");
            return View();
        }

        // POST: SnippetTag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SnippetId,TagId")] SnippetTag snippetTag)
        {
            if (ModelState.IsValid)
            {
                snippetTag.Id = Guid.NewGuid();
                context.Add(snippetTag);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SnippetId"] = new SelectList(context.Snippets, "Id", "Id", snippetTag.SnippetId);
            ViewData["TagId"] = new SelectList(context.Tags, "Id", "Id", snippetTag.TagId);
            return View(snippetTag);
        }

        // GET: SnippetTag/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippetTag = await context.SnippetTags.FindAsync(id);
            if (snippetTag == null)
            {
                return NotFound();
            }
            ViewData["SnippetId"] = new SelectList(context.Snippets, "Id", "Id", snippetTag.SnippetId);
            ViewData["TagId"] = new SelectList(context.Tags, "Id", "Id", snippetTag.TagId);
            return View(snippetTag);
        }

        // POST: SnippetTag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SnippetId,TagId")] SnippetTag snippetTag)
        {
            if (id != snippetTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(snippetTag);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnippetTagExists(snippetTag.Id))
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
            ViewData["SnippetId"] = new SelectList(context.Snippets, "Id", "Id", snippetTag.SnippetId);
            ViewData["TagId"] = new SelectList(context.Tags, "Id", "Id", snippetTag.TagId);
            return View(snippetTag);
        }

        // GET: SnippetTag/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippetTag = await context.SnippetTags
                .Include(s => s.Snippet)
                .Include(s => s.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snippetTag == null)
            {
                return NotFound();
            }

            return View(snippetTag);
        }

        // POST: SnippetTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var snippetTag = await context.SnippetTags.FindAsync(id);
            if (snippetTag != null)
            {
                context.SnippetTags.Remove(snippetTag);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnippetTagExists(Guid id)
        {
            return context.SnippetTags.Any(e => e.Id == id);
        }
    }
}
