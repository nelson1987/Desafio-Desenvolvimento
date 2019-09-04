using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.Domain.Applications
{
    public interface IFundoApplication
    {
        List<Fundo> Listar();
    }
}
