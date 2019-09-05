using Desafio.Domain.Entities;
using Desafio.Domain.Exceptions;
using NUnit.Framework;
using System;

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
            Assert.That(ex.Message, Is.EqualTo("Não é possível realizar um resgate pois o investidor não investe no fundo."));
        }

        [Test(Description = "Resgatar valor abaixo do total disponivel no fundo")]
        public void ResgatarAbaixoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 1000.00M);
        }

        [Test(Description = "Resgatar valor igual ao total disponivel no fundo")]
        public void ResgatarIgualDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 2000.00M);
        }

        [Test(Description = "Resgatar valor acima do total disponivel no fundo")]
        public void ResgatarAcimaDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 3000.00M);
        }

        [Test(Description = "Resgatar valor de fundo não disponível para o cliente")]
        public void ResgatarValorDeFundoNaoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            Exception ex = Assert.Throws<DomainServiceException>(delegate { investidor.Resgatar(fundoNovo, 2000.00M); });
            Assert.That(ex.Message, Is.EqualTo("Não é possível realizar um resgate pois o investidor não investe no fundo."));
        }

        [Test(Description = "Resgatar valor menor ao disponível no fundo e depois igual ao disponível")]
        public void ResgatarMenorEAposIgualAoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 1000.00M);
            investidor.Resgatar(fundo, 1000.00M);
        }

        [Test(Description = "Resgatar abaixo do disponivel e depois acima do disponível em seguida")]
        public void ResgatarValorAbaixoEmSeguidaValorAcimaDoDisponivel()
        {
            investidor.Investir(fundo, 2000.00M);
            investidor.Resgatar(fundo, 1000.00M);
            investidor.Resgatar(fundo, 4000.00M);
        }
    }
}