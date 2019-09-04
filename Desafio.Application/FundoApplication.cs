using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;
using System.Collections.Generic;

namespace Desafio.Application
{
    public class FundoApplication : IFundoApplication
    {
        private IFundoRepository fundoRepository { get; set; }

        public FundoApplication(IFundoRepository fundoRepository)
        {
            this.fundoRepository = fundoRepository;
        }

        public List<Fundo> Listar()
        {
            return fundoRepository.FindAll();
        }
    }
}
