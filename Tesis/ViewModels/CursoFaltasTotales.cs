
using System.Collections.Generic;
using Tesis.Models;

namespace Tesis.ViewModels
{
    public class CursoFichaMedicaViewModel
    {
        public Cursos Curso { get; set; }

        public List<EstudianteConFaltasViewModel> Estudiantes { get; set; }
    }

    public class EstudianteConFaltasViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool TieneDni { get; set; }
        public bool TieneDniPadre { get; set; }
        public bool TieneDniMadre { get; set; }
        public bool TieneDniTutor { get; set; }
        public bool TienePartidaNacimiento { get; set; }
        public bool TieneCUS { get; set; }
        public bool TieneISA { get; set; }
        public bool TieneConstanciaDomicilio { get; set; }
        public double TotalFaltasCalculadas { get; set; }
    }
}
