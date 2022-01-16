using AplicacaoCinema.WebApi.Infraestrutura.Mappers;
using Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace AplicacaoCinema.WebApi.Hosting.Extensions
{
    public static class DapperExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection serviceCollection)
        {
            SqlMapper.AddTypeHandler(new GuidTypeHandler());
            SqlMapper.AddTypeHandler(new HorarioTypeHandler());

            return serviceCollection;
        }
    }
}