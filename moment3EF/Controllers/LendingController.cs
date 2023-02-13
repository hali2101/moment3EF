using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moment3EF.Data;
using moment3EF.Models;

namespace moment3EF.Controllers
{
    public class LendingController : Controller
    {
        private readonly RecordContext _context;

        public LendingController(RecordContext context)
        {
            _context = context;
        }

        // GET: Lending
        public async Task<IActionResult> Index()
        {
            var recordContext = _context.Lendings.Include(l => l.Album);
            return View(await recordContext.ToListAsync());
        }

        // GET: Lending/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lendings == null)
            {
                return NotFound();
            }

            var lending = await _context.Lendings
                .Include(l => l.Album)
                .FirstOrDefaultAsync(m => m.LendingId == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // GET: Lending/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumName");

            return View();

        }

        // POST: Lending/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LendingId,Name,Email,AlbumId,DateOfLending")] Lending lending)
        {

            if (ModelState.IsValid)
            {
                // Kontrollera om album finns -> ändra InHouse i tabellen Album till false
                var album = await _context.Albums.FindAsync(lending.AlbumId);

                //kontroll om listan är tom eller inte och om albumet är utlånat eller inte
                if (album != null && album.InHouse == true)
                {
                    //lägger till utlåning samt uppdaterar InHouse i album-tabellen
                    _context.Add(lending);
                    album.InHouse = false;
                    _context.Update(album);
                }
                else
                {
                    //felmeddelande ifall albumet redan är utlånat
                    ViewBag.ErrorMessage = "Tyvärr är albumet redan utlånat!";
                    ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumName");
                    return View();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumId", lending.AlbumId);
            return View(lending);
        }

        // GET: Lending/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lendings == null)
            {
                return NotFound();
            }

            var lending = await _context.Lendings.FindAsync(id);
            if (lending == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumName", lending.AlbumId);
            return View(lending);
        }

        // POST: Lending/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LendingId,Name,Email,AlbumId,DateOfLending")] Lending lending)
        {
            if (id != lending.LendingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingExists(lending.LendingId))
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
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumName", lending.AlbumId);
            return View(lending);
        }

        // GET: Lending/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lendings == null)
            {
                return NotFound();
            }

            var lending = await _context.Lendings
                .Include(l => l.Album)
                .FirstOrDefaultAsync(m => m.LendingId == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // POST: Lending/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lendings == null)
            {
                return Problem("Entity set 'RecordContext.Lendings'  is null.");
            }
            var lending = await _context.Lendings.FindAsync(id);
            if (lending != null)
            {
                _context.Lendings.Remove(lending);
            }
            // Kontrollera om album finns -> ändra InHouse i tabellen Album till true
            var album = await _context.Albums.FindAsync(lending.AlbumId);
            if (album != null)
            {
                album.InHouse = true;
                _context.Update(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendingExists(int id)
        {
          return (_context.Lendings?.Any(e => e.LendingId == id)).GetValueOrDefault();
        }
    }
}
