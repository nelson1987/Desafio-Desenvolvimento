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
        public decimal ValorTotalDisponivel(Fundo fundo)
        {
            return Movimentacoes.Where(x => x.Fundo == fundo).Sum(x => x.ValorInvestido);
        }
        public Guid Id { get; set; }

        public List<Movimentacao> Movimentacoes { get; set; }

        public void Investir(Fundo fundo, decimal valorInvestido)
        {
            InvestimentoService investimento = new InvestimentoService(this, valorInvestido, fundo);
            if (investimento.isValid())
                Movimentacoes.Add(investimento.Movimentacao);
        }

        public void Resgatar(Fundo fundo, decimal valorInvestido)
        {
            ResgateService resgate = new ResgateService(this, valorInvestido, fundo);
            if (resgate.isValid())
                Movimentacoes.Add(resgate.Movimentacao);
        }

        public bool InvesteEm(Fundo fundo)
        {
            return Movimentacoes.Any(x => x.Fundo == fundo);
        }
    }
}
