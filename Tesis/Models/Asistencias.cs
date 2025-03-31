using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Tesis.Models
{
    public class Asistencias
    {
            [Key]
            public int Id { get; set; } // ID único del registro de asistencia

            [Required]
            public int CursoId { get; set; } // Relación con el curso

            [ForeignKey("CursoId")]
            public Cursos Curso { get; set; } = null!; // Referencia al curso

            [Required]
            public int EstudianteId { get; set; } // Relación con el estudiante

            [ForeignKey("EstudianteId")]
            [DeleteBehavior(DeleteBehavior.Cascade)]
        public Estudiantes Estudiante { get; set; } = null!; // Referencia al estudiante

            [Required]
            public DateTime Fecha { get; set; } // Fecha de la asistencia

            public bool Presente { get; set; } // Indicador de asistencia (presente o ausente)

            public bool AusenteJustificado { get; set; }

            public bool AusenteInjustificado { get; set; }

            public bool TardanzaUncuarto { get; set; }

            public bool TardanzaMedia { get; set; }
            public int FaltasConsecutivas { get; set; }
           public string Estado { get; set; } = "Presente";
    }
}

