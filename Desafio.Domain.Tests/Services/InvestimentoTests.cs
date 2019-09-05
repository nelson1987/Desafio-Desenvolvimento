using Desafio.Domain.Entities;
using Desafio.Domain.Services;
using Desafio.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Desafio.Domain.Tests.Services
{
    public class InvestimentoTests
    {
        private Pessoa Investidor { get; set; }

        [SetUp]
        public void Setup()
        {
            Investidor = new Pessoa();
        }

        [Test(Description = "Investir valor maior ao mínimo inicial exigido pelo fundo")]
        public void InvestirMaiorQueMinimoInicial()
        {
            Fundo copacabanaTrial = new Fundo("Copacabana Trial", 1000.00M);
            InvestimentoService investimento = new InvestimentoService(Investidor, 2000.00M, copacabanaTrial);
            Assert.IsTrue(investimento.isValid());
        }

        [Test(Description = "Investir valor igual ao mínimo inicial exigido pelo fundo")]
        public void InvestirIgualAMinimoInicial()
        {
            Fundo copacabanaTrial = new Fundo("Copacabana Trial", 1000.00M);
            InvestimentoService investimento = new InvestimentoService(Investidor, 1000.00M, copacabanaTrial);
            Assert.IsTrue(investimento.isValid());
        }

        [Test(Description = "Investir valor menor ao mínimo inicial exigido pelo fundo")]
        public void InvestirMenorQueMinimoInicial()
        {
            Fundo copacabanaTrial = new Fundo("Copacabana Trial", 1000.00M);
            InvestimentoService investimento = new InvestimentoService(Investidor, 500.00M, copacabanaTrial);
            Exception ex = Assert.Throws<DomainServiceException>(delegate { investimento.isValid(); });
            Assert.That(ex.Message, Is.EqualTo("O valor investido deve ser maior que o mínimo exigido."));
        }

        [Test(Description = "Investir valor maior ao mínimo inicial exigido pelo fundo, depois valor menor que o exigido")]
        public void InvestirMaiorQueMinimoInicialEMenorQueMinimoInicial()
        {
            Fundo copacabanaTrial = new Fundo("Copacabana Trial", 1000.00M);

            Pessoa investidor = new Pessoa();
            investidor.Investir(copacabanaTrial, 2000.00M);
            investidor.Investir(copacabanaTrial, 500.00M);
            Assert.AreEqual(investidor.Movimentacoes.Count(), 2);
        }
    }
}
