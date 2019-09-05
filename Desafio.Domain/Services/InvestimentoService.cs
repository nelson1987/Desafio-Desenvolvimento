using Desafio.Domain.Entities;
using Desafio.Domain.Exceptions;
using System.Linq;

namespace Desafio.Domain.Services
{
    public class InvestimentoService
    {
        private decimal ValorInvestido;

        public InvestimentoService(Pessoa investidor, decimal valorInvestido, Fundo fundo)
        {
            Investidor = investidor;
            ValorInvestido = valorInvestido;
            Fundo = fundo;
        }

        public Fundo Fundo { get; set; }

        public Pessoa Investidor { get; set; }

        public Movimentacao Movimentacao { get { return new Movimentacao() { Fundo = this.Fundo }; } }

        public bool isValid()
        {
            if (!Investidor.JaInvesteEm(Fundo))
            {
                if (ValorInvestido < Fundo.MinimoExigido)
                    throw new DomainServiceException("O valor investido deve ser maior que o mínimo exigido.");
            }
            return true;
        }
    }
}
