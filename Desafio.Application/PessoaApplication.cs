using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;
using System.Collections.Generic;

namespace Desafio.Application
{
    public class PessoaApplication : IPessoaApplication
    {
        private IPessoaRepository PessoaRepository { get; set; }

        public PessoaApplication(IPessoaRepository PessoaRepository)
        {
            this.PessoaRepository = PessoaRepository;
        }

        public List<Pessoa> Listar()
        {
            return PessoaRepository.FindAll();
        }
    }
}
