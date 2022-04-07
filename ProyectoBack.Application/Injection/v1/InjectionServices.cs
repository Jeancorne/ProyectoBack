using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoBack.Application.Interfaces;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Application.Services.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoBack.Application.Injection.v1
{
    public static class InjectionServices
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            //Instancias de servicios
            service.AddScoped<IServicio, Servicio>();
            
            return service;
        }
    }
}
