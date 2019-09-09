using AutoMapper;
using Desafio.Api.Contracts.Movimento.Desafio.Api.Contracts.Movimento;
using Desafio.Domain.Entities;

namespace Desafio.Crosscutting.AutoMapper
{
    public class ViewModelToEntityProfile : Profile
    {
        //construtor..
        public ViewModelToEntityProfile()
        {
            #region Movimentacao
            CreateMap<InclusaoMovimentacaoFundoViewModel, Movimentacao>()
                .ForMember(dst => dst.DataMovimento, opt => opt.MapFrom(src => src.DataMovimentacao))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.ValorInvestido, opt => opt.MapFrom(src => src.ValorMovimentacao));
            #endregion
        }
    }
}
