using System.Collections.Generic;
using System.Linq;
using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository.Repositories
{
    public class MovimentoRepository : BaseRepository<Movimentacao>, IMovimentoRepository
    {
        public MovimentoRepository(DesafioContext context)
        : base(context)
        {
        }

        public List<Movimentacao> BuscarMovimentos()
        {
            return context.Set<Movimentacao>()
                .Include(x=>x.Pessoa)
                .Include(x=>x.Fundo)
                .ToList();
        }
    }
}
