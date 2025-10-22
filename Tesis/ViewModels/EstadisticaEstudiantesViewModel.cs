namespace Tesis.ViewModels
{
    public class EstadisticaEstudiantesViewModel
    {
        public int TotalEstudiantes { get; set; }
        public Dictionary<string, int> EstudiantesPorCurso { get; set; } = new();
        public Dictionary<string, int> FotocopiasPorCurso { get; set; } = new();
    }
}