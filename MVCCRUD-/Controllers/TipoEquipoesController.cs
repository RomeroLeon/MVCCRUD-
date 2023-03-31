using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD_.Models;

namespace MVCCRUD_.Controllers
{
    public class TipoEquipoesController : Controller
    {
        private readonly MvccrudContext _context;

        public TipoEquipoesController(MvccrudContext context)
        {
            _context = context;
        }

        // GET: TipoEquipoes
        public async Task<IActionResult> Index()
        {
              return _context.TipoEquipos != null ? 
                          View(await _context.TipoEquipos.ToListAsync()) :
                          Problem("Entity set 'MvccrudContext.TipoEquipos'  is null.");
        }

        // GET: TipoEquipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEquipos == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipos
                .FirstOrDefaultAsync(m => m.IdTipoEquipo == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoEquipo,Descripcion,Estado")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEquipos == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipos.FindAsync(id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoEquipo,Descripcion,Estado")] TipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.IdTipoEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEquipoExists(tipoEquipo.IdTipoEquipo))
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
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEquipos == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipos
                .FirstOrDefaultAsync(m => m.IdTipoEquipo == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEquipos == null)
            {
                return Problem("Entity set 'MvccrudContext.TipoEquipos'  is null.");
            }
            var tipoEquipo = await _context.TipoEquipos.FindAsync(id);
            if (tipoEquipo != null)
            {
                _context.TipoEquipos.Remove(tipoEquipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEquipoExists(int id)
        {
          return (_context.TipoEquipos?.Any(e => e.IdTipoEquipo == id)).GetValueOrDefault();
        }
    }
}
