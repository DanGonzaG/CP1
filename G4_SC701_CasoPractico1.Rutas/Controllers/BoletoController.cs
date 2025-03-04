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
    public class BoletoController : Controller
    {
        private readonly CP1Context _context;

        public BoletoController(CP1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cP1Context = _context.Boletos.Include(b => b.ruta).Include(b => b.usuario);
            return View(await cP1Context.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .Include(b => b.ruta)
                .Include(b => b.usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        public IActionResult Create()
        {
            ViewData["IdRuta"] = new SelectList(_context.Rutas, "Id", "NombreRuta");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NombreUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdRuta,IdUsuario")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                var ruta = await _context.Rutas
                    .Include(r => r.vehiculo)
                    .Include(r => r.horario)
                    .FirstOrDefaultAsync(r => r.Id == boleto.IdRuta);

                if (ruta == null)
                {
                    ModelState.AddModelError("IdRuta", "La ruta seleccionada no existe.");
                    return View(boleto);
                }

                boleto.FechaCompra = DateTime.Now;

                // Validar disponibilidad de asientos
                int capacidadVehiculo = ruta.vehiculo?.CapacidadPasajeros ?? 0;
                int boletosVendidos = await _context.Boletos
                    .CountAsync(b => b.IdRuta == boleto.IdRuta && b.FechaCompra.Date == boleto.FechaCompra.Date);

                if (boletosVendidos >= capacidadVehiculo)
                {
                    ModelState.AddModelError("", "No hay asientos disponibles para esta ruta.");
                    return View(boleto);
                }

                _context.Add(boleto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdRuta"] = new SelectList(_context.Rutas, "Id", "NombreRuta", boleto.IdRuta);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NombreUsuario", boleto.IdUsuario);
            return View(boleto);
        }

        [HttpGet]
        public async Task<IActionResult> GetCapacidadRuta(int id)
        {
            var ruta = await _context.Rutas
                .Include(r => r.vehiculo)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (ruta == null || ruta.vehiculo == null)
            {
                return Json(new { capacidad = "No disponible" });
            }

            return Json(new { capacidad = ruta.vehiculo.CapacidadPasajeros });
        }




        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null) return NotFound();

            ViewData["IdRuta"] = new SelectList(_context.Rutas, "Id", "NombreRuta", boleto.IdRuta);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NombreUsuario", boleto.IdUsuario);
            return View(boleto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdRuta,IdUsuario,FechaCompra")] Boleto boleto)
        {
            if (id != boleto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boleto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletoExists(boleto.Id))
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
            ViewData["IdRuta"] = new SelectList(_context.Rutas, "Id", "Id", boleto.IdRuta);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Contraseña", boleto.IdUsuario);
            return View(boleto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .Include(b => b.ruta)
                .Include(b => b.usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto != null)
            {
                _context.Boletos.Remove(boleto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletoExists(int id)
        {
            return _context.Boletos.Any(e => e.Id == id);
        }
    }
}