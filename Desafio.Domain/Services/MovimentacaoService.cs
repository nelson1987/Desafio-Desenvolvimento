using Desafio.Domain.Entities;

namespace Desafio.Domain.Services
{
    public abstract class MovimentacaoService
    {

        protected MovimentacaoService(Pessoa investidor, decimal valorInvestido, Fundo fundo)
        {
            Investidor = investidor;
            ValorInvestido = valorInvestido;
            Fundo = fundo;
        }

        public decimal ValorInvestido { get; private set; }

        public Fundo Fundo { get; set; }

        public Pessoa Investidor { get; set; }

        public Movimentacao Movimentacao
        {
            get
            {
                return new Movimentacao
                {
                    Fundo = this.Fundo,
                    ValorInvestido = this.ValorInvestido,
                    Pessoa = this.Investidor
                };
            }
        }
        public abstract bool isValid();
    }
}
