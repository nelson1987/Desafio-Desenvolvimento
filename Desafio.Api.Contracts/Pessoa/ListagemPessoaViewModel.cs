using Desafio.Domain.Entities;
using System;

namespace Desafio.Api.Contracts
{
    public class ListagemPessoaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal MinimoExigido { get; set; }
    }
}
