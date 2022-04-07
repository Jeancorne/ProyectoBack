using AppBack.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Injection.v1
{
    public static class InjectInfraestructure
    {
        public static IServiceCollection RegisterInfrastructerServices(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionBD"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
