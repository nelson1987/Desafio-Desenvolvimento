using System;
using System.Linq;
using Desafio.Domain.Entities;
using Desafio.Domain.Exceptions;

namespace Desafio.Domain.Services
{
    public class ResgateService : MovimentacaoService
    {
        public ResgateService(Pessoa investidor, decimal valorResgatado, Fundo fundo)
            : base(investidor, (valorResgatado *-1), fundo)
        {
        }

        public override bool isValid()
        {
            if (!Investidor.InvesteEm(Fundo))
                throw new DomainServiceException("Não é possível realizar um resgate pois o investidor não investe no fundo.");
            else
            {
                var totalInvestidoNoFundo = Investidor.Movimentacoes.Where(x=>x.Fundo == Fundo).Sum(x => x.ValorInvestido);
                if (totalInvestidoNoFundo <= ValorInvestido)
                    throw new DomainServiceException("Não é possível realizar um resgate maior que o disponível no fundo.");
            }
            return true;
        }
    }
}
