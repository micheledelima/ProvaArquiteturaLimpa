using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;

namespace Infrastructure.Repositories
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
