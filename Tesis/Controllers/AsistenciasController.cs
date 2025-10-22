using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tesis.Models;
using Tesis.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace Tesis.Controllers
{
    [Authorize(Roles = "Administrador, Gestion")]
 
    public class AsistenciasController : Controller
    {
        private readonly DbtesisContext _context;

        public AsistenciasController(DbtesisContext context)
        {
            _context = context;
        }

        //Guardar asistencia del estudiante en la BD

        [HttpPost]
        public async Task<IActionResult> GuardarAsistencias(List<EstudianteAsistenciaViewModel> Asistencias, string Fecha)
        {
            var fechaAsistencia = DateTime.Parse(Fecha).Date;

            foreach (var asistencia in Asistencias)
            {
                var asistenciaExistente = await _context.Asistencias
                    .FirstOrDefaultAsync(a => a.EstudianteId == asistencia.Id && a.Fecha == fechaAsistencia);

                if (asistenciaExistente == null)
                {
                    var nuevaAsistencia = new Asistencias
                    {
                        EstudianteId = asistencia.Id,
                        CursoId = (await _context.Estudiantes.FindAsync(asistencia.Id)).CursoId,
                        Fecha = fechaAsistencia,
                        Estado = asistencia.Estado,
                        Presente = asistencia.Estado == "Presente",              
                        AusenteJustificado = asistencia.Estado == "AusenteJustificado",
                        AusenteInjustificado = asistencia.Estado == "AusenteInjustificado",
                        TardanzaUncuarto = asistencia.Estado == "TardanzaUncuarto",
                        TardanzaMedia = asistencia.Estado == "TardanzaMedia"
                    };
                    _context.Asistencias.Add(nuevaAsistencia);
                }
                else
                {
                    asistenciaExistente.Estado = asistencia.Estado;
                    asistenciaExistente.Presente = asistencia.Estado == "Presente";                
                    asistenciaExistente.AusenteJustificado = asistencia.Estado == "AusenteJustificado";
                    asistenciaExistente.AusenteInjustificado = asistencia.Estado == "AusenteInjustificado";
                    asistenciaExistente.TardanzaUncuarto = asistencia.Estado == "TardanzaUncuarto";
                    asistenciaExistente.TardanzaMedia = asistencia.Estado == "TardanzaMedia";
                    _context.Asistencias.Update(asistenciaExistente);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Asistencias");
        }


        // GET: Asistencias/EstudiantesPorCurso/1

        public async Task<IActionResult> EstudiantesPorCurso(int id, DateTime? fecha)
        {
            fecha ??= DateTime.Today;

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Where(e => e.CursoId == id)
                .ToListAsync();

            var asistencias = await _context.Asistencias
                .Where(a => estudiantes.Select(e => e.Id).Contains(a.EstudianteId))
                .ToListAsync();

            var estudiantesViewModel = estudiantes.Select(e => new EstudianteAsistenciaViewModel
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Estado = asistencias.FirstOrDefault(a => a.EstudianteId == e.Id)?.Estado ?? "Presente",
                Fecha = fecha.Value,

                TotalPresente = asistencias.Count(a => a.EstudianteId == e.Id && a.Presente),
                TotalAusenteJustificado = asistencias.Count(a => a.EstudianteId == e.Id && a.AusenteJustificado),
                TotalAusenteInjustificado = asistencias.Count(a => a.EstudianteId == e.Id && a.AusenteInjustificado),
                TotalTardanzaUncuarto = asistencias.Count(a => a.EstudianteId == e.Id && a.TardanzaUncuarto),
                TotalTardanzaMedia = asistencias.Count(a => a.EstudianteId == e.Id && a.TardanzaMedia),

             


            }).ToList();

            ViewBag.CursoNombre = curso.Nombre;
            ViewBag.CursoId = id;
            ViewBag.FechaSeleccionada = fecha.Value.ToString("yyyy-MM-dd");

            return View(estudiantesViewModel);
        }



        // GET: Asistencias
        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos
                .Include(c => c.Estudiantes) // ✅ Incluir estudiantes
                .ThenInclude(e => e.Asistencias) // ✅ Incluir asistencias de los estudiantes
                .ToListAsync();

            return View(cursos);
        }

        // GET: Asistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencias = await _context.Asistencias
                .Include(a => a.Curso)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asistencias == null)
            {
                return NotFound();
            }

            return View(asistencias);
        }

        // GET: Asistencias/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre");
            return View();
        }

        // POST: Asistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CursoId,EstudianteId,Fecha,Presente")] Asistencias asistencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", asistencias.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", asistencias.EstudianteId);
            return View(asistencias);
        }

        // GET: Asistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencias = await _context.Asistencias.FindAsync(id);
            if (asistencias == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", asistencias.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", asistencias.EstudianteId);
            return View(asistencias);
        }

        // POST: Asistencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CursoId,EstudianteId,Fecha,Presente")] Asistencias asistencias)
        {
            if (id != asistencias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciasExists(asistencias.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", asistencias.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", asistencias.EstudianteId);
            return View(asistencias);
        }

        // GET: Asistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencias = await _context.Asistencias
                .Include(a => a.Curso)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asistencias == null)
            {
                return NotFound();
            }

            return View(asistencias);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistencias = await _context.Asistencias.FindAsync(id);
            if (asistencias != null)
            {
                _context.Asistencias.Remove(asistencias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciasExists(int id)
        {
            return _context.Asistencias.Any(e => e.Id == id);
        }
    }
}
