using System.Diagnostics.Eventing.Reader;

namespace Tesis.ViewModels
{
    public class EstudianteAsistenciaViewModel
    {
        public int Id { get; set; } // ID del estudiante
        public string Nombre { get; set; } = string.Empty; // Nombre del estudiante

        public DateTime Fecha { get; set; }
        public string Apellido { get; set; } = string.Empty;
        public int TotalAusente { get; set; } // Total de asistencias
        public int TotalPresente { get; set; } // Total de inasistencias
        
        public int TotalAusenteJustificado { get; set; }

        public int TotalAusenteInjustificado { get; set; }

        public int TotalTardanzaUncuarto { get; set; }

        public int TotalTardanzaMedia { get; set; }
        public double TotalFaltasCalculadas => TotalAusenteJustificado + TotalAusenteInjustificado + (TotalTardanzaUncuarto * 0.25) + (TotalTardanzaMedia * 0.5);
        public bool Presente { get; set; }

        public bool AusenteJustificado { get; set; }

        public bool AusenteInjustificado { get; set; }

        public bool TardanzaUncuarto { get; set; }
        public bool TardanzaMedia { get; set; }
        public string Estado { get; set; } = "Presente";
        public object? CursoId { get; set; }
    }
}
