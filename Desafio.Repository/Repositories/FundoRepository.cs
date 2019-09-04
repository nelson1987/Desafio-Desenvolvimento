using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;

namespace Desafio.Repository.Repositories
{
    public class FundoRepository
        : BaseRepository<Fundo>, IFundoRepository
    {
        private readonly DesafioContext context;
        public FundoRepository(DesafioContext context)
        : base(context)
        {
            this.context = context;
        }
    }
}
