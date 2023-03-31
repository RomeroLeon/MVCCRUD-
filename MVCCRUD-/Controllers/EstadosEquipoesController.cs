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
    public class EstadosEquipoesController : Controller
    {
        private readonly MvccrudContext _context;

        public EstadosEquipoesController(MvccrudContext context)
        {
            _context = context;
        }

        // GET: EstadosEquipoes
        public async Task<IActionResult> Index()
        {
              return _context.EstadosEquipos != null ? 
                          View(await _context.EstadosEquipos.ToListAsync()) :
                          Problem("Entity set 'MvccrudContext.EstadosEquipos'  is null.");
        }

        // GET: EstadosEquipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadosEquipos == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.EstadosEquipos
                .FirstOrDefaultAsync(m => m.IdEstadosEquipo == id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }

            return View(estadosEquipo);
        }

        // GET: EstadosEquipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosEquipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadosEquipo,Descripcion,Estado")] EstadosEquipo estadosEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosEquipo);
        }

        // GET: EstadosEquipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadosEquipos == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.EstadosEquipos.FindAsync(id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }
            return View(estadosEquipo);
        }

        // POST: EstadosEquipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadosEquipo,Descripcion,Estado")] EstadosEquipo estadosEquipo)
        {
            if (id != estadosEquipo.IdEstadosEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosEquipoExists(estadosEquipo.IdEstadosEquipo))
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
            return View(estadosEquipo);
        }

        // GET: EstadosEquipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadosEquipos == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.EstadosEquipos
                .FirstOrDefaultAsync(m => m.IdEstadosEquipo == id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }

            return View(estadosEquipo);
        }

        // POST: EstadosEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadosEquipos == null)
            {
                return Problem("Entity set 'MvccrudContext.EstadosEquipos'  is null.");
            }
            var estadosEquipo = await _context.EstadosEquipos.FindAsync(id);
            if (estadosEquipo != null)
            {
                _context.EstadosEquipos.Remove(estadosEquipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosEquipoExists(int id)
        {
          return (_context.EstadosEquipos?.Any(e => e.IdEstadosEquipo == id)).GetValueOrDefault();
        }
    }
}
