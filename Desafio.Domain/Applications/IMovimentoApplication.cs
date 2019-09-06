using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.Domain.Applications
{
    public interface IMovimentoApplication
    {
        List<Movimentacao> Listar();
    }
}
