using FluentValidation;
using System.Reflection;
using Sat.Recruitment.Service.Interface;
using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Service.Validation;
using Sat.Recruitment.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Service.IoC
{
    public static class ServiceRegistration
    {
        public static IConfiguration Configuration { get; private set; }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddScoped<IUserService, UserService>();
            services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
