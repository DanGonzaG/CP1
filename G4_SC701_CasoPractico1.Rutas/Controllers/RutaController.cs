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
            var cP1Context = _context.Rutas.Include(r => r.usuario).Include(r => r.vehiculo);
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
                .Include(r => r.usuario)
                .Include(r => r.vehiculo)
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
            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "NombreUsuario");

            var vehiculos = _context.Vehiculos
                .Select(v => new
                {
                    Id = v.Id,
                    DisplayText = v.Modelo + " - " + v.CapacidadPasajeros + " pasajeros"
                })
                .ToList();

            ViewData["IdVehiculo"] = new SelectList(vehiculos, "Id", "DisplayText");
            return View();
        }

        // POST: Ruta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreRuta,Estado,IdUsuarioRegistro,IdVehiculo")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                ruta.FechaRegistro = DateTime.UtcNow;
                _context.Add(ruta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "NombreUsuario", ruta.IdUsuarioRegistro);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Modelo", ruta.IdVehiculo);
            return View(ruta);
        }

        // Nuevo método para obtener información del vehículo mediante AJAX
        [HttpGet]
        public JsonResult GetVehiculoInfo(int id)
        {
            var vehiculo = _context.Vehiculos
                .Where(v => v.Id == id)
                .Select(v => new
                {
                    modelo = v.Modelo,
                    capacidadPasajeros = v.CapacidadPasajeros
                })
                .FirstOrDefault();

            if (vehiculo == null)
            {
                return Json(new { modelo = "No encontrado", capacidadPasajeros = "N/A" });
            }

            return Json(vehiculo);
        }

        private bool RutaExists(int id)
        {
            return _context.Rutas.Any(e => e.Id == id);
        }

        // GET: Ruta/Edit/5
        // GET: Ruta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas
                .Include(r => r.vehiculo) // Incluir los datos del vehículo
                .FirstOrDefaultAsync(r => r.Id == id);

            if (ruta == null)
            {
                return NotFound();
            }

            ViewData["IdUsuarioRegistro"] = new SelectList(_context.Usuarios, "Id", "Contraseña", ruta.IdUsuarioRegistro);
            ViewData["IdVehiculo"] = new SelectList(
                _context.Vehiculos.Select(v => new
                {
                    Id = v.Id,
                    Descripcion = v.Modelo + " - " + v.CapacidadPasajeros + " pasajeros"
                }),
                "Id", "Descripcion", ruta.IdVehiculo
            );

            return View(ruta);
        }


        // POST: Ruta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreRuta,Estado,IdUsuarioRegistro,IdVehiculo")] Ruta ruta)
        {
            if (id != ruta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ruta.FechaRegistro = DateTime.UtcNow; // Se actualiza la fecha
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
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Estado", ruta.IdVehiculo);
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
                .Include(r => r.vehiculo)
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

        private bool RutaExistss(int id)
        {
            return _context.Rutas.Any(e => e.Id == id);
        }
    }
}
