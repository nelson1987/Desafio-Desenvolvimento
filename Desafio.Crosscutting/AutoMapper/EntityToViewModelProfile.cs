using AutoMapper;
using Desafio.Api.Contracts.Fundo;
using Desafio.Api.Contracts.Movimento;
using Desafio.Domain.Entities;

namespace Desafio.Crosscutting.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {
        //construtor..
        public EntityToViewModelProfile()
        {
            #region Fundo
            CreateMap<Fundo, ListagemFundoViewModel>()
                .ForMember(dst => dst.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.InvestimentoInicialMinimo, opt => opt.MapFrom(src => src.MinimoExigido))
                .ForMember(dst => dst.Nome, opt => opt.MapFrom(src => src.Nome));
            #endregion

            #region Movimento
            CreateMap<Movimentacao, ListagemMovimentacaoFundoViewModel>()
                .ForMember(dst => dst.CpfCliente, opt => opt.MapFrom(src => src.Pessoa.Cpf))
                .ForMember(dst => dst.IdFundo, opt => opt.MapFrom(src => src.Fundo.Id))
                .ForMember(dst => dst.DataMovimentacao, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.ValorMovimentacao, opt => opt.MapFrom(src => src.ValorInvestido))
                .AfterMap((dst, src) => src.TipoMovimentacao = dst.ValorInvestido > 0 ? TipoMovimentoFundoViewModel.Aplicacao : TipoMovimentoFundoViewModel.Resgate);
            #endregion
        }
    }
}
