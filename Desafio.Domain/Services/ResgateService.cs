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
            {
                throw new DomainServiceException(Resources.Dicionario.IMPOSSIVEL_RESGATE_INVESTIDOR_NAO_INVESTE_NO_FUNDO);
            }
            else
            {
                if (Investidor.ValorTotalDisponivel(Fundo) < (ValorInvestido * -1))
                {
                    throw new DomainServiceException(Resources.Dicionario.IMPOSSIVEL_RESGATE_MAIOR_QUE_DISPONIVEL);
                }
            }
            return true;
        }
    }
}
