using Desafio.Domain.Entities;
using Desafio.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Desafio.Domain.Tests.Services
{
    public class ResgateTests
    {
        private Pessoa investidor { get; set; }

        private Fundo fundo { get; set; }

        private Fundo fundoNovo { get; set; }

        [SetUp]
        public void Setup()
        {
            investidor = new Pessoa();
            fundo = new Fundo("Copacabana Trial", 1000.00M);
            fundoNovo = new Fundo("Vargas FCI", 5000.00M);
        }

        [Test(Description = "Tentar resgatar valor de um fundo que não pertence a carteira do cliente")]
        public void ResgatarSemTerOFundo()
        {
            Exception ex = Assert.Throws<DomainServiceException>(delegate { investidor.Resgatar(fundo, 100.00M); });
            Assert.AreEqual(ex.Message, Resources.Dicionario.IMPOSSIVEL_RESGATE_INVESTIDOR_NAO_INVESTE_NO_FUNDO);
        }

        [Test(Description = "Resgatar valor abaixo do total disponivel no fundo")]
        public void ResgatarAbaixoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 1000.00M);
            Assert.AreEqual(investidor.Movimentacoes.Count(), 2);
            Assert.AreEqual(investidor.Movimentacoes.Where(x => x.Fundo == fundo).Sum(x=>x.ValorInvestido), 1000.00M);
        }

        [Test(Description = "Resgatar valor igual ao total disponivel no fundo")]
        public void ResgatarIgualDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 2000.00M);
            Assert.AreEqual(investidor.Movimentacoes.Count(), 2);
            Assert.AreEqual(investidor.Movimentacoes.Where(x => x.Fundo == fundo).Sum(x => x.ValorInvestido), 0.00M);
        }

        [Test(Description = "Resgatar valor acima do total disponivel no fundo")]
        public void ResgatarAcimaDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);

            Exception ex = Assert.Throws<DomainServiceException>(delegate { investidor.Resgatar(fundo, 3000.00M); });
            Assert.AreEqual(ex.Message, Resources.Dicionario.IMPOSSIVEL_RESGATE_MAIOR_QUE_DISPONIVEL);
        }

        [Test(Description = "Resgatar valor de fundo não disponível para o cliente")]
        public void ResgatarValorDeFundoNaoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            Exception ex = Assert.Throws<DomainServiceException>(delegate { investidor.Resgatar(fundoNovo, 2000.00M); });
            Assert.AreEqual(ex.Message, Resources.Dicionario.IMPOSSIVEL_RESGATE_INVESTIDOR_NAO_INVESTE_NO_FUNDO);
        }

        [Test(Description = "Resgatar valor menor ao disponível no fundo e depois igual ao disponível")]
        public void ResgatarMenorEAposIgualAoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 1000.00M);
            investidor.Resgatar(fundo, 1000.00M);
            Assert.AreEqual(investidor.Movimentacoes.Count(), 3);
        }

        [Test(Description = "Resgatar abaixo do disponivel e depois acima do disponível em seguida")]
        public void ResgatarValorAbaixoEmSeguidaValorAcimaDoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 1000.00M);
            
            Exception ex = Assert.Throws<DomainServiceException>(delegate { investidor.Resgatar(fundo, 4000.00M); });
            Assert.AreEqual(ex.Message, Resources.Dicionario.IMPOSSIVEL_RESGATE_MAIOR_QUE_DISPONIVEL);

        }
    }
}