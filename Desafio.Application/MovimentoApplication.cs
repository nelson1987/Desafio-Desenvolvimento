using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;
using System.Collections.Generic;

namespace Desafio.Application
{
    public class MovimentoApplication : IMovimentoApplication
    {
        private IMovimentoRepository MovimentoRepository { get; set; }

        public MovimentoApplication(IMovimentoRepository MovimentoRepository)
        {
            this.MovimentoRepository = MovimentoRepository;
        }

        public List<Movimentacao> Listar()
        {
            return MovimentoRepository.FindAll();
        }
    }
}
