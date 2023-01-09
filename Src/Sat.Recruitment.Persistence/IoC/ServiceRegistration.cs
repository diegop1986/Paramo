using Sat.Recruitment.Service.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Persistence.IoC
{
    public static class ServiceRegistration
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>((x) =>
            {
                var instance = new UserRepository();
                instance.FillSource();
                return instance;
            } );
        }
    }
}

