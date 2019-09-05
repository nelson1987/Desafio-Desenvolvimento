using System;
using System.Collections.Generic;
using System.Linq;
using Desafio.Domain.Services;

namespace Desafio.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public Guid Id { get; set; }

        public List<Movimentacao> Movimentacoes { get; set; }

        public void Investir(Fundo fundo, decimal valorInvestido)
        {
            InvestimentoService investimento = new InvestimentoService(this, valorInvestido, fundo);
            if (investimento.isValid())
                Movimentacoes.Add(investimento.Movimentacao);
        }

        public bool JaInvesteEm(Fundo fundo)
        {
            return Movimentacoes.Any(x => x.Fundo == fundo);
        }
    }
}
