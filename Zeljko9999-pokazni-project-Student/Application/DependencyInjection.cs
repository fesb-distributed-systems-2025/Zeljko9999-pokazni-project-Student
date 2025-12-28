using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Repositories;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IProgramTypeRepository, ProgramTypeRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProgramTypeService, ProgramTypeService>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
