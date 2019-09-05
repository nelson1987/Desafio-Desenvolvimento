using System;

namespace Desafio.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; }
        public Fundo Fundo { get; set; }
        public decimal ValorInvestido { get; set; }
    }
}
