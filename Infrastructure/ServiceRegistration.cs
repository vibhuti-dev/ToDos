using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IToDoRepository, ToDoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}