using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;

namespace Infrastructure.Repositories
{
    public class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
