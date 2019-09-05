using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;

namespace Desafio.Repository.Repositories
{
    public class FundoRepository : BaseRepository<Fundo>, IFundoRepository
    {
        private DesafioContext context { get; set; }
        public FundoRepository(DesafioContext context)
        : base(context)
        {
            this.context = context;
        }
    }
}
