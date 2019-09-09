using System.ComponentModel;

namespace Desafio.Api.Contracts.Movimento
{
    public enum TipoMovimentoFundoViewModel
    {
        [Description("Aplicação")]
        Aplicacao = 1,
        [Description("Resgate")]
        Resgate = 2
    }
}
