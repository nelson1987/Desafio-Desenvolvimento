using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Crosscutting.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Register(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ViewModelToEntityProfile>();
                cfg.AddProfile<EntityToViewModelProfile>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
