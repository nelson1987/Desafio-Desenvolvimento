using System;

namespace Desafio.Api.Contracts.Fundo
{
    public class ListagemFundoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal InvestimentoInicialMinimo { get; set; }
    }
}