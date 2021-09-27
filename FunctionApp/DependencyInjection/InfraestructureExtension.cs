using Infrastructure.CardinalMap;
using Infrastructure.CardinalMap.Contracts;
using Infrastructure.Graphs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp.DependencyInjection
{
    public static class InfraestructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGraphSearch, GraphSearch>();

            string[] defaultPoints = configuration.GetSection("DefaultGraphPoints").Get<string[]>();

            services.AddTransient<IGraph>(s => new Graph(defaultPoints));

            services.AddScoped<ICardinalChain, CardinalChain>();
            services.AddScoped<ICardinalMap, CardinalMap>();
            services.AddScoped<ICardinalPoint, CardinalPoint>();

            return services;
        }
    }
}
