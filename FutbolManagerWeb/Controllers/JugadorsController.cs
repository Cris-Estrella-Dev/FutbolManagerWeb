using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FutbolManagerWeb.Data;
using FutbolManagerWeb.Models;

namespace FutbolManagerWeb.Controllers
{
    public class JugadorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jugadores.Include(j => j.Equipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jugadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Equipo)
               
                .FirstOrDefaultAsync(m => m.JugadorId == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "EquipoId", "Nombre");

            return View();
        }

        // POST: Jugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JugadorId,Nombre,Apellidos,Dorsal,Edad,EquipoId")] Jugador jugador)
        {
            
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "EquipoId", "Nombre", jugador.EquipoId);

            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "EquipoId", "Nombre", jugador.EquipoId);
 
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JugadorId,Nombre,Apellidos,Dorsal,Edad,EquipoId")] Jugador jugador)
        {
            if (id != jugador.JugadorId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.JugadorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "EquipoId", "Nombre", jugador.EquipoId);
         
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Equipo)
            
                .FirstOrDefaultAsync(m => m.JugadorId == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugadores.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.JugadorId == id);
        }
    }
}
