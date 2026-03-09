using JobsModule.Application.DTOs;
using JobsModule.Domain.Entities;
using Mapster;

namespace JobsModule.Application.Mapping
{
    public class JobModuleMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //Here we register the mappings
            //Example:
            //config.NewConfig<source, destination>();
            config.NewConfig<Job, JobDTO>()
                .Map(dest => dest.CompanyName, src => src.Employer != null ? src.Employer.CompanyName : null)
                .Map(dest => dest.CompanyLogo, src => src.Employer != null ? src.Employer.CompanyLogo : null);

            config.NewConfig<(Job job, Employer employer), JobDTO>()
                //.Map(dest => dest.CompanyName, src => src.Item2 != null ? src.Item2.CompanyName : null)
                //.Map(dest => dest.CompanyLogo, src => src.Item2 != null ? src.Item2.CompanyLogo : null);
                .Map(dest => dest, src => src.job)
                .Map(dest => dest, src => src.employer);

            config.NewConfig<JobDTO, Job>()
                .Ignore(dest => dest.Employer);

            config.NewConfig<JobApplicationDTO, JobApplication>()
                .TwoWays();

        }
    }
}
