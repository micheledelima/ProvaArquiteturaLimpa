namespace Application.DTOs
{
    public class MatriculaDTO
    {
        public Guid Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public string Status { get; set; }
        public Guid AlunoId { get; set; }
        public string AlunoNome { get; set; }
    }
}
