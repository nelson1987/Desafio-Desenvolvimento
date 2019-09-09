using System.Collections.Generic;
using Desafio.Domain.Entities;

namespace Desafio.Domain.Repositories
{
    public interface IMovimentoRepository : IBaseRepository<Movimentacao>
    {
        List<Movimentacao> BuscarMovimentos();
    }
}
