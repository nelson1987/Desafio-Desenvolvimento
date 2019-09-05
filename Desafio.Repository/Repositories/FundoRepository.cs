using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;

namespace Desafio.Repository.Repositories
{
    public class FundoRepository : BaseRepository<Fundo>, IFundoRepository
    {
        public FundoRepository(DesafioContext context)
        : base(context)
        {
        }
    }
}
