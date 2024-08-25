namespace Domain.Entities
{
    public class Matricula
    {
        public Guid Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public string Status { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }

        public bool PodeConcluir()
        {
            return Status == "Ativa" && Curso.PodeAdicionarAluno() && DataMatricula > DateTime.Today && Aluno != null;
        }
    }
}