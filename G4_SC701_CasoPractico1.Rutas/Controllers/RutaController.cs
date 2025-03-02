using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View(await _context.Rutas.ToListAsync());
        }

        // GET: Ruta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ruta = await _context.Rutas.FirstOrDefaultAsync(r => r.Id == id);
            if (ruta == null)
                return NotFound();

            return View(ruta);
        }

        // GET: Ruta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ruta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nombre,Descripcion,Paradas,Horarios,Estado")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                // Asigna la fecha de registro en el momento de la creación.
                ruta.FechaRegistro = DateTime.Now;

                // Se asigna el ID del usuario que registra la ruta.
                // IMPORTANTE: En producción se debe obtener el ID del usuario autenticado.
                ruta.UsuarioRegistroId = 1;
                // Razón: Se asigna el ID en lugar de una cadena, ya que UsuarioRegistroId es la FK que relaciona con la tabla Usuarios.

                _context.Add(ruta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ruta);
        }

        // GET: Ruta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null)
                return NotFound();

            return View(ruta);
        }

        // POST: Ruta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion,Paradas,Horarios,Estado,FechaRegistro,UsuarioRegistroId")] Ruta ruta)
        {
            if (id != ruta.Id)
                return NotFound();

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ruta);
        }

        // GET: Ruta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ruta = await _context.Rutas.FirstOrDefaultAsync(r => r.Id == id);
            if (ruta == null)
                return NotFound();

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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RutaExists(int id)
        {
            return _context.Rutas.Any(e => e.Id == id);
        }
    }
}
