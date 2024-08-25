namespace Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int MaxAlunos { get; private set; } = 30;
        public List<Aluno> Alunos { get; set; } = [];
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public List<Matricula> Matriculas { get; set; } = [];

        public bool PodeAdicionarAluno()
        {
            return Alunos.Count < MaxAlunos;
        }
    }
}