using NUnit.Framework;

namespace Desafio.Domain.Tests.Services
{
    public class ResgateTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test(Description = "Resgatar valor abaixo do total disponivel no fundo")]
        public void ResgatarAbaixoDisponivel()
        {
            Assert.Fail();
        }

        [Test(Description = "Resgatar valor igual ao total disponivel no fundo")]
        public void ResgatarIgualDisponivel()
        {
            Assert.Fail();
        }

        [Test(Description = "Resgatar valor acima do total disponivel no fundo")]
        public void ResgatarAcimaDisponivel()
        {
            Assert.Fail();
        }

        [Test(Description = "Resgatar valor de fundo não disponível para o cliente")]
        public void ResgatarValorDeFundoNaoDisponivel()
        {
            Assert.Fail();
        }

        [Test(Description = "Resgatar valor menor ao disponível no fundo e depois igual ao disponível")]
        public void ResgatarMenorEAposIgualAoDisponivel()
        {
            Assert.Fail();
        }

        [Test(Description = "Investir abaixo do disponivel e depois acima do disponível em seguida")]
        public void ResgatarValorAbaixoEmSeguidaValorAcimaDoDisponivel()
        {
            Assert.Fail();
        }
    }
}