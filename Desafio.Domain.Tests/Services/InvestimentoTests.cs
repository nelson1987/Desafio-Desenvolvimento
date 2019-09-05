using NUnit.Framework;

namespace Desafio.Domain.Tests.Services
{
    public class InvestimentoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Investir valor menor ao mínimo inicial exigido pelo fundo")]
        public void InvestirMenorQueMinimoInicial()
        {
            Assert.Fail();
        }

        [Test(Description = "Investir valor igual ao mínimo inicial exigido pelo fundo")]
        public void InvestirIgualAMinimoInicial()
        {
            Assert.Fail();
        }

        [Test(Description = "Investir valor maior ao mínimo inicial exigido pelo fundo")]
        public void InvestirMaiorQueMinimoInicial()
        {
            Assert.Fail();
        }

        [Test(Description = "Investir valor maior ao mínimo inicial exigido pelo fundo, depois valor menor que o exigido")]
        public void InvestirMaiorQueMinimoInicialEMenorQueMinimoInicial()
        {
            Assert.Fail();
        }
    }
}
