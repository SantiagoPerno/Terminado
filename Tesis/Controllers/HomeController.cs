using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tesis.Models;
using Tesis.ViewModels;

namespace Tesis.Controllers
{
    [Authorize(Roles = "Administrador, Gestion")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbtesisContext _context;

        public HomeController(ILogger<HomeController> logger, DbtesisContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos
                .Include(c => c.Estudiantes)
                .ToListAsync();

            var viewModel = new EstadisticaEstudiantesViewModel
            {
                TotalEstudiantes = cursos.Sum(c => c.Estudiantes.Count)
            };

            foreach (var curso in cursos)
            {
                viewModel.EstudiantesPorCurso[curso.Nombre] = curso.Estudiantes.Count;
           
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
