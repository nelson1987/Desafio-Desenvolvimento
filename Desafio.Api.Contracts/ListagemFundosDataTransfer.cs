using Desafio.Domain.Entities;
using System;

namespace Desafio.Api.Contracts
{
    public class ListagemFundosDataTransfer
    {
        public ListagemFundosDataTransfer(Fundo entity)
        {
            Id = entity.Id;
            Nome = entity.Nome;
            MinimoExigido = entity.MinimoExigido;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal MinimoExigido { get; set; }
    }
}
