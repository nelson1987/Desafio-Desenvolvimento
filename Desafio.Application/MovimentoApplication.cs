using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;
using Desafio.Domain.Services;
using System;
using System.Collections.Generic;

namespace Desafio.Application
{
    public class MovimentoApplication : IMovimentoApplication
    {
        private IMovimentoRepository MovimentoRepository { get; set; }
        private IPessoaRepository PessoaRepository { get; set; }
        private IFundoRepository FundoRepository { get; set; }

        public MovimentoApplication(IMovimentoRepository MovimentoRepository)
        {
            this.MovimentoRepository = MovimentoRepository;
        }

        public List<Movimentacao> Listar()
        {
            return MovimentoRepository.BuscarMovimentos();
        }

        public void Resgatar(Movimentacao movimentacao)
        {
            var pessoa = PessoaRepository.FindByCpf(movimentacao.Pessoa.Cpf);
            var fundo = FundoRepository.FindById(movimentacao.Fundo.Id);
            ResgateService resgate = new ResgateService(pessoa, movimentacao.ValorInvestido, fundo);
            if (resgate.isValid())
            {
                MovimentoRepository.Insert(resgate.Movimentacao);
            }
        }

        public void Aplicar(Movimentacao movimentacao)
        {
            var pessoa = PessoaRepository.FindByCpf(movimentacao.Pessoa.Cpf);
            var fundo = FundoRepository.FindById(movimentacao.Fundo.Id);
            InvestimentoService investimento = new InvestimentoService(pessoa, movimentacao.ValorInvestido, fundo);
            if (investimento.isValid())
            {
                MovimentoRepository.Insert(investimento.Movimentacao);
            }
        }
    }
}
