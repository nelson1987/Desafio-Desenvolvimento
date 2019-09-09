using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;

namespace Desafio.Repository.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DesafioContext context)
        : base(context)
        {
        }

        public Pessoa FindByCpf(string cpf)
        {
            return Find(x => x.Cpf == cpf);
        }
    }
}
