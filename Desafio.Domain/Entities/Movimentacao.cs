using System;

namespace Desafio.Domain.Entities
{
    public class Movimentacao
    {
        public virtual Guid Id { get; set; }
        public virtual Fundo Fundo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual decimal ValorInvestido { get; set; }
        public virtual DateTime DataMovimento { get; set; }
    }
}
