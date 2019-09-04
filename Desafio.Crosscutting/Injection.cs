using Desafio.Application;
using Desafio.Domain.Applications;
using Desafio.Domain.Repositories;
using Desafio.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Crosscutting
{
    public static class Injection
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<DesafioContext>();

            services.AddTransient<IFundoApplication, FundoApplication>();
            services.AddTransient<IFundoRepository, FundoRepository>();
        }
    }
}
