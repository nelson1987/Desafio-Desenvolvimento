using System;

namespace Desafio.Domain.Entities
{
    public class Fundo
    {
        protected Fundo()
        {

        }

        public Fundo(string nome, decimal minimoExigido) : this()
        {
            Nome = nome;
            MinimoExigido = minimoExigido;
        }

        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal MinimoExigido { get; set; }
    }
}
