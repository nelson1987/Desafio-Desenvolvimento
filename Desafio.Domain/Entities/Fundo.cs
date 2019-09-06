using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entities
{
    public class Fundo
    {
        protected Fundo()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public Fundo(string nome, decimal minimoExigido) : this()
        {
            Nome = nome;
            MinimoExigido = minimoExigido;
        }

        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal MinimoExigido { get; set; }
        public virtual List<Movimentacao> Movimentacoes { get; set; }
    }
}
