using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Api.Contracts.Movimento
{
    public class ListagemMovimentacaoFundoViewModel
    {
        public Guid Id { get; set; }
        public TipoMovimentoFundoViewModel TipoMovimentacao { get; set; }
        public Guid IdFundo { get; set; }
        public string CpfCliente { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public decimal DataMovimentacao { get; set; }
    }
}
