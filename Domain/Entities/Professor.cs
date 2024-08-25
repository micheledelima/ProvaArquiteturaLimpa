namespace Domain.Entities
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}