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
    public class VehiculoController : Controller
    {
        private readonly CP1Context _context;

        public VehiculoController(CP1Context context)
        {
            _context = context;
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
            var cP1Context = _context.Vehiculos.Include(v => v.usuario);
            return View(await cP1Context.ToListAsync());
        }

        // GET: Vehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                            .Include(v => v.usuario) 
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public IActionResult Create()
        {
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Contraseña");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Modelo,CapacidadPasajeros,Estado,FechaRegistro,idUsuario")] Vehiculo vehiculo)
        {
            var date = DateTime.Now;

            
            var usuario = await _context.Usuarios
                                .Include(u => u.Rol)
                                .Where(u => u.Id == vehiculo.idUsuario)
                                .Select(u => new { u.Id, u.NombreUsuario, u.RolId, RolNombre = u.Rol.Nombre })
                                .FirstOrDefaultAsync();
           


            
            if (ModelState.IsValid)
            {
                vehiculo.FechaRegistro = date;
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "NombreUsuario", vehiculo.idUsuario);
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                    .Include(v => v.usuario) 
                    .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["Usuario"] = vehiculo.usuario?.NombreUsuario;
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Usuario", vehiculo.idUsuario);
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Modelo,CapacidadPasajeros,Estado,FechaRegistro,idUsuario")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Usuario", vehiculo.idUsuario);
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
