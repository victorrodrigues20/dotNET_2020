using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.Services;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;
using ProjBiblio.Infrastructure.Data.Repositories;

namespace ProjBiblio.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Projeto de Aplicação
            services.AddScoped<IAutorService, AutorService>();

            //Projeto Domínio | Projeto Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAutorRepository, AutorRepository>();
        }

        public static void RegisterContexts(IServiceCollection services, string conn)
        {
            services.AddDbContext<BibliotecaDbContext>(options => 
                options.UseNpgsql(conn));
        }
    }
}
