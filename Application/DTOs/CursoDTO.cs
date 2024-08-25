namespace Application.DTOs
{
    public class CursoDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid ProfessorId { get; set; }
        public string ProfessorNome { get; set; }
        public List<MatriculaDTO> Matriculas { get; set; } = new List<MatriculaDTO>();
    }
}
