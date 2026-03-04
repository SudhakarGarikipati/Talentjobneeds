using JobsModule.Application.Mapping;
using JobsModule.Application.Service.Abstraction;
using JobsModule.Application.Service.Implementation;
using JobsModule.Application.Service.Queries;
using JobsModule.Domain;
using JobsModule.Domain.Interfaces;
using JobsModule.Infrastructure.Persistence;
using JobsModule.Infrastructure.Persistence.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobsModule.Infrastructure
{
    public static class JobServiceRegistration
    {
        public static void RegisteredServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TalentjobneedsDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("TalentjobneedsDb"));
            });

            services.AddScoped<IJobApplicationQueries, JobApplicationQueries>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobQueries, JobQueries>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();

            //Mapping
            var config = new TypeAdapterConfig();
            config.Scan(typeof(JobModuleMappings).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
        }
    }
}
