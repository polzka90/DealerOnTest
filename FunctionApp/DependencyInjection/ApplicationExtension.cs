using Application.UseCases.MarsRovers;
using Application.UseCases.SalesTaxes;
using Application.UseCases.Trains;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MediatR;
using System.Reflection;
using System.Collections.Generic;

namespace FunctionApp.DependencyInjection
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.GetName().Name == "Application").ToList();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(assembly => assembly.GetName().Name == "Application"));
            services.AddScoped<IMarsRoversCommandHandler, MarsRoversCommandHandler>();
            services.AddScoped<ISalesTaxesCommandHandler, SalesTaxesCommandHandler>();
            services.AddScoped<ITrainsCommandHandler, TrainsCommandHandler>();

            return services;
        }
    }
}
