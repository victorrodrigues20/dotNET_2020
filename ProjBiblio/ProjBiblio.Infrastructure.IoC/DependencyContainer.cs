using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<ICarrinhoService, CarrinhoService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();

            //Projeto Domínio | Projeto Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAutorRepository, AutorRepository>();
        }

        public static void RegisterContexts(IServiceCollection services, string conn)
        {
            services.AddDbContext<BibliotecaDbContext>(options => 
                options.UseNpgsql(conn));
        }

        public static void RegisterMappers(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.DTOs.Mapping.MappingProfile());
                mc.AddProfile(new Application.ViewModels.Mapping.MappingProfile());
                mc.AddProfile(new Application.InputModels.Mapping.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void RegisterIdentity(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BibliotecaDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
