using Application.Mappings;
using Application.Service.Abstraction;
using Application.Service.Implementation;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthServiceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AuthServiceDb")));

            services.AddScoped<IAuthServiceRepo, AuthServiceRepo>();
            services.AddScoped<IAuthAppService, AuthAppService>();

            //Mapping
            var config = new TypeAdapterConfig();
            config.Scan(typeof(UserMapping).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
        }
    }
}
