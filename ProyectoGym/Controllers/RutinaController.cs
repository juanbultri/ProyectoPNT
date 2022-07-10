using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Context;
using ProyectoGym.Models;

namespace ProyectoGym.Controllers
{
    public class RutinaController : Controller
    {
        private readonly ProyectoGymContext _context;

        public RutinaController(ProyectoGymContext context)
        {
            _context = context;
        }

        // GET: Rutina
        public async Task<IActionResult> Index(int userId)
        {
            ViewBag.User = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == userId);
            return View(await _context.Rutinas.Where(rutina => rutina.UsuarioId == userId).OrderByDescending(rutina => rutina.RutinaId).ToListAsync());
        }

        // GET: Rutina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .FirstOrDefaultAsync(m => m.RutinaId == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // GET: Rutina/Create
        public IActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        // POST: Rutina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RutinaId,FechaInicio,FechaFin,Detalle, UsuarioId")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                var rutinas = (from r in _context.Rutinas
                               where r.UsuarioId == rutina.UsuarioId && r.FechaFin == null
                               select r
                               ).ToArray();

                foreach (var unaRutina in rutinas) {
                    unaRutina.FechaFin = rutina.FechaInicio;
                    _context.Update(unaRutina);
                }

                _context.Add(rutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { @userId = rutina.UsuarioId });
            }
            return View(rutina);
        }

        // GET: Rutina/Edit/5
        public async Task<IActionResult> Edit(int? id, int userId)
        {
            ViewBag.UserId = userId;

            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }
            return View(rutina);
        }

        // POST: Rutina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RutinaId,FechaInicio,FechaFin,Detalle,UsuarioId")] Rutina rutina)
        {
            if (id != rutina.RutinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutinaExists(rutina.RutinaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { @userId=rutina.UsuarioId });
            }
            return View(rutina);
        }

        // GET: Rutina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .FirstOrDefaultAsync(m => m.RutinaId == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // POST: Rutina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rutina = await _context.Rutinas.FindAsync(id);
            _context.Rutinas.Remove(rutina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { @userId = rutina.UsuarioId});
        }

        private bool RutinaExists(int id)
        {
            return _context.Rutinas.Any(e => e.RutinaId == id);
        }
    }
}
