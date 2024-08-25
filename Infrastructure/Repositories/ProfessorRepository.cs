using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;

namespace Infrastructure.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
