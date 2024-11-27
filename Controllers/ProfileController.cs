using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using snippets.Data;
using snippets.Models;

namespace snippets.Controllers
{
    public class ProfileController(ApiDbContext context) : Controller
    {
        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var apiDbContext = context.Profiles.Include(p => p.User);
            return View(await apiDbContext.ToListAsync());
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Id");
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Username,Photo,CreatedAt,UpdatedAt")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                profile.Id = Guid.NewGuid();
                profile.CreatedAt = DateTime.UtcNow;
                profile.UpdatedAt = DateTime.UtcNow;
                context.Add(profile);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Id", profile.UserId);
            return View(profile);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Id", profile.UserId);
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserId,Username,Photo,CreatedAt,UpdatedAt")] Profile profile)
        {
            if (id != profile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    profile.UpdatedAt = DateTime.UtcNow;
                    context.Update(profile);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.Id))
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
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Id", profile.UserId);
            return View(profile);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profile = await context.Profiles.FindAsync(id);
            if (profile != null)
            {
                context.Profiles.Remove(profile);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(Guid id)
        {
            return context.Profiles.Any(e => e.Id == id);
        }
    }
}
