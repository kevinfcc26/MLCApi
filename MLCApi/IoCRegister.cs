using Microsoft.Extensions.DependencyInjection;
using MLCApi.IRepositories;
using MLCApi.Models;
using MLCApi.Repositories;
using MLCApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            return services;
        }
        public static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IVendedoresService,VendedoresService>();
            services.AddTransient<IVehiculosService,VehiculosService>();

            return services;
        }
        public static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Marca>,MarcaRepository>();
            services.AddTransient<IRepository<Vehiculos>, VehiculosRepository >();
            services.AddTransient<IRepository<Vendedores>, VendedoresRepository>();
            services.AddTransient<IRepository<Ventas>, VentasRepository>();

            return services;
        }
    }
}
