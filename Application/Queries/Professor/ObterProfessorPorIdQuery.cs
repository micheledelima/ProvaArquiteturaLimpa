using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Professor
{
    public class ObterProfessorPorIdQuery : IRequest<ProfessorDTO>
    {
        public Guid Id { get; }

        public ObterProfessorPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
