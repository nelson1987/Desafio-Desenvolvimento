using System;
using Desafio.Domain.Entities;

namespace Desafio.Domain.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Pessoa FindByCpf(string cpf);
    }
}
