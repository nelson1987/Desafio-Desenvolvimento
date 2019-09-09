using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.Domain.Applications
{
    public interface IMovimentoApplication
    {
        List<Movimentacao> Listar();
        void Resgatar(Movimentacao resgate);
        void Aplicar(Movimentacao resgate);
    }
}
