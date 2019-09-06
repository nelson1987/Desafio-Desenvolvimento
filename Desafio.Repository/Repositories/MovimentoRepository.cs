using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;

namespace Desafio.Repository.Repositories
{
    public class MovimentoRepository : BaseRepository<Movimentacao>, IMovimentoRepository
    {
        public MovimentoRepository(DesafioContext context)
        : base(context)
        {
        }
    }
}
