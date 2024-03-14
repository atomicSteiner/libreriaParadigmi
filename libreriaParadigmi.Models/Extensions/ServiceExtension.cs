using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });
            services.AddScoped<LibroRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<UtenteRepository>();
            return services;
        }
    }
}
