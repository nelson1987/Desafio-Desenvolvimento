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
        private Fundo CopacabanaTrial { get; set; }

        [SetUp]
        public void Setup()
        {
            Investidor = new Pessoa();
            CopacabanaTrial = new Fundo("Copacabana Trial", 1000.00M);
        }

        [Test(Description = "Investir valor maior ao mínimo inicial exigido pelo fundo")]
        public void InvestirMaiorQueMinimoInicial()
        {
            InvestimentoService investimento = new InvestimentoService(Investidor, 2000.00M, CopacabanaTrial);
            Assert.IsTrue(investimento.isValid());
        }

        [Test(Description = "Investir valor igual ao mínimo inicial exigido pelo fundo")]
        public void InvestirIgualAMinimoInicial()
        {
            InvestimentoService investimento = new InvestimentoService(Investidor, 1000.00M, CopacabanaTrial);
            Assert.IsTrue(investimento.isValid());
        }

        [Test(Description = "Investir valor menor ao mínimo inicial exigido pelo fundo")]
        public void InvestirMenorQueMinimoInicial()
        {
            InvestimentoService investimento = new InvestimentoService(Investidor, 500.00M, CopacabanaTrial);
            Exception ex = Assert.Throws<DomainServiceException>(delegate { investimento.isValid(); });
            Assert.That(ex.Message, Is.EqualTo("O valor investido deve ser maior que o mínimo exigido."));
        }

        [Test(Description = "Investir valor maior ao mínimo inicial exigido pelo fundo, depois valor menor que o exigido")]
        public void InvestirMaiorQueMinimoInicialEMenorQueMinimoInicial()
        {
            Investidor.Investir(CopacabanaTrial, 2000.00M);
            Investidor.Investir(CopacabanaTrial, 500.00M);
            Assert.AreEqual(Investidor.Movimentacoes.Count(), 2);
        }
    }
}
