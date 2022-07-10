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
    public class ActividadesUsuariosController : Controller
    {
        private readonly ProyectoGymContext _context;

        public ActividadesUsuariosController(ProyectoGymContext context)
        {
            _context = context;
        }

        // GET: ActividadesUsuarios
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.User = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);


            var datos = (from au in _context.ActividadesUsuario
                         join u in _context.Usuarios on au.Usuario.Id equals u.Id
                         join a in _context.Actividades on au.Actividad.Id equals a.Id
                         where u.Id == id
                         select new ActividadesUsuario {
                            Id = au.Id,
                            Usuario = u,
                            Actividad = a
                         }).ToListAsync();

            return View(await datos);
        }

        // GET: ActividadesUsuarios/Create
        public ActionResult Create(int userId)
        {
            ViewBag.User = _context.Usuarios.FirstOrDefault(m => m.Id == userId);


            var actividadesDelUsuario = from au in _context.ActividadesUsuario 
                                        where au.Usuario.Id == userId
                                        select au.Actividad.Id;

            var ActividadesParaAgregar = from a in _context.Actividades
                                         where !actividadesDelUsuario.Contains(a.Id)
                                         select a;

            ViewData["ActividadesParaAgregar"] = ActividadesParaAgregar.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int userId, int actividadId)
        {
            ActividadesUsuario actividadesUsuario = new ActividadesUsuario();
            if (ModelState.IsValid)
            {
                actividadesUsuario.Actividad = await _context.Actividades.FindAsync(actividadId);
                actividadesUsuario.Usuario = await _context.Usuarios.FindAsync(userId);
                _context.Add(actividadesUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { @id = userId });
            }
            return View(actividadesUsuario);
        }

        // GET: ActividadesUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }


            //var actividadesUsuario = await _context.ActividadesUsuario
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var actividadesUsuario = await (from au in _context.ActividadesUsuario
                                            join a in _context.Actividades on au.Actividad.Id equals a.Id
                                            where au.Id == id
                                            select new ActividadesUsuario {
                                                Id = au.Id,
                                                Actividad = a
                                            }).FirstOrDefaultAsync();


            if (actividadesUsuario == null)
            {
                return NotFound();
            }

            ViewBag.userId = userId;
            return View(actividadesUsuario);
        }

        // POST: ActividadesUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? userId)
        {
            var actividadesUsuario = await _context.ActividadesUsuario.FindAsync(id);
            _context.ActividadesUsuario.Remove(actividadesUsuario);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index), new { @id = userId });
        }

        private bool ActividadesUsuarioExists(int id)
        {
            return _context.ActividadesUsuario.Any(e => e.Id == id);
        }
    }
}
