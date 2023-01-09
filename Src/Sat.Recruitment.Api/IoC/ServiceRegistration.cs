using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Api.IoC
{
    public static class ServiceRegistration
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
        }
    }
}
