using Desafio.Domain.Entities;
using Desafio.Domain.Exceptions;

namespace Desafio.Domain.Services
{
    public class InvestimentoService : MovimentacaoService
    {
        public InvestimentoService(Pessoa investidor, decimal valorInvestido, Fundo fundo)
            : base(investidor, valorInvestido, fundo)
        {
        }

        public override bool isValid()
        {
            if (!Investidor.InvesteEm(Fundo))
            {
                if (ValorInvestido < Fundo.MinimoExigido)
                {
                    throw new DomainServiceException(Resources.Dicionario.VALOR_INVESTIDO_SERA_MAIOR_MINIMO_EXIGIDO);
                }
            }
            return true;
        }
    }
}
