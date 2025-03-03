using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G4_SC701_CasoPractico1.Rutas.Models;

namespace G4_SC701_CasoPractico1.Rutas.Controllers
{
    public class RutaController : Controller
    {
        private readonly CP1Context _context;

        public RutaController(CP1Context context)
        {
            _context = context;
        }

        // GET: Ruta
        public async Task<IActionResult> Index()
        {
            var cP1Context = _context.Rutas.Include(r => r.usuario);
            return View(await cP1Context.ToListAsync());
        }

        // GET: Ruta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas
                            .Include(v => v.usuario)
                            .FirstOrDefaultAsync(m => m.Id == id);

            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // GET: Ruta/Create
        public IActionResult Create()
        {
            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "Contraseña");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Estado");
            return View();
        }

        // POST: Ruta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreRuta,Descripcion, Estado,FechaRegistro,IdUsuarioRegistro,IdVehiculo")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ruta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "Contraseña", ruta.IdUsuarioRegistro);
            
            return View(ruta);
        }

        // GET: Ruta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas
                       .Include(u => u.usuario)
                       .FirstOrDefaultAsync(m => m.Id == id);
            if (ruta == null)
            {
                return NotFound();
            }
            ViewData["Usuario"] = ruta.usuario?.NombreUsuario;
            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "Contraseña", ruta.IdUsuarioRegistro);
            
            return View(ruta);
        }

        // POST: Ruta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreRuta, Descripcion,Estado,FechaRegistro,IdUsuarioRegistro,IdVehiculo")] Ruta ruta)
        {
            if (id != ruta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutaExists(ruta.Id))
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
            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "Contraseña", ruta.IdUsuarioRegistro);
            
            return View(ruta);
        }

        // GET: Ruta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas
                .Include(r => r.usuario)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // POST: Ruta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta != null)
            {
                _context.Rutas.Remove(ruta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutaExists(int id)
        {
            return _context.Rutas.Any(e => e.Id == id);
        }
    }
}
