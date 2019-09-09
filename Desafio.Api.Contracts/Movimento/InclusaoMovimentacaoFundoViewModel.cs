using System;

namespace Desafio.Api.Contracts.Movimento
{
    namespace Desafio.Api.Contracts.Movimento
    {
        public class InclusaoMovimentacaoFundoViewModel
        {
            public Guid Id { get; set; }
            public Guid IdMovimentacao { get; set; }
            public TipoMovimentoFundoViewModel TipoMovimentacao { get; set; }
            public Guid IdFundo { get; set; }
            public string CpfCliente { get; set; }
            public decimal ValorMovimentacao { get; set; }
            public decimal DataMovimentacao { get; set; }
        }
    }
}
