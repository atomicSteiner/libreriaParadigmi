using FluentValidation;
using FluentValidation.AspNetCore;
using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Services;
using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies().
                SingleOrDefault(assembly => assembly.GetName().Name == "libreriaParadigmi.Application"));
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<IUtenteService, UtenteService>();
            return services;
        }
    }
}
