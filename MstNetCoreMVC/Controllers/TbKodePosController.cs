using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MstNetCoreMVC.Models;

namespace MstNetCoreMVC.Controllers;

public class TbKodePosController : Controller
{
    private readonly MyDbContext _context;

    public TbKodePosController(MyDbContext context)
    {
        _context = context;
    }

    // GET: TbKodePos
    public async Task<IActionResult> Index(string currentFilter,
    string searchString,
    int? pageNumber)
    {
        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewData["CurrentFilter"] = searchString;
        var kodepos = from m in _context.TbKodePos
                       select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            kodepos = kodepos.Where(s => s.Propinsi.Contains(searchString)
                                   || s.Kabupaten.Contains(searchString));
        }

        int pageSize = 10;

        return View(await PaginatedList<TbKodePos>.CreateAsync(kodepos.AsNoTracking(), pageNumber ?? 1, pageSize));
    }

    // GET: TbKodePos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tbKodePos = await _context.TbKodePos
            .FirstOrDefaultAsync(m => m.Id == id);
        return tbKodePos == null ? NotFound() : View(tbKodePos);
    }

    // GET: TbKodePos/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TbKodePos/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NoKodePos,Kelurahan,Kecamatan,Jenis,Kabupaten,Propinsi")] TbKodePos tbKodePos)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tbKodePos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tbKodePos);
    }

    // GET: TbKodePos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tbKodePos = await _context.TbKodePos.FindAsync(id);
        return tbKodePos == null ? NotFound() : View(tbKodePos);
    }

    // POST: TbKodePos/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NoKodePos,Kelurahan,Kecamatan,Jenis,Kabupaten,Propinsi")] TbKodePos tbKodePos)
    {
        if (id != tbKodePos.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tbKodePos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKodePosExists(tbKodePos.Id))
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
        return View(tbKodePos);
    }

    // GET: TbKodePos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tbKodePos = await _context.TbKodePos
            .FirstOrDefaultAsync(m => m.Id == id);
        return tbKodePos == null ? NotFound() : View(tbKodePos);
    }

    // POST: TbKodePos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var tbKodePos = await _context.TbKodePos.FindAsync(id);
        _context.TbKodePos.Remove(tbKodePos);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TbKodePosExists(int id)
    {
        return _context.TbKodePos.Any(e => e.Id == id);
    }
}
